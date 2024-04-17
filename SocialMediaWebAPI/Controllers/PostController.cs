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

        public PostController(IGenericRepository<Post> postRepo)
        {
            _postRepo = postRepo;
        }

        [HttpPost] //POST : api/Post
        public async Task<ActionResult<Post>> AddNewPost(Post post)
        {
            if (post == null)
                return BadRequest();
            await _postRepo.AddAsync(post);
            return Ok();
        }

        [HttpGet] // GET : api/Post
        public async Task<ActionResult<IReadOnlyList<Post>>> GetAllPosts()
        {
            var posts = await _postRepo.GetAll();
            return Ok(posts);
        }

        [HttpGet("id")] // Get : api/Post/id
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await _postRepo.GetById(id);
            if(post == null)
                return BadRequest();
            return Ok(post);  
        }

    }
}
