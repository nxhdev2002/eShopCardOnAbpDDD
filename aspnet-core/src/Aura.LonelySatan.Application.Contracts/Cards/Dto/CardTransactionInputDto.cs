using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardTransactionInputDto : PagedAndSortedResultRequestDto
    {
        [Required]
        public Guid CardId { get; set; }
    }
}
