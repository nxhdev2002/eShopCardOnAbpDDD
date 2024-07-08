using System;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardGetInputDto
    {
        public Guid Id { get; set; }
    }

    public class CardGetDetailsInputDto
    {
        public Guid Id { get; set; }
        public int OTP { get; set; }
    }
}
