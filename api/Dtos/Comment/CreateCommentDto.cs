using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 char long")]
        [MaxLength(200,ErrorMessage ="cant be more than 200 char")]
        public string Title { get; set; } = String.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Content must be 5 char long")]
        [MaxLength(200,ErrorMessage ="cant be more than 200 char")]
        public string Content { get; set; } = String.Empty;
        public int Stockid { get; set; }
    }
}