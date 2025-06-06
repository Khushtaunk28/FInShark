using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepo
    {
        Task<List<Stock>> GetAllSync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);

        Task<Stock> CreateAsync(Stock stockmodel);

        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockdt);

        Task<Stock?> DeleteAsync(int id);

        Task<bool> StockExists(int id);
    }
}