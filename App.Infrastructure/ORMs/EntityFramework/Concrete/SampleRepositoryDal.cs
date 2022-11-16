using App.Core.Infrastructure.EntityFramework;
using App.Domain.Entities;
using App.Infrastructure.Contexts;
using App.Infrastructure.ORMs.EntityFramework.Abstract;

namespace App.Infrastructure.ORMs.EntityFramework.Concrete;

public class SampleRepositoryDal : Repository<SampleEntity, DatabaseContext>, ISampleRepository { }
