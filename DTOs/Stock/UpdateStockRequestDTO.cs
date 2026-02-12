using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Validations;

namespace api.DTOs.Stock
{
    public class UpdateStockRequestDTO
    {
        [MaxLength(10, ErrorMessage = "Symbol can not be more than 10 characters")]
        public string? Symbol { get; set; }

        [MaxLength(20, ErrorMessage = "Company Name can not be more than 20 characters")]
        public string? CompanyName { get; set; }

        [Range(typeof(decimal), "1", "1000000000")]
        public decimal? Purchase { get; set; }

        [Range(typeof(decimal), "1", "100")]
        public decimal? LastDiv { get; set; }

        [MaxLength(20, ErrorMessage = "Industry can not be more than 20 characters")]
        public string? Industry { get; set; }

        [MarketCapRange]
        public long? MarketCap { get; set; }
    }
}