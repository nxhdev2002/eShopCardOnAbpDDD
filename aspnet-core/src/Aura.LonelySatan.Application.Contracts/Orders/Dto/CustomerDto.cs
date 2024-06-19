using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Aura.LonelySatan.Satan.Dto
{
    public class CustomerDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
