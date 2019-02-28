using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Service.Implementation {
    public class PersonService : IPersonService {
        private IPersonRepository _repository;

        public PersonService(IPersonRepository repository) {
            this._repository = repository;
        }

        public PersonService() {
        }

        public Person Create(Person person) {
            return this._repository.Create(person);
        }

        public void Delete(long id) {
            this._repository.Delete(id);
        }

        public List<Person> FindAll() {
            return this._repository.FindAll();
        }

        public Person FindById(long id) {
            return this.FindById(id);
        }

        public Person Update(Person person) {
            return this._repository.Update(person);
        }
    }
}
