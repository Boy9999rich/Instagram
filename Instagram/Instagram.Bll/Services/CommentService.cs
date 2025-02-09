using Instagram.Bll.Dto;
using Instagram.Dal.Entity;
using Instagram.Repository;

namespace Instagram.Bll.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<long> AddAsync(CommentCreateDto commentCreateDto)
    {
        var comment = new Comment()
        {
            Body = commentCreateDto.body,
            PostId = commentCreateDto.PostId,
            AccountId = commentCreateDto.AccountId,
            ParentCommentId = commentCreateDto.ParentCommentId
        };
        comment.CreatedTime = DateTime.UtcNow;
        return await _commentRepository.AddCommentAsync(comment);
    }

    public async Task<List<CommentGetDto>> GetAllAsync()
    {
        var comments = await _commentRepository.GetAllCommentsAsync();
        var commentGetDtos = ConvertToCommentGetDto(comments);
        return commentGetDtos;
    }

    private List<CommentGetDto> ConvertToCommentGetDto(List<Comment> comments)
    {
        var commentGetDtos = new List<CommentGetDto>();

        foreach (Comment comment in comments)
        {
            var commentGetDto = new CommentGetDto()
            {
                CommentId = comment.CommentId,
                body = comment.Body,
                CreatedTime = comment.CreatedTime,
                AccountId = comment.AccountId,
                PostId = comment.PostId,
                ParentCommentId = comment.ParentCommentId
            };
            commentGetDtos.Add(commentGetDto);
            if (comment.Replies == null || comment.Replies.Count == 0) continue;
            commentGetDtos[commentGetDtos.Count() - 1].Replies = ConvertToCommentGetDto(comment.Replies);
        }
        return commentGetDtos;
    }

    public async Task<CommentGetDto> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }
}
