using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardCvvDto
    {
        [Required]
        public string Value { get; set; }
    }
}
