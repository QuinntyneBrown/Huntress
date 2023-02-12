// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Dashboard } from "../dashboard";

export type User = {
  userId?: string;
  username?: string;
  dashboards?: Dashboard[];
};


