import { AnotherClass } from './app.component';
import '../Views/styles.scss';

class Test {
    showAlert() {
        let o = new AnotherClass();
        o.showMessage("ARUN THAKUR IS BEST");
    }
}

new Test().showAlert();