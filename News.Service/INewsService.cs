using News.Service.Common;
using News.Service.ViewModels;
using System.Collections.Generic;

namespace News.Service
{
    public interface INewsService
    {
        ReturnResult AddNews(NewsViewModel newsViewMoedl);

        List<NewsViewModel> GetNews();

        NewsViewModel GetNewsById(int id);
    }
}
