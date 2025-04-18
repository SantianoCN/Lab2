using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsaregorodtsevLab2.Data.Entities
{
    public class MenuPosition
    {
        public long Id { get; set; }
        public long DishId { get; set; }
        public Dish Dish { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate {  get; set; }
    }
}
