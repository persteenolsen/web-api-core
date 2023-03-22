using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Options;
using WebApi.Helpers;

using WebApi.Entities;


namespace WebApi.Services
{

    // Declaring an Interface to be called from the PostsController
    public interface IPostService
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        void Delete(int id);
        Post Create(Post post);
        void Update(int id, Post post);
    }

    // The Interface - ready to be accessed by the controller  
    public class PostService : IPostService
    {
                
      
        private DataContext _context;

        public PostService(DataContext context)
        {
            _context = context;
        }

        // POST
        public Post Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();

            return post;
        }

        // PUT
        public void Update(int id, Post postParam)
        {
            var post = _context.Posts.Find(id);

            if (post == null)
                throw new AppException("Post not found");
          
            // update Post properties
            post.Title = postParam.Title;
            post.Body = postParam.Body;
           
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        // GET
        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }

        // GET
        public Post GetById(int id)
        {
            return _context.Posts.Find(id);
        }

        // DELETE
        public void Delete(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }

     
    }


}
