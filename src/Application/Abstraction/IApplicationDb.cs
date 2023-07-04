using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstraction;

public interface IApplicationDb
{
   DbSet<Teacher> Teachers { get; }
   DbSet<Student> Students { get; }
   DbSet<Title> Titles { get; }
   /// <summary>
   /// Save changes to the database
   /// </summary>
   /// <param name="cancellationToken"></param>
   /// <returns></returns>
   Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}