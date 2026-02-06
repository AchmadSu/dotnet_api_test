using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Models;
using Microsoft.AspNetCore.Components.Web;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static Comment ToCommentFromCreate(this CreateCommentDTO commentDto, int stockId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                CreatedOn = DateTime.UtcNow,
                StockId = stockId
            };
        }

        public static CommentDTO ToCommentDTO(this Comment commentModel)
        {
            return new CommentDTO
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn.Date,
                StockId = commentModel.StockId
            };
        }
    }
}