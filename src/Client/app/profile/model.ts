export interface IUserProfileDTO {
    profileId: string;
    firstName: string;
    lastName: string;
    contact: string;
    active: boolean;
}

export interface IErrorMessage {
    message: string;
    type: string;
}