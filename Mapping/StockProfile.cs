using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Models;
using AutoMapper;

namespace api.Mapping
{
    public class StockProfile : GlobalMappingProfile<UpdateStockRequestDTO, Stock>
    {
    }
}