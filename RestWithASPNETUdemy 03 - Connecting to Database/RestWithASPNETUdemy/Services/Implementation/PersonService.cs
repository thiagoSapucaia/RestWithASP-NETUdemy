using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Services.Implementation {
    public class PersonService : IPersonService {
        private MySQLContext _context;

        public PersonService(MySQLContext context) {
            this._context = context;
        }

        public PersonService() {
        }

        public Person Create(Person person) {
            try {
                this._context.Add(person);
                this._context.SaveChanges();
            } catch (Exception ex) {
                throw ex;
            }
            return person;
        }

        public void Delete(long id) {
            try {
                Person personBd = this.FindById(id);
                if (personBd != null) {
                    this._context.Remove(personBd);
                    this._context.SaveChanges();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<Person> FindAll() {
            return this._context.Persons.ToList();
        }

        public Person FindById(long id) {
            return this._context.Persons.SingleOrDefault(x => x.Id == id);
        }

        public Person Update(Person person) {
            try {
                Person personBd = this.FindById((long)person.Id);
                if (personBd == null) {
                    return new Person();
                }
                this._context.Entry(personBd).CurrentValues.SetValues(person);
                this._context.SaveChanges();
            } catch (Exception ex) {
                throw ex;
            }
            return person;
        }
    }
}
