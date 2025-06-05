using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Interfaces
{
    public interface ICommnetRepo
    {
        public Task<List<Comment>> GetAllAsync();

        public Task<Comment?> GetByIdAsync(int id);
        public Task<Comment> CreateAsync(Comment commentmodel);

        public Task<Comment?> UpdateAsync(int id, Comment comment);

        public Task<Comment?> DeleteAsync(int id);


    }
}