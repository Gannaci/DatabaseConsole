using DatabaseConsole.Data;
using DatabaseConsole.Models.Entity;
using DatabaseConsole.Models;
using Microsoft.Data.SqlClient;

namespace DatabaseConsole.Services
{
    public class StatusService
    {
        private static readonly DataContexts _context = new();

        public static async Task SaveStatusAndCommentAsync(StatusEntity statusAndComment)
        {
            var statusAndCommentEntity = new StatusEntity
            {
                Status = statusAndComment.Status,
                Comment = statusAndComment.Comment,
                UpdateTime = DateTime.Today
            };
            _context.Add(statusAndCommentEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<StatusEntity> GetByIdAsync(int id)
        {
            var statusEntity = await _context.Status.FindAsync(id);
            
            if(statusEntity != null)
                return statusEntity;

            else 
                return null!;
        }
    }
}
