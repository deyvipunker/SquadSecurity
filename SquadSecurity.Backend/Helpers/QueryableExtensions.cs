﻿using SquadSecurity.Shared.DTOs;

namespace SquadSecurity.Backend.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.RecorsNumber)
                .Take(pagination.RecorsNumber);
        }
    }
}
