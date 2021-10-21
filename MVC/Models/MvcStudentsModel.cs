using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MvcStudentsModel
    {
        public int StudentID { get; set; }
          [Required(ErrorMessage = "Please enter student name.")]        
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        public Nullable<int> Age { get; set; }
        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }
        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid 10 Digit Mobile Number.")]
        public Nullable<int> Mobile { get; set; }
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Please Enter valid email ID")]
        public string Email { get; set; }
    }
}