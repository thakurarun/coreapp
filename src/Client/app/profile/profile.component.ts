import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

import { IUserProfileDTO } from './model';
import { ProfileService } from './profile.service';

@Component({
    selector: 'view-profile',
    template: require('./profile.html')
})
export class ViewProfileComponent implements OnInit {

    constructor(private profileService: ProfileService) {
    }

    private editMode = false;
    private userProfile: IUserProfileDTO;
    private welcomeMessage: string = "Welcome";

    initProfile() {
        this.profileService.getProfile()
            .subscribe(profile => {
                this.userProfile = profile;
            });
    }

    editProfile() {
        this.editMode = true;
    }

    saveProfile() {
        this.profileService.saveProfile(this.userProfile)
            .subscribe(response => {
                this.parseResponse(response);
                this.editMode = false;
            }, (error) => {
                this.parseError(error);
            });
    }

    private parseResponse(response) {
    }

    private parseError(error: Error) {
        // TODO: PARSE ERROR properly...
    }

    ngOnInit() {
        this.initProfile();
    }

}