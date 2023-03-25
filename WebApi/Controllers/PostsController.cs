using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PostsController : Controller // Could be ControllerBase while Index() is not in use
    {
        // Not in use by now
        public IActionResult Index()
        {
            return View();
        } 

        // For using the methods of the PostService by the interface IPostService
        private IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

       
        [HttpPost("")]
        public IActionResult Create([FromBody]Post post)
        {
            try
            {
                // save 
                _postService.Create(post);
                return Ok(post);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Post post)
        {
            try
            {
                // save 
                _postService.Update(id, post);

                // Make sure to return the id submitted - to avoid returning a "strange" null / 0 - displayed at client
                // Ready for updating more than once without leaving the form
                post.Id = id;

                return Ok(post);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // Returning the List of Posts from the PostService - The Angular Client is sending a http get request
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _postService.GetAll();
            return Ok(posts);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _postService.GetById(id);
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postService.Delete(id);
            return Ok();
        }
    }
}