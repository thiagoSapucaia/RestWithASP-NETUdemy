using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementation {
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity {
        private readonly MySQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MySQLContext context) {
            this._context = context;
            this._dataset = this._context.Set<T>();
        }

        public GenericRepository() {
        }

        public T Create(T item) {
            try {
                this._dataset.Add(item);
                this._context.SaveChanges();
            } catch (Exception ex) {
                throw ex;
            }
            return item;
        }

        public void Delete(long id) {
            try {
                var Item = this.FindById(id);
                if (Item != null) {
                    this._dataset.Remove(Item);
                    this._context.SaveChanges();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public bool Exists(long? id) {
            return this._dataset.Any(x => x.Id.Equals(id));
        }

        public List<T> FindAll() {
            return this._dataset.ToList();
        }

        public T FindById(long id) {
            return this._dataset.SingleOrDefault(x => x.Id == id);
        }

        public T Update(T item) {
            try {
                if (!this.Exists(item.Id)) {
                    return null;
                }
                this._context.Entry(item).CurrentValues.SetValues(item);
                this._context.SaveChanges();
            } catch (Exception ex) {
                throw ex;
            }
            return item;
        }
    }
}
