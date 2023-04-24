using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Post
    {
        
        public int Id { get; set; }

        // NOTE: The validation fires if the Modelstate is not valid and a http status 400 will
        // be sent to the client - and should be handled by the client - Look the Angular Error handling for details
        // Type varchar50 in the MS SQL DB
        [Required(ErrorMessage = "Title is required")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 10 characters")]
        public string Title { get; set; }

        // Note: Type varchar50 in the MS SQL DB
        [Required(ErrorMessage = "Body is required")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Body must be between 2 and 15 characters")]
        public string Body { get; set; }

       // public string secret { get; set; }
    }
}
