using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepo : ICommnetRepo
    {
        private readonly ApplicationDBContext _context;
        public CommentRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comment.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment> CreateAsync(Comment commentmodel)
        {
            await _context.Comment.AddAsync(commentmodel);
            await _context.SaveChangesAsync();
            return commentmodel;

        }

        public async Task<Comment?> UpdateAsync(int id, Comment comment)
        {
            var existcomment = await _context.Comment.FindAsync(id);
            if (existcomment == null)
            {
                return null;
            }
            existcomment.Title = comment.Title;
            existcomment.Content = comment.Content;
            await _context.SaveChangesAsync();
            return existcomment;

        }

        

         
    }
}