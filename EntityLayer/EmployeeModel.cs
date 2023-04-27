using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer
{
    public class EmployeeModel
    {
        [Required]    
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="First Name is required")]
        [RegularExpression("[a-zA-Z]{1,20}", ErrorMessage = "name should contain alphabets only")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression("[a-zA-Z]{1,20}", ErrorMessage = "name should contain alphabets only")]
        public string Last_Name { get; set; }

        [Required]
        public int? Salary { get; set; }

        [Required]
        public string State { get; set; }

        [Required(ErrorMessage = "City Name is required")]
        [RegularExpression("[a-zA-Z]{1,20}", ErrorMessage = "city name should contain alphabets only")]
        public string City { get; set; }

        [Required(ErrorMessage = "please enter valid pincode")]
        [Range(10000, 1000000, ErrorMessage = "pincode should contain 6 digits")]
        public int? Pincode { get; set; }

        [Required(ErrorMessage = "please enter mobile number")]
        [Range(100000000, 999999999, ErrorMessage = "enter valid mobile number")]
        [Phone]
        public int Mobile_Number { get; set; }
       

        [Required(ErrorMessage ="Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }


        [Required(ErrorMessage = "Please enter valid email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression("[a-zA-Z0-9._%+-]+@[A-Za-z0-9.-]+\\.[a-zA-Z]{2,4}", ErrorMessage = "please enter email in the format ex-abc123@gmail.com")]
        public string Email { get; set; }

        public string StateName { get; set; }

        [Required(ErrorMessage ="RoleId is required")]
        [Range(1,2,ErrorMessage ="Role Id must be 1 or 2")]
        public int? RoleId { get; set; }


    }
}
