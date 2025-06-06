using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepo : IStockRepo
    {
        private readonly ApplicationDBContext _context;
        public StockRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Stock>> GetAllSync(QueryObject query)
        {
            var stock = _context.Stock.Include(c => c.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stock = stock.Where(s => s.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stock = stock.Where(s => s.Symbol.Contains(query.Symbol));
            }
            return await stock.ToListAsync();
            
        }

        public async Task<Stock> CreateAsync(Stock stockmodel)
        {
            await _context.Stock.AddAsync(stockmodel);
            await _context.SaveChangesAsync();
            return stockmodel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            var stock = await _context.Stock.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
            if (stock == null)
            {
                return null;
            }
            return stock;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }

            stockModel.Symbol = stockDto.Symbol;
            stockModel.CompanyName = stockDto.CompanyName;
            stockModel.Purchase = stockDto.Purchase;
            stockModel.LastDividend = stockDto.LastDividend;
            stockModel.Industry = stockDto.Industry;
            stockModel.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();

            return stockModel;
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stock.AnyAsync(s=> s.Id==id );
        }
    }
}