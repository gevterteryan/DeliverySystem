using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Model
{
    public class RestaurantMenu
    {
        public int Id { get; set; }
        public int RestID { get; set; }    
        public int CatID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        /*public Image Product { get; set; }*/
    }
}
