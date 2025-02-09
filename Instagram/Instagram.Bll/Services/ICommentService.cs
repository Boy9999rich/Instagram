using Instagram.Bll.Dto;

namespace Instagram.Bll.Services
{
    public interface ICommentService
    {
        Task<long> AddAsync(CommentCreateDto commentCreateDto);
        Task<CommentGetDto> GetByIdAsync(long Id);
        Task<List<CommentGetDto>> GetAllAsync();
    }
}