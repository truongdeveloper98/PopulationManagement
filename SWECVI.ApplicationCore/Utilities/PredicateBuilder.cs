using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace SWECVI.ApplicationCore.Utilities
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> AndAlso<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
       
        public static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            if (!string.IsNullOrEmpty(property))
            {
                methodName = methodName == "DESC" ? "OrderByDescending" : "OrderBy";

                string[] props = property.Split('.');
                Type type = typeof(T);
                ParameterExpression arg = Expression.Parameter(type, "x");
                Expression expr = arg;
                foreach (string prop in props)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    PropertyInfo pi = type.GetProperty(prop);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                    if (pi == null)
                    {
                        var properties = type.GetProperties().FirstOrDefault(x => x.Name.ToLower() == prop.ToLower());

                        if(properties != null)
                        {
                            pi = properties;
                        }
                    }

#pragma warning disable CS8604 // Possible null reference argument.
                    expr = Expression.Property(expr, pi);
#pragma warning restore CS8604 // Possible null reference argument.

                    type = pi.PropertyType;
                }

                Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);

                LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                object result = typeof(Queryable).GetMethods().Single(
                    predicate: method => method.Name == methodName
                    && method.IsGenericMethodDefinition
                    && method.GetGenericArguments().Length == 2
                    && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (result != null)
                {
                    return (IOrderedQueryable<T>)result;
                }
            }

            return (IOrderedQueryable<T>)source;
        }
    }
}
