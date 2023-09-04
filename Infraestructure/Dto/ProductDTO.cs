using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Dto
{
    [Table("product")]
    public class ProductDto
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("category")]
        public string Category { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("stock")]
        public int Stock { get; set; }
    }
}
