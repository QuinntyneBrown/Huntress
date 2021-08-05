using Huntress.Api.Models;
using System.Collections.Generic;

namespace Huntress.Api
{
    public static class Constants
    {
        public static class Currency
        {
            public static readonly string CDN = "CAD";
        }
        public static class ClaimTypes
        {
            public static readonly string UserId = nameof(UserId);
            public static readonly string Username = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        }

        public static class AccessRights
        {
            public static List<AccessRight> Read => new() { AccessRight.ReadAccess };
            public static List<AccessRight> ReadWrite => new() { AccessRight.ReadAccess, AccessRight.WriteAccess };
            public static List<AccessRight> FullAccess => new() { AccessRight.ReadAccess, AccessRight.WriteAccess, AccessRight.CreateAccess, AccessRight.DeleteAccess };
        }

        public static class Roles
        {
            public static readonly string Customer = nameof(Customer);
            public static readonly string Admin = nameof(Admin);
        }

        public static class Aggregates
        {
            public static readonly string Customer = nameof(Customer);
            public static readonly string Order = nameof(Order);
            public static readonly string Product = nameof(Product);
            public static readonly string User = nameof(User);
            public static List<string> All => new()
            {
                Customer,
                Order,
                Product,
                User
            };
        }
    }
}
