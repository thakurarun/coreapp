"use strict";
var $ = require("jquery");
var AnotherClass = (function () {
    function AnotherClass() {
    }
    AnotherClass.prototype.showMessage = function (name) {
        $("p").text(name);
    };
    return AnotherClass;
}());
exports.AnotherClass = AnotherClass;
//# sourceMappingURL=app.component.js.map