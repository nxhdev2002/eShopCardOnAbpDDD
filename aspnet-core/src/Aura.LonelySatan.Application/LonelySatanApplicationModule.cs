﻿using Aura.LonelySatan.Commons;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Aura.LonelySatan;

[DependsOn(
    typeof(LonelySatanDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(LonelySatanApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class LonelySatanApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpAutoMapperOptions>(options =>
        //{
        //    options.AddMaps<LonelySatanApplicationModule>();
        //});

        MappingConfig.ConfigureMappings();
    }
}
