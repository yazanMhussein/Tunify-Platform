using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

public static class DbSetMockingExtensions
{
    public static Mock<DbSet<T>> ReturnsDbSet<T>(this Mock<TunifyDbContext> context, IQueryable<T> data) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        context.Setup(c => c.Set<T>()).Returns(mockSet.Object);
        return mockSet;
    }
}
