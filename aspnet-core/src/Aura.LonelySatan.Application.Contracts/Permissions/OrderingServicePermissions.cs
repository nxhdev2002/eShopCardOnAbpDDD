using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Reflection;

namespace Aura.LonelyLucifer.Permissions
{
    public static class OrderingServicePermissions
    {
        public const string GroupName = "OrderingService";
        public static class Orders
        {
            public const string Default = GroupName + ".Orders";
            public const string SetAsCancelled = GroupName + ".SetAsCancelled";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(OrderingServicePermissions));
        }
    }
}
