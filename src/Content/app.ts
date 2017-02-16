import { AnotherClass } from './app.component';
import '../Views/styles.scss';

class Test {
    showAlert() {
        let o = new AnotherClass();
        o.showMessage("Hello world, Arun Thakur");
    }
}

new Test().showAlert();