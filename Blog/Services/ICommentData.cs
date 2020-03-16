using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface ICommentData
    {
        public IEnumerable<Comment> GetComments();

        public Comment PostComment(Comment comment);
    }
}
