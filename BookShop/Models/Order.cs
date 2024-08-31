using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public List<OrderDetail>? orderDetails { get; set; }
        [Required(ErrorMessage = "Va rugam sa va introduceti prenumele")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Va rugam sa va introduceti numele")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Va rugam sa va introduceti adresa")]
        [Display(Name = "Address Line 1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; } = string.Empty;
        [Display(Name = "Address Line 2")]
        [StringLength(100)]
        public string? AddressLine2 { get; set; }
        [Required(ErrorMessage = "Va rugam sa va introduceti codul postal")]
        [Display(Name = "Zip Code")]
        [StringLength(10, MinimumLength = 4)]
        public string zipCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Va rugam sa va introduceti orasul")]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Va rugam sa va introduceti judetul")]
        [StringLength(50)]
        public string? Region { get; set; }
        [Required(ErrorMessage = "Va rugam sa va introduceti tara")]
        [StringLength(50)]

        public string Country { get; set; } = string.Empty;
        [Required(ErrorMessage = "Va rugam sa va introduceti numarul de telefon")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string phoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Va rugam sa va introduceti adresa de email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])", ErrorMessage = "Va rugam sa va introduceti adresa de email in formatul corect")]
        public string Email { get; set; } = string.Empty;
        [BindNever]
        public decimal? OrderTotal { get; set; }
        [BindNever]
        public DateTime OrderPlaced { get; set; }
    }
}
