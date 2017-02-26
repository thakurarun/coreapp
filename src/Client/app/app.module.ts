import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';

import { ProfileService } from './profile/profile.service';
import { ViewProfileComponent } from './profile/profile.component';
import { SidebarComponent } from './sidebar/sidebar.component';

@NgModule({
    imports: [BrowserModule, HttpModule, FormsModule],
    declarations: [AppComponent, ViewProfileComponent, SidebarComponent],
    bootstrap: [AppComponent],
    providers: [
        ProfileService
    ]
})
export class AppModule { }