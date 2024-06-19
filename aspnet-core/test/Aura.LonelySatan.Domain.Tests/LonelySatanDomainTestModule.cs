using Volo.Abp.Modularity;

namespace Aura.LonelySatan;

[DependsOn(
    typeof(LonelySatanDomainModule),
    typeof(LonelySatanTestBaseModule)
)]
public class LonelySatanDomainTestModule : AbpModule
{

}
