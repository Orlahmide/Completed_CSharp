using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DataTransferObject
{
    public class UpdatePostDto
    {
        public required int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

    }
}
