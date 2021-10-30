using System;
using System.ComponentModel.DataAnnotations;


namespace Application.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public DateTime Created { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName}" +
                    $" " +
                    $"{LastName}";
            }
        }
    }
}
