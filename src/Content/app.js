"use strict";
var app_component_1 = require("./app.component");
require("../Views/styles.scss");
var Test = (function () {
    function Test() {
    }
    Test.prototype.showAlert = function () {
        var o = new app_component_1.AnotherClass();
        o.showMessage("Hello world, Arun Thakur");
    };
    return Test;
}());
new Test().showAlert();
//# sourceMappingURL=app.js.map