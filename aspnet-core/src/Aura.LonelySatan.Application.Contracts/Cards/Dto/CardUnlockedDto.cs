using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardUnlockedDto
    {
        [Required]
        public Guid CardId { get; set; }
    }
}
