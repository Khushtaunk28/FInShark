using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;

namespace api.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }

        public string Symbol { get; set; } = String.Empty;

        public string CompanyName { get; set; } = String.Empty;

        public decimal Purchase { get; set; }

        public decimal LastDividend { get; set; }

        public string Industry { get; set; } = String.Empty;

        public long MarketCap { get; set; }

        public List<CommentDto> Comments { get; set; }

        


    }
}