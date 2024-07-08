using System;
using System.ComponentModel.DataAnnotations;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardCreateDto
    {
        [Required]
        [Range(10, double.MaxValue)]
        public decimal Amount { get; set; }
    }
}
