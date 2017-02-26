import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

import { IUserProfileDTO, IErrorMessage } from './model';
import { ProfileService } from './profile.service';
import * as _ from 'lodash';

@Component({
    selector: 'view-profile',
    template: require('./profile.html')
})
export class ViewProfileComponent implements OnInit {

    constructor(private profileService: ProfileService) {
    }

    private editMode = false;
    private userProfile: IUserProfileDTO;
    private originalUserProfile: IUserProfileDTO;
    private welcomeMessage: string = "Welcome";
    private errorMessages: IErrorMessage[] = [];
    private hasError = false;

    ngOnInit() {
        this.getProfile();
    }

    getProfile() {
        this.profileService.getProfile()
            .subscribe(profile => {
                this.userProfile = profile;
                this.originalUserProfile = _(this.userProfile).cloneDeep();
            });
    }

    editProfile() {
        this.editMode = true;
    }

    saveProfile() {
        this.profileService.saveProfile(this.userProfile)
            .subscribe(response => {
                this.getProfile();
                this.editMode = false;
                this.hasError = false;
            }, (error) => {
                this.parseError(error);
            });
    }

    cancelSaveProfile() {
        this.editMode = false;
        this.hasError = false;
        this.userProfile = _(this.originalUserProfile).cloneDeep();
    }

    private parseResponse(response) {
    }

    private parseError(error: any) {
        this.errorMessages.length = 0;
        this.hasError = true;
        Object.keys(error).map(key => {
            let errorMessage: IErrorMessage = {
                message: error[key],
                type: key == "" ? "model" : "property"
            };
            this.errorMessages.push(errorMessage);
        })
    }
}