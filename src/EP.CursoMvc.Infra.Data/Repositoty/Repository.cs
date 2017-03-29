using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Model;
using EP.CursoMvc.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EP.CursoMvc.Infra.Data.Repositoty
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected CursoMvcContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository()
        {
            //Teste
            Db = new CursoMvcContext();

            DbSet = Db.Set<TEntity>();


        }

        public virtual TEntity Adicionar(TEntity obj)
        {

            var objRet = DbSet.Add(obj);
            SaveChanges();

            return objRet;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {

            var entry = Db.Entry(obj);
            DbSet.Attach(obj);

            entry.State = EntityState.Modified;
            SaveChanges();
            return obj;
    
        }

        public  IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {

            return DbSet.Where(predicate);
        }


        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {

            return DbSet.ToList(); 
        }

        public virtual void Remover(Guid id)
        {

            DbSet.Remove(ObterPorId(id));
            SaveChanges();
        }

        public virtual int SaveChanges()
        {

            return Db.SaveChanges();
        }


        public void Dispose()
        {

            Db.Dispose();
        }

        public virtual IEnumerable<TEntity> ObterTodosPaginado(int s, int t)
        {

            return DbSet.Skip(s).Take(t).ToList();
        }
    }
}
