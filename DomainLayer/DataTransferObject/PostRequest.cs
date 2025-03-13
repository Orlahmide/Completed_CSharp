using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DataTransferObject
{
    public class PostRequest
    {
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int UserId { get; set; }

         
    }
}
