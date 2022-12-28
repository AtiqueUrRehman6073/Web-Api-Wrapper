using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntities.DBModels
{
    public class Employee_Model
    {
        public string? Patient_Account { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Email_Address { get; set; }
        public string? Date_Of_Birth { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
