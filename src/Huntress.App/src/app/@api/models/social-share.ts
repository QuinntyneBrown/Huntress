import { SocialShareType } from "./social-share-type";

export type SocialShare = {
    socialShareId: string,
    url: string,
    shareType: SocialShareType
};
