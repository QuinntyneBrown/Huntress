import { Role } from "./role";

export type User = {
    userId: string,
    username: string,
    password: string,
    roles: Role[]
};
