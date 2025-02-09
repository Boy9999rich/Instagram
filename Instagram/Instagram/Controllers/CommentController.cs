using Instagram.Bll.Dto;
using Instagram.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Controllers
{
    [Route("api/COmment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("AddComment")]
        public async Task<long> AddComemntAsync(CommentCreateDto commentCreateDto)
        {
            return await _commentService.AddAsync(commentCreateDto);
        }
        [HttpGet("GetAll")]
        public async Task<List<CommentGetDto>> GetAllAsync()
        {
            return await _commentService.GetAllAsync();
        }
    }
}
