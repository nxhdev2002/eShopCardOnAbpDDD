using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Aura.LonelySatan;

[Dependency(ReplaceServices = true)]
public class LonelySatanBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LonelySatan";
}
