"use strict";
var app_component_1 = require("./app.component");
require("../Views/styles.scss");
var Test = (function () {
    function Test() {
    }
    Test.prototype.showAlert = function () {
        var o = new app_component_1.AnotherClass();
        o.showMessage("ARUN THAKUR IS BEST");
    };
    return Test;
}());
new Test().showAlert();
//# sourceMappingURL=app.js.map