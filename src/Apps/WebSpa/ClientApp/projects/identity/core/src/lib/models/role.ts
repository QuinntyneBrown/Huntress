// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Privilege } from "./privilege";
import { User } from "./user";

export type Role = {
  roleId?: string;
  name?: string;
  users?: User[];
  privileges?: Privilege[];
};


