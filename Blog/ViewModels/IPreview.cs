using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public interface IPreview
    {
        IEnumerable<string> PreviewArticleContent(IEnumerable<Article> Articles);
    }
}
