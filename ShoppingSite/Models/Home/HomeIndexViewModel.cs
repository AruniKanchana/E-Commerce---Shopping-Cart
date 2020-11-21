using ShoppingSite.DAF;
using ShoppingSite.Repositary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ShoppingSite.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public IPagedList<Tbl_Product> ListOfProducts { get; set; }

        dbMyOnlineShoppingEntities context = new dbMyOnlineShoppingEntities();
        public HomeIndexViewModel CreateModel(string search,int pageSize, int? page)
        {
            IPagedList<Tbl_Product> data = context.Tbl_Product.Where(m => m.ProductName.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, pageSize);
            return new HomeIndexViewModel
            {

                ListOfProducts = data

            };
        }
    }
}