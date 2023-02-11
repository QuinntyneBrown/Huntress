// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Role } from "./role";

export type User = {
  userId?: string;
  username?: string;
  password?: string;
  roles?: Role[];
};
