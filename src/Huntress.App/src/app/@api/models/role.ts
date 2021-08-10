import { Privilege } from "@api";
import { AggregatePrivilege } from "./aggregate-privilege";

export type Role = {
    roleId: string,
    name: string,
    privileges: Privilege[],
    aggregatePrivileges: AggregatePrivilege[]
};
