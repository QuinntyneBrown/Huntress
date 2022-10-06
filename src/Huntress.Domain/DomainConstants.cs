using Huntress.Domain.Enums;
using System.Collections.Generic;

namespace Huntress.Domain;

public static class DomainConstants
{
    public static class Currency
    {
        public static readonly string CDN = "CAD";
    }
    public static class ClaimTypes
    {
        public static readonly string UserId = nameof(UserId);
        public static readonly string Privilege = nameof(Privilege);
        public static readonly string Username = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        public static readonly string Role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
    }

    public static class AccessRights
    {
        public static List<AccessRight> Read => new() { AccessRight.Read };
        public static List<AccessRight> ReadWrite => new() { AccessRight.Read, AccessRight.Write };
        public static List<AccessRight> FullAccess => new() { AccessRight.Read, AccessRight.Write, AccessRight.Create, AccessRight.Delete };
    }

    public static class Roles
    {
        public static readonly string Customer = nameof(Customer);
        public static readonly string Admin = nameof(Admin);
    }

    public static class Aggregates
    {
        public static readonly string Customer = nameof(Customer);
        public static readonly string DigitalAsset = nameof(DigitalAsset);
        public static readonly string Order = nameof(Order);
        public static readonly string Product = nameof(Product);
        public static readonly string User = nameof(User);
        
        public static List<string> All => new()
        {
            Customer,
            DigitalAsset,
            Order,
            Product,
            User
        };
    }
}
