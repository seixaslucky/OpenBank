﻿using System;
using Microsoft.EntityFrameworkCore;

namespace OpenBank.Infra.Data.Context
{
    public static class DbContextUtils
    {
        public static TDb Create<TDb>(string connStr, Func<DbContextOptions<TDb>, TDb> creator) where TDb : DbContext
        {
            var options = new DbContextOptionsBuilder<TDb>()
                .UseSqlServer(connStr)
                .Options;

            var dbContext = creator(options);
            return dbContext;
        }
    }
}
