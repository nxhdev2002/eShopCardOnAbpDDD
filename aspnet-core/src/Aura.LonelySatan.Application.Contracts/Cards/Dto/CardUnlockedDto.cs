using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardUnlockedDto
    {
        [Required]
        [MinLength(15)]
        [MaxLength(16)]
        public string CardNumber { get; set; }
    }
}
