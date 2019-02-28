using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Service.Implementation {
    public class BookService : IBookService {
        private IRepository<Book> _repository;

        public BookService(IRepository<Book> repository) {
            this._repository = repository;
        }

        public BookService() {
        }

        public Book Create(Book Book) {
            return this._repository.Create(Book);
        }

        public void Delete(long id) {
            this._repository.Delete(id);
        }

        public List<Book> FindAll() {
            return this._repository.FindAll();
        }

        public Book FindById(long id) {
            return this.FindById(id);
        }

        public Book Update(Book Book) {
            return this._repository.Update(Book);
        }
    }
}
