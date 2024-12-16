using System.ComponentModel.DataAnnotations;

namespace PhoneContactF.Models
{
    public class ContactDto
    {

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Surname { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }
    }
}
