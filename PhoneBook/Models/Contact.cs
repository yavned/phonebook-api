using PhoneBook.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Gender { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
