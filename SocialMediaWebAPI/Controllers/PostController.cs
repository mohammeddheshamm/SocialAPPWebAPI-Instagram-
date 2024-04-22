using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social.Core.Entity;
using Social.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaWebAPI.Controllers
{
    
    public class PostController : BaseApiController
    {
        private readonly IGenericRepository<Post> _postRepo;
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost] //POST : api/Post
        public async Task<ActionResult<Post>> AddNewPost(Post post)
        {
            if (post == null)
                return BadRequest();
            await _unitOfWork.Repository<Post>().AddAsync(post);
            return Ok();
        }

        [HttpGet] // GET : api/Post
        public async Task<ActionResult<IReadOnlyList<Post>>> GetAllPosts()
        {
            var posts = await _unitOfWork.Repository<Post>().GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("id")] // Get : api/Post/id
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await _unitOfWork.Repository<Post>().GetByIdAsync(id);
            if(post == null)
                return BadRequest();
            return Ok(post);  
        }

    }
}
