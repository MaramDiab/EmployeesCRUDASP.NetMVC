using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    public class Employee
    {
        [Required]
        [RegularExpression("^05(9[987542]|6[982])\\d{6}$", ErrorMessage = "Please Enter A valid phone number ")]
       public string PhoneNumber { get; set; }
        //create properties 
        //id
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public DateTime EmployeeBirthDate { get; set; }
        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please Enter A valid Email")]
        public string EmployeeEmail { get; set; }




    }
}
