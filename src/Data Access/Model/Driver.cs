using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data_Access.EnumeratedProperties.DriverTypeEnum;

namespace Data_Access.Model
{
    public class Driver
    {
        public int Id { get; set; }
        public DriverType Type { get; set; }
        public int AssinedOrderCount { get; set; }
        public string LastOrderAddress { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Age { get; set; }
        public  bool IsActive { get;set; }
    }
}
