using Aura.LonelySatan.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Aura.LonelySatan.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class LonelySatanController : AbpControllerBase
{
    protected LonelySatanController()
    {
        LocalizationResource = typeof(LonelySatanResource);
    }
}
