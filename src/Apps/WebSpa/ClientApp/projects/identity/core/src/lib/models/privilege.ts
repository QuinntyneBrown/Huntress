// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { AccessRight } from "./access-right";

export type Privilege = {
  privilegeId?: string;
  roleId?: string;
  accessRight?: AccessRight;
  aggregate?: string;
};


