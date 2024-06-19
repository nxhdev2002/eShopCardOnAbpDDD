using System;
using System.Collections.Generic;
using System.Text;
using Aura.LonelySatan.Localization;
using Volo.Abp.Application.Services;

namespace Aura.LonelySatan;

/* Inherit your application services from this class.
 */
public abstract class LonelySatanAppService : ApplicationService
{
    protected LonelySatanAppService()
    {
        LocalizationResource = typeof(LonelySatanResource);
    }
}
