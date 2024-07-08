using System;
using System.ComponentModel.DataAnnotations;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardUnlockedDto
    {
        [Required]
        public Guid CardId { get; set; }
    }
}
