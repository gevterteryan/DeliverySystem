using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Model
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int CatID { get; set; }
        public string Name { get; set; }
        public string CatName { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public string OpeningDate { get; set; }
        public string ClosedDate { get; set; }    
        public decimal? Rating { get; set; }
    }
}
