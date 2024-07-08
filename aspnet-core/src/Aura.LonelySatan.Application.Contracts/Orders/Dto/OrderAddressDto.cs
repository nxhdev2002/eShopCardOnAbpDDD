﻿using System.ComponentModel.DataAnnotations;

namespace Aura.LonelySatan.Satan.Dto
{
    public class OrderAddressDto
    {
        public string Description { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}
