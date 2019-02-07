using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementation
{
    public class PersonService : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            return new List<Person>();
        }

        public Person FindById(long id)
        {
            return new Person();
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
