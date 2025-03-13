using BusinessLogic.Services;
using DomainLayer.DataTransferObject;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/posts")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // Get all posts
        [HttpGet("all")]
        public ActionResult<IEnumerable<Post>> GetAllPosts()
        {
            return Ok(_postService.GetAllPosts());
        }

        // Get post by ID
        [HttpGet("post/{id}")]
        public ActionResult<Post> GetPostById(int id)
        {
            try
            {
                var post = _postService.GetPostById(id);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Add a new post
        [HttpPost("create")]
        public ActionResult AddPost([FromBody] PostRequest postRequest)
        {
            try
            {
                var response = _postService.AddPost(postRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update an existing post
        [HttpPut("update")]
        public ActionResult UpdatePost([FromBody] UpdatePostDto updatePostDto)
        {
            try
            {
                var response = _postService.UpdatePost(updatePostDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a post
        [HttpDelete("remove/{id}")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _postService.DeletePost(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
