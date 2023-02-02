using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AnimeSiteTests
{
    class DbSetMockBuilder<T> where T : class
    {
        public static Mock<DbSet<T>> Build(List<T> data)
        {
            Mock<DbSet<T>> mock = new Mock<DbSet<T>>();
            var queryData = data.AsQueryable();

            mock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryData.Provider);
            mock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryData.Expression);
            mock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryData.ElementType);
            mock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryData.GetEnumerator());

            return mock;
        }
    }
}
