using Aura.LonelySatan.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Aura.LonelySatan.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LonelySatanEntityFrameworkCoreModule),
    typeof(LonelySatanApplicationContractsModule)
    )]
public class LonelySatanDbMigratorModule : AbpModule
{
}
