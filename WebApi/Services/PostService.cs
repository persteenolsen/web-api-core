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
    }

    // The Interface - ready to be accessed by the controller  
    public class PostService : IPostService
    {
                
        // Posts hardcoded for simplicity, store in a db with hashed passwords in production applications
       /* private List<Post> _posts = new List<Post>
        {
            
             new Post { Id = 1, Title = "This is Title 1", Body = "This is body 1"  },
             new Post { Id = 1, Title = "This is Title 2", Body = "This is body 2"  }
        }; */


        private DataContext _context;

        public PostService(DataContext context)
        {
            _context = context;
        }

        public Post Create(Post post)
        {
           // validation of the title
           // if (string.IsNullOrWhiteSpace(title))
           //    throw new AppException("Title is required");

           
            _context.Posts.Add(post);
            _context.SaveChanges();

            return post;
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }


        public Post GetById(int id)
        {
            return _context.Posts.Find(id);
        }

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
