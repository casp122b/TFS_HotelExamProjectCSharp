using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class BookingService : IService<BookingBO>
    {
        BookingConverter bookConv = new BookingConverter();
        DALFacade _facade;

        public BookingService(DALFacade facade)
        {
            _facade = facade;
        }

        public BookingBO Create(BookingBO book)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newBook = uow.BookingRepository.Create(bookConv.Convert(book));
                uow.Complete();
                return bookConv.Convert(newBook);
            }
        }

        public BookingBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var removeBook = uow.BookingRepository.Delete(Id);
                uow.Complete();
                return bookConv.Convert(removeBook);
            }
        }

        public BookingBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var getBook = uow.BookingRepository.Get(Id);
                return bookConv.Convert(getBook);
            }
        }

        public List<BookingBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.BookingRepository.GetAll().Select(bookConv.Convert).ToList();
            }
        }

        public BookingBO Update(BookingBO book)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var updateBook = uow.BookingRepository.Get(book.Id);
                if (updateBook == null)
                {
                    throw new InvalidOperationException("booking not found");
                }
                updateBook.CheckIn = book.CheckIn;
                updateBook.CheckOut = book.CheckOut;
                uow.Complete();
                return bookConv.Convert(updateBook);
            };
        }
    }
}
