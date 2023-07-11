using Microsoft.EntityFrameworkCore;
using SinovadDemo.Transversal.Collection;
using System.Linq.Expressions;

namespace SinovadDemo.Transversal.Paging
{
    public static class PaginExtension
    {
        public static async Task<DataCollection<T>> GetPagedAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize, string orderColumnName = null, bool isAscending = false, CancellationToken cancellationToken = default)
        {
            var result = new DataCollection<T>
            {
                Items = await query.OrderBy(orderColumnName, isAscending).Skip((pageIndex - 1)* pageSize).Take(pageSize).ToListAsync(cancellationToken),
                Total = await query.CountAsync(cancellationToken),
                Page = pageIndex
            };
            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / pageSize));
            }
            return result;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string columnName, bool isAscending = true)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                return source;
            }

            ParameterExpression parameter = Expression.Parameter(source.ElementType, "");

            MemberExpression property = Expression.Property(parameter, columnName);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = isAscending ? "OrderBy" : "OrderByDescending";

            Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                  new Type[] { source.ElementType, property.Type },
                                  source.Expression, Expression.Quote(lambda));

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }

    }
}
