import { Privilege } from "@api";

export type Role = {
    roleId: string,
    name: string,
    privileges: Privilege[]
};
