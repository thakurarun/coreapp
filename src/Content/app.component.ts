import $ = require("jquery");
export class AnotherClass {
    showMessage(name: string) {
        $("p").text(name);
    }
}