using System;
using System.ComponentModel.DataAnnotations;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardGetInputDto
    {
        public Guid Id { get; set; }
    }

    public class CardGetDetailsInputDto
    {
        public Guid Id { get; set; }
        [Required]
        public string OTP { get; set; }
    }
}
