import $ = require("jquery");
export class AnotherClass {
    showMessage(name: string) {
        $("p#content").text(name);
    }
}