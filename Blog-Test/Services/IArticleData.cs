using Blog_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Test.Services
{
    public interface IArticleData
    {
        IEnumerable<Article> GetArticles();
        Article GetArticle(int id);
        Article PostArticle(Article article);
        Article EdditArticle(Article article);
        Article DeleteArticle(int id);
    }
}
