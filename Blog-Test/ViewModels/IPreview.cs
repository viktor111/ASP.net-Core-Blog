using Blog_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Test.ViewModels
{
    public interface IPreview
    {
        IEnumerable<string> PreviewArticleContent(IEnumerable<Article> Articles);
    }
}
