import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

import { IUserProfileDTO } from './model';

@Injectable()
export class ProfileService {

    constructor(private http: Http) { }

    getProfile(): Observable<IUserProfileDTO> {
        let url = "http://localhost:6659/api/Profile";
        return this.http.get(url)
            .map(result => result.json() as IUserProfileDTO);
    }

    saveProfile(profile: IUserProfileDTO) {
        let url = "http://localhost:6659/api/Profile";
        return this.http.post(url, profile)
            .map(result => result.json() as IUserProfileDTO);
    }
}