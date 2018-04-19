interface Window {
  oni?: {
    on: <T>(eventName: string, handler: (value?: T) => void) => void;
    fromNative: <T>(eventName: string, value?: T) => void;
    toNativeAsync: <TItem, TResult>(eventName: string, value?: TItem) => Promise<TResult>;
  };
}
