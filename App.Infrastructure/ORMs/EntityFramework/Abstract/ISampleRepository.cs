using App.Core.Infrastructure.Abstract;
using App.Domain.Entities;

namespace App.Infrastructure.ORMs.EntityFramework.Abstract;
public interface ISampleRepository : IGenericRepository<SampleEntity> { }

