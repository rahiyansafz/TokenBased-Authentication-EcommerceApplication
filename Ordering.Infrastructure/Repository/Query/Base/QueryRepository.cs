﻿using Microsoft.Extensions.Configuration;
using Ordering.Core.Repositories.Query.Base;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure.Repository.Query.Base;

public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : class
{
    public QueryRepository(IConfiguration configuration)
        : base(configuration)
    {

    }
}
