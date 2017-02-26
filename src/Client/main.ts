import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import '../Views/styles.scss';
import { AppModule } from './app/app.module';

platformBrowserDynamic().bootstrapModule(AppModule);