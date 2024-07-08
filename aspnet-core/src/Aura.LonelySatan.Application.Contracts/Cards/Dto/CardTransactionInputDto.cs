using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardTransactionInputDto : PagedAndSortedResultRequestDto
    {
        [Required]
        public Guid CardId { get; set; }
    }
}
