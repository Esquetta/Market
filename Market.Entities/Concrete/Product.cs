using Market.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Concrete
{
    public class Product : IEntity
    {
        
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        [Required]
        public string QuantityPerUnit { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public short UnitInStock { get; set; }
        
    }
}
