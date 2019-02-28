using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Service
{
    public interface IBookService
    {
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
        Book FindById(long id);
        List<Book> FindAll();
    }
}
