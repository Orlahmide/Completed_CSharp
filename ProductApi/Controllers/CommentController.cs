using BusinessLogic.Interfaces;
using DomainLayer.DataTransferObject;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PresentationLayer.Controllers
{
    [Route("api/comments")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // Get all comments for a specific post
        [HttpGet("post/{postId}/all")]
        public ActionResult<IEnumerable<Comment>> GetCommentsByPostId(int postId)
        {
            try
            {
                var comments = _commentService.GetCommentsByPostId(postId);
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get a comment by ID
        [HttpGet("details/{id}")]
        public ActionResult<Comment> GetCommentById(int id)
        {
            try
            {
                var comment = _commentService.GetCommentById(id);
                return Ok(comment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Add a new comment
        [HttpPost("create")]
        public ActionResult AddComment([FromBody] CreateCommentDto comment)
        {
            try
            {
                CommentResponse response = _commentService.AddComment(comment);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update an existing comment
        [HttpPut("edit/{id}")]
        public ActionResult UpdateComment([FromBody] CommentResponse comment)
        {
            try
            {
                _commentService.UpdateComment(comment);
                return Ok("Comment updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a comment
        [HttpDelete("remove/{id}")]
        public ActionResult DeleteComment(int id)
        {
            try
            {
                _commentService.DeleteComment(id);
                return Ok("Comment deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
