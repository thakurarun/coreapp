import { Component } from '@angular/core';

@Component({
    selector: 'team-app',
    template: `
            <sidebar></sidebar>
            <div class="container main-content">
                <view-profile></view-profile>
            </div>
            `
})

export class AppComponent {

}