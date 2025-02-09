using Instagram.Dal.Entity;
using System.Xml.Linq;

namespace Instagram.Repository
{
    public interface ICommentRepository
    {
        Task<long> AddCommentAsync(Comment comment);
        Task<Comment> GetCommentByIdAsync(long Id);
        Task<List<Comment>> GetAllCommentsAsync();
    }
}