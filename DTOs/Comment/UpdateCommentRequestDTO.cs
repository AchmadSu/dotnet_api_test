using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Comment
{
    public class UpdateCommentRequestDTO
    {
        [MinLength(5, ErrorMessage = "Title must be at least contains 5 characters")]
        [MaxLength(160, ErrorMessage = "Title must be less equal than 160 characters")]
        public string? Title { get; set; }
        [MinLength(20, ErrorMessage = "Content must be at least contains 20 characters")]
        [MaxLength(250, ErrorMessage = "Content must be less equal than 250 characters")]
        public string? Content { get; set; }
    }
}