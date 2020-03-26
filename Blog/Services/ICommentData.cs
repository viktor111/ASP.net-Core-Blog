using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface ICommentData
    {
        IEnumerable<Comment> GetComments(int id);
        Comment DeleteComment(int id);
        Comment PostComment(Comment comment);
    }
}
