using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementation {
    public class PersonBusiness : IPersonBusiness {
        private IPersonRepository _repository;

        public PersonBusiness(IPersonRepository repository) {
            this._repository = repository;
        }

        public PersonBusiness() {
        }

        public Person Create(Person person) {
            return this._repository.Create(person);
        }

        public void Delete(long id) {
            this._repository.Delete(id);
        }

        public List<Person> FindAll() {
            return this.FindAll();
        }

        public Person FindById(long id) {
            return this.FindById(id);
        }

        public Person Update(Person person) {
            return this._repository.Update(person);
        }
    }
}
