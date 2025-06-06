using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;

namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Symbol must be 3 char long")]
        [MaxLength(10,ErrorMessage ="cant be more than 10 char")]
        public string Symbol { get; set; } = String.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "Title must be 3char long")]
        [MaxLength(20,ErrorMessage ="cant be more than 20 char")]

        public string CompanyName { get; set; } = String.Empty;

        [Required]
        [Range(1,1000000)]
        public decimal Purchase { get; set; }

        [Range(0,100)]
        public decimal LastDividend { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Industry must be 3 char long")]
        [MaxLength(10,ErrorMessage ="cant be more than 10 char")]
        
        public string Industry { get; set; } = String.Empty;
        [Range(10,1000000000)]
        public long MarketCap { get; set; }
    }
}