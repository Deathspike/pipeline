import * as mui from '@material-ui/core';

export function patchStyles(source: Record<any, any>) {
  for (const key in source) {
    const match = key.match(/^((.*)Styles)$/);
    const view = match && source[match[2]];
    const style = match && source[match[1]];
    if (match && view && style) source[match[2]] = mui.withStyles(style)(view);
  }
}
