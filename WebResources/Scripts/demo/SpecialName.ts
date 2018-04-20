//deploy: kipon_/some/deep/path/special.js

module Spec {
    export class Some {
        id: string;
    }

    function loadForm(ctx: Xrm.Events.EventContext): void {
        console.log('do nothing...');
    }
}