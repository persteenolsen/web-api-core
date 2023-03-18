using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;

namespace WebApi.Controllers
{
    // [Authorize]
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

        // Returning the List of Posts from the PostService - The Angular Client is sending a http get request 
        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _postService.GetAll();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _postService.GetById(id);
            return Ok(post);
        }
    }
}