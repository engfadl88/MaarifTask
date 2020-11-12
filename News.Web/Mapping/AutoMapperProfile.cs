using AutoMapper;
using News.Service.ViewModels;

namespace News.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<News.Data.News, NewsViewModel>();
            CreateMap<NewsViewModel, News.Data.News>();
        }
    }
}