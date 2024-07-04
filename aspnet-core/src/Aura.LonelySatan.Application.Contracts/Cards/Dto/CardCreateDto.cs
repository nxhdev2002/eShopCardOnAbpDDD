using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardCreateDto
    {
        [Required]
        [Range(10, double.MaxValue)]
        public decimal Amount { get; set; }
    }
}
