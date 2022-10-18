using Microsoft.Ajax.Utilities;
using Onlineshopping.Dal;
using Onlineshopping.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Onlineshopping.Models.Home
{
    public class HomeIndex
    {
        public GenericUnitOfWork unitOfWork = new GenericUnitOfWork();
        MyonlineshopEntities context = new MyonlineshopEntities();
        public IPagedList<product> ListOfproducts { get; set; }
        public HomeIndex CreateModel(string search,int pageSize,int? page)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IPagedList<product> data = context.Database.SqlQuery<product>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, pageSize);
            return new HomeIndex
            {
                ListOfproducts = data
            };
        }
    }
}