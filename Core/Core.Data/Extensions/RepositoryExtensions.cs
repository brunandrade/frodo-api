using Microsoft.EntityFrameworkCore;

namespace Core.Data.Extensions;

public static class RepositoryExtensions
{
    public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, IEnumerable<string>? includes) where T : class
    {
        if (includes is null || !includes.Any())
        {
            return query;
        }

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }
}
