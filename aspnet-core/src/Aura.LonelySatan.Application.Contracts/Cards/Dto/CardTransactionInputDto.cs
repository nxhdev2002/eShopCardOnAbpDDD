using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardTransactionInputDto : PagedAndSortedResultRequestDto
    {
        public Guid CardId { get; set; }
    }
}
