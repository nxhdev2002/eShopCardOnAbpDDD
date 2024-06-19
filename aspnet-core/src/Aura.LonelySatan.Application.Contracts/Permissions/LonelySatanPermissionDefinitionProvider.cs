using Aura.LonelyLucifer.Permissions;
using Aura.LonelySatan.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Aura.LonelySatan.Permissions;

public class LonelySatanPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LonelySatanPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(LonelySatanPermissions.MyPermission1, L("Permission:MyPermission1"));
        var orderGroup = context.AddGroup(OrderingServicePermissions.GroupName);
        var orders = orderGroup.AddPermission(OrderingServicePermissions.Orders.Default, L("Permission:Orders"));

        orders.AddChild(OrderingServicePermissions.Orders.SetAsCancelled, L("Permission:Orders.SetAsCancelled"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LonelySatanResource>(name);
    }
}
