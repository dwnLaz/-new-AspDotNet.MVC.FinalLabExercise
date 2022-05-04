using System;
using System.Linq;
using EmployeeData.Data;
using EmployeeWeb.Models;
using EmployeeData.Repositories;

namespace EmployeeWeb.Services
{
    public abstract class GenericService
    {
        public EmployeeDbContext Context { get; set; }
        public GenericService(EmployeeDbContext context)
        {
            this.Context = context;
        }
        public PagedResult<T> GetPaged<T>(IQueryable<T> query,
                                 int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = page == 0 ? 0 : (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}
