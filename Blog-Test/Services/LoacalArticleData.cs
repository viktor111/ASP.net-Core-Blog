﻿using Blog_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Test.Services
{
    //public class LoacalArticleData : IArticleData
    //{
    //    public LoacalArticleData()
    //    {
    //        _articles = new List<Article>
    //        {
    //            new Article{Id = 1, Title = "blog post" , Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Vulputate dignissim suspendisse in est ante in nibh mauris. Mauris pellentesque pulvinar pellentesque habitant. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. Pharetra magna ac placerat vestibulum. Sit amet facilisis magna etiam tempor orci eu lobortis elementum. Ac placerat vestibulum lectus mauris ultrices eros in cursus turpis. Lorem sed risus ultricies tristique. Amet volutpat consequat mauris nunc congue. Donec ac odio tempor orci dapibus ultrices in. Dictumst quisque sagittis purus sit amet. Cursus turpis massa tincidunt dui ut ornare lectus sit amet. Erat pellentesque adipiscing commodo elit at imperdiet dui accumsan. Duis at tellus at urna condimentum mattis pellentesque. Magna ac placerat vestibulum lectus mauris ultrices eros in. Nulla malesuada pellentesque elit eget gravida cum. Nisl nunc mi ipsum faucibus vitae aliquet nec ullamcorper sit. Ultricies mi eget mauris pharetra et ultrices. Eleifend mi in nulla posuere. Suspendisse potenti nullam ac tortor vitae purus faucibus.", Author = "Viktor", Category = CategoryType.general},
    //            new Article{Id = 2, Title = "blog post two" , Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Vulputate dignissim suspendisse in est ante in nibh mauris. Mauris pellentesque pulvinar pellentesque habitant. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. Pharetra magna ac placerat vestibulum. Sit amet facilisis magna etiam tempor orci eu lobortis elementum. Ac placerat vestibulum lectus mauris ultrices eros in cursus turpis. Lorem sed risus ultricies tristique. Amet volutpat consequat mauris nunc congue. Donec ac odio tempor orci dapibus ultrices in. Dictumst quisque sagittis purus sit amet. Cursus turpis massa tincidunt dui ut ornare lectus sit amet. Erat pellentesque adipiscing commodo elit at imperdiet dui accumsan. Duis at tellus at urna condimentum mattis pellentesque. Magna ac placerat vestibulum lectus mauris ultrices eros in. Nulla malesuada pellentesque elit eget gravida cum. Nisl nunc mi ipsum faucibus vitae aliquet nec ullamcorper sit. Ultricies mi eget mauris pharetra et ultrices. Eleifend mi in nulla posuere. Suspendisse potenti nullam ac tortor vitae purus faucibus.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Vulputate dignissim suspendisse in est ante in nibh mauris. Mauris pellentesque pulvinar pellentesque habitant. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. Pharetra magna ac placerat vestibulum. Sit amet facilisis magna etiam tempor orci eu lobortis elementum. Ac placerat vestibulum lectus mauris ultrices eros in cursus turpis. Lorem sed risus ultricies tristique. Amet volutpat consequat mauris nunc congue. Donec ac odio tempor orci dapibus ultrices in. Dictumst quisque sagittis purus sit amet. Cursus turpis massa tincidunt dui ut ornare lectus sit amet. Erat pellentesque adipiscing commodo elit at imperdiet dui accumsan. Duis at tellus at urna condimentum mattis pellentesque. Magna ac placerat vestibulum lectus mauris ultrices eros in. Nulla malesuada pellentesque elit eget gravida cum. Nisl nunc mi ipsum faucibus vitae aliquet nec ullamcorper sit. Ultricies mi eget mauris pharetra et ultrices. Eleifend mi in nulla posuere. Suspendisse potenti nullam ac tortor vitae purus faucibus.", Author = "Viktor", Category = CategoryType.AI},
    //            new Article{Id = 3, Title = "blog post three" , Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Vulputate dignissim suspendisse in est ante in nibh mauris. Mauris pellentesque pulvinar pellentesque habitant. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. Pharetra magna ac placerat vestibulum. Sit amet facilisis magna etiam tempor orci eu lobortis elementum. Ac placerat vestibulum lectus mauris ultrices eros in cursus turpis. Lorem sed risus ultricies tristique. Amet volutpat consequat mauris nunc congue. Donec ac odio tempor orci dapibus ultrices in. Dictumst quisque sagittis purus sit amet. Cursus turpis massa tincidunt dui ut ornare lectus sit amet. Erat pellentesque adipiscing commodo elit at imperdiet dui accumsan. Duis at tellus at urna condimentum mattis pellentesque. Magna ac placerat vestibulum lectus mauris ultrices eros in. Nulla malesuada pellentesque elit eget gravida cum. Nisl nunc mi ipsum faucibus vitae aliquet nec ullamcorper sit. Ultricies mi eget mauris pharetra et ultrices. Eleifend mi in nulla posuere. Suspendisse potenti nullam ac tortor vitae purus faucibus.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Vulputate dignissim suspendisse in est ante in nibh mauris. Mauris pellentesque pulvinar pellentesque habitant. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. Pharetra magna ac placerat vestibulum. Sit amet facilisis magna etiam tempor orci eu lobortis elementum. Ac placerat vestibulum lectus mauris ultrices eros in cursus turpis. Lorem sed risus ultricies tristique. Amet volutpat consequat mauris nunc congue. Donec ac odio tempor orci dapibus ultrices in. Dictumst quisque sagittis purus sit amet. Cursus turpis massa tincidunt dui ut ornare lectus sit amet. Erat pellentesque adipiscing commodo elit at imperdiet dui accumsan. Duis at tellus at urna condimentum mattis pellentesque. Magna ac placerat vestibulum lectus mauris ultrices eros in. Nulla malesuada pellentesque elit eget gravida cum. Nisl nunc mi ipsum faucibus vitae aliquet nec ullamcorper sit. Ultricies mi eget mauris pharetra et ultrices. Eleifend mi in nulla posuere. Suspendisse potenti nullam ac tortor vitae purus faucibus.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Vulputate dignissim suspendisse in est ante in nibh mauris. Mauris pellentesque pulvinar pellentesque habitant. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. Pharetra magna ac placerat vestibulum. Sit amet facilisis magna etiam tempor orci eu lobortis elementum. Ac placerat vestibulum lectus mauris ultrices eros in cursus turpis. Lorem sed risus ultricies tristique. Amet volutpat consequat mauris nunc congue. Donec ac odio tempor orci dapibus ultrices in. Dictumst quisque sagittis purus sit amet. Cursus turpis massa tincidunt dui ut ornare lectus sit amet. Erat pellentesque adipiscing commodo elit at imperdiet dui accumsan. Duis at tellus at urna condimentum mattis pellentesque. Magna ac placerat vestibulum lectus mauris ultrices eros in. Nulla malesuada pellentesque elit eget gravida cum. Nisl nunc mi ipsum faucibus vitae aliquet nec ullamcorper sit. Ultricies mi eget mauris pharetra et ultrices. Eleifend mi in nulla posuere. Suspendisse potenti nullam ac tortor vitae purus faucibus.", Author = "Viktor", Category = CategoryType.tips}
    //        };
    //    }

    //    public IEnumerable<Article> GetArticles()
    //    {
    //        return _articles.OrderBy(ct => ct.Category);
    //    }

    //    public Article GetArticle(int id)
    //    {
    //        return _articles.FirstOrDefault(a => a.Id == id);
    //    }

    //    public Article PostArticle(Article article)
    //    {
    //        article.Id = _articles.Max(r => r.Id) + 1;
    //        _articles.Add(article);
    //        return article;
    //    }

    //    List<Article> _articles;
    //}
}
