import { Privilege } from "./privilege";

export type AggregatePrivilege  = {
  aggregate: string,
  privileges: Privilege[]
};
