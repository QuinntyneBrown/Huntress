import { InjectionToken } from "@angular/core";

export const storageKey = 'huntress';
export const accessTokenKey = `${storageKey}:accessTokenKey`;
export const usernameKey = `${storageKey}:usernameKey`;
export const baseUrl = 'baseUrl';
export const currentUserKey = `${storageKey}:currentUserKey`;
export const currentProfileKey = `${storageKey}:currentProfileKey`;
export const ACTION_EFFECT_LOOKUP = new InjectionToken("Action Effect Lookup");
export const pageSizeOptions = ["5", "10", "25"];
export const BASE_URL = new InjectionToken("BASE_URL");
