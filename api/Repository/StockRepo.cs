using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepo: IStockRepo
    {
        private readonly ApplicationDBContext _context;
        public StockRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<List<Stock>> GetAllSync()
        {
            return _context.Stock.ToListAsync();
        }
    }
}