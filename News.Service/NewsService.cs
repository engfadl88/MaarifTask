using AutoMapper;
using News.Data;
using News.Service.Common;
using News.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace News.Service
{
    public class NewsService : INewsService
    {
        protected readonly MaarifDBEntities _context;

        public NewsService()
        {
            _context = new MaarifDBEntities();
        }
        
        public ReturnResult AddNews(NewsViewModel newsViewMoedl)
        {
            ReturnResult returnResult = new ReturnResult();

            if (newsViewMoedl != null)
            {
                newsViewMoedl.CreatedOn = DateTime.Now;
                newsViewMoedl.CreatedBy = "Ahmed"; // should be the logged user

                var news = Mapper.Map<NewsViewModel, News.Data.News>(newsViewMoedl);

                _context.News.Add(news);

                //if (userVM.Roles != null || userVM.Roles.Count > 0)
                //{
                //    foreach (var role in userVM.Roles)
                //    {
                //        if (role.Selected)
                //        {
                //            var userRole = new UserRole
                //            {
                //                UserId = user.Id,
                //                RoleId = role.Id
                //            };
                //            _context.UserRoles.Add(userRole);
                //        }
                //    }
                //}

                _context.SaveChanges();
            }

            return returnResult;
        }

        public List<NewsViewModel> GetNews()
        {
            DateTime baseDate = DateTime.Today;

            var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);

            var thisMonthStart = baseDate.AddDays(1 - baseDate.Day);
            var thisMonthEnd = thisMonthStart.AddMonths(1).AddSeconds(-1);
           
            var newsLst = _context.News.OrderByDescending(n => n.CreatedOn).ToList();

            var newsViewModelLst = Mapper.Map<List<News.Data.News>, List<NewsViewModel>>(newsLst);

            if (newsLst != null && newsLst.Count > 0)
            {
                foreach (var item in newsViewModelLst)
                {
                    if (item.CreatedOn >= thisWeekStart && item.CreatedOn < thisWeekEnd)
                        item.currentPeriod = "week";
                    else if(item.CreatedOn >= thisMonthStart && item.CreatedOn < thisMonthEnd)
                        item.currentPeriod = "month";                     
                    else
                        item.currentPeriod = "all";
                }
            }
            return newsViewModelLst;
        }

        public NewsViewModel GetNewsById(int id)
        {
            var newsObj = _context.News.FirstOrDefault(r => r.Id == id);
            
            var newsViewModel = Mapper.Map<News.Data.News, NewsViewModel>(newsObj);
                            
            return newsViewModel;
        }

    }
}
