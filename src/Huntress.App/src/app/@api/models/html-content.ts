import { HtmlContentType } from "./html-content-type";

export type HtmlContent = {
    htmlContentId: string,
    name: string,
    body: string,
    type: HtmlContentType
};
