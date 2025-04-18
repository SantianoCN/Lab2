using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsaregorodtsevLab2.Data.Entities
{
    public class Dish
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long DishTypeId { get; set; }
        public DishType Type { get; set; }
        public double Сalories { get; set; }
    }
}
