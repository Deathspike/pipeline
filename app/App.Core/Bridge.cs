using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using App.Core.Interfaces;
using App.Core.Models;
using App.Core.Plugins;
using Newtonsoft.Json;

namespace App.Core
{
    public sealed class Bridge
    {
        private readonly IClient _client;
        private readonly ICorePlugin _corePlugin;
        private readonly SortedDictionary<string, SortedDictionary<object, bool>> _queue;
        private bool _isActive;

        #region Abstracts

        private void EmptyQueue()
        {
            while (_queue.Count != 0)
            {
                var list = _queue.First();

                foreach (var item in list.Value)
                {
                    SendOrQueue(item.Value, list.Key, item.Key);
                }

                _queue.Remove(list.Key);
            }
        }

        private object ProcessRequest(RequestData requestData)
        {
            var pieceList = requestData.EventName.ToLowerInvariant().Split('.').ToList();
            var source = _corePlugin as object;

            while (pieceList.Count > 1)
            {
                var pi = source.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name.ToLower() == pieceList[0]);
                if (pi == null) break;
                source = pi.GetValue(source);
                pieceList.RemoveAt(0);
            }

            while (pieceList.Count == 1)
            {
                var mi = source.GetType().GetRuntimeMethods().FirstOrDefault(x => x.Name.ToLower() == pieceList[0]);
                if (mi == null) break;
                var pi = mi.GetParameters();
                return mi.Invoke(source, pi.Length != 0 ? new[] {requestData.Value.ToObject(pi[0].ParameterType)} : null);
            }

            throw new Exception("Unknown event source");
        }

        private void ProcessResponse(RequestData requestData, object response)
        {
            if (response is Task task)
            {
                task.ContinueWith(x =>
                {
                    if (x.IsFaulted)
                    {
                        _client.Submit(requestData.CallbackName, new SubmitData(false, string.Join(
                            Environment.NewLine,
                            x.Exception.InnerExceptions.Select(y => y.Message))));
                    }
                    else if (x.GetType().IsConstructedGenericType)
                    {
                        _client.Submit(requestData.CallbackName, new SubmitData(true, x.GetType()
                            .GetRuntimeProperty(nameof(Task<object>.Result))
                            .GetValue(x)));
                    }
                    else
                    {
                        _client.Submit(requestData.CallbackName, new SubmitData(true));
                    }
                });
            }
            else
            {
                _client.Submit(requestData.CallbackName, new SubmitData(true, response));
            }
        }

        private void SendOrQueue(bool isExclusive, string eventName, object value)
        {
            if (_isActive)
            {
                _client.Submit("oni.fromNative", new SubmitData(eventName, value));
            }
            else if (!_queue.TryGetValue(eventName, out var values))
            {
                _queue[eventName] = new SortedDictionary<object, bool> {{value, isExclusive}};
            }
            else if (!isExclusive)
            {
                values.Add(value, false);
            }
            else
            {
                values.Clear();
                values.Add(value, true);
            }
        }

        #endregion

        #region Constructor

        public Bridge(IClient client, ICorePlugin corePlugin)
        {
            _client = client;
            _corePlugin = corePlugin;
            _queue = new SortedDictionary<string, SortedDictionary<object, bool>>();
        }

        #endregion

        #region Methods

        public void ProcessRequest(string json)
        {
            var requestData = JsonConvert.DeserializeObject<RequestData>(json);
            var response = null as object;

            try
            {
                response = ProcessRequest(requestData);
            }
            catch (Exception ex)
            {
                _client.Submit(requestData.CallbackName, new SubmitData(false, ex.Message));
            }
            finally
            {
                if (response != null) ProcessResponse(requestData, response);
            }
        }

        public void SubmitEvent(string eventName, object value = null)
        {
            SendOrQueue(false, eventName, value);
        }

        public void SubmitExclusiveEvent(string eventName, object value = null)
        {
            SendOrQueue(true, eventName, value);
        }

        public void UpdateActiveState(bool isActive)
        {
            _isActive = isActive;
            if (_isActive) EmptyQueue();
        }

        #endregion
    }
}