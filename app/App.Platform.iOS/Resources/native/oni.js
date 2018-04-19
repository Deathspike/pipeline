var oni = (function() {
  var handlers = {};
  var lastId = 0;

  return {
    on: function(eventName, handler) {
      if (handlers[eventName]) {
        handlers[eventName].push(handler);
      } else {
        handlers[eventName] = [handler];
      }
    },

    fromNative: function(eventName, value) {
      if (handlers[eventName]) {
        for (var i = 0; i < handlers[eventName].length; i += 1) {
          handlers[eventName][i](value);
        }
      }
    },

    toNativeAsync: function(eventName, value) {
      var callbackId = lastId++;
      var callbackName = "onicb_" + callbackId;
      return new Promise(function(resolve, reject) {
        window[callbackName] = function(success, result) {
          delete window[callbackName];
          (success ? resolve : reject)(result);
        };
        console.log("oni:" + JSON.stringify({callbackName: callbackName, eventName: eventName, value: value}));
      });
    }
  };
})();
