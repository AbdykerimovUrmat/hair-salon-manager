using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces;
using HairSalon.Data;
using HairSalon.Data.Extensions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services
{
    public class EntityService<TEntity, TKey> : ContextHasService
        where TEntity : class, IIdHas<TKey>
        where TKey : IEquatable<TKey>
    {
        protected DbSet<TEntity> Entities { get; set; }

        public EntityService(AppDbContext context) 
            : base(context) { }

        public virtual async Task<TEntity> Add<T>(T model)
        {
            var entity = model.Adapt<TEntity>();
            await BeforeAdd(entity);
            await Check(entity);
            await Context.Set<TEntity>().AddAsync(entity);
            await SaveChanges();

            return entity;
        }

        protected virtual Task BeforeAdd(TEntity entity)
        {
            return Task.CompletedTask;
        }

        protected virtual Task Check(TEntity entity)
        {
            return Task.CompletedTask;
        }

        public virtual async Task<IEnumerable<T>> List<T>()
        {
            return await List<T>(Context.Set<TEntity>());
        }

        public async Task<IEnumerable<T>> List<T>(IQueryable<TEntity> query)
        {
            return await query
                .AsNoTracking()
                .ProjectToType<T>()
                .ToListAsync();
        }

        public virtual async Task<T> ById<T>(TKey id) where T : class, IIdHas<TKey>
        {
            return await Context.Set<TEntity>()
                .AsNoTracking()
                .ProjectToType<T>()
                .ById(id);
        }

        public virtual async Task Edit<T>(T model) where T : IIdHas<TKey>
        {
            var entity = await Context.Set<TEntity>().ById(model.Id);
            model.Adapt(entity);
            await Check(entity);

            await SaveChanges();
        }

        public virtual async Task Delete(TKey id)
        {
            Context.Set<TEntity>().Remove(await Context.Set<TEntity>().ById(id));
            await SaveChanges();
        }
    }
}
