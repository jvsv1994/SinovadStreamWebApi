using Microsoft.EntityFrameworkCore;
using SinovadDemo.Transversal.Collection;
using System.Linq.Expressions;
using System.Reflection;

namespace SinovadDemo.Transversal.Paging
{
    public static class PaginExtension
    {
        public static async Task<DataCollection<T>> GetPagedAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize, string sortBy, string sortDirection,string searchText,string searchBy,CancellationToken cancellationToken = default)
        {
            var result = new DataCollection<T>
            {
                Items = await query.SearchBy(searchText,searchBy).OrderBy(sortBy, sortDirection).Skip((pageIndex - 1)* pageSize).Take(pageSize).ToListAsync(cancellationToken),
                Total = await query.CountAsync(cancellationToken),
                Page = pageIndex
            };
            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / pageSize));
            }
            return result;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string sortBy, string sortDirection)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                return source;
            }

            ParameterExpression parameter = Expression.Parameter(source.ElementType, "");

            MemberExpression property = Expression.Property(parameter, sortBy);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = sortDirection == "asc" ? "OrderBy" : "OrderByDescending";

            Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                  new Type[] { source.ElementType, property.Type },
                                  source.Expression, Expression.Quote(lambda));

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }

        public static IQueryable<T> SearchBy<T>(this IQueryable<T> source, string searchText, string searchBy)
        {
            if (string.IsNullOrEmpty(searchText) || string.IsNullOrEmpty(searchBy))
            {
                return source;
            }
            ParameterExpression parameter = Expression.Parameter(source.ElementType, "");
            List<string> listColumns = new List<string>();
            if (!string.IsNullOrEmpty(searchBy))
            {
                listColumns = searchBy.Split("|").ToList();
            }
            foreach (var propertyName in listColumns)
            {
               var propertyExp = Expression.Property(parameter, propertyName);//Column name in the table
               var constantExpression = Expression.Constant(searchText);//Value to compare
               MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
               var someValue = Expression.Constant(searchText, typeof(string));
               var containsMethodExp = Expression.Call(propertyExp, method, someValue);
               Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(containsMethodExp, parameter);
               source= source.Where(lambda);
            }
            return source;
        }

    }
}
