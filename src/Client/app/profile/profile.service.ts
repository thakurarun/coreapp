import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { IUserProfileDTO } from './model';

@Injectable()
export class ProfileService {

    constructor(private http: Http) { }

    getProfile(): Observable<IUserProfileDTO> {
        let url = "/api/Profile";
        return this.http.get(url)
            .map(result => result.json())
            .catch(err => {
                throw err.json();
            });
    }

    saveProfile(profile: IUserProfileDTO) {
        let url = "/api/Profile";
        return this.http.post(url, profile)
            .map(result => result.json())
            .catch((err: any) => {
                throw err.json();
            });
    }
}
