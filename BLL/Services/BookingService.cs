using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class BookingService: IService<BookingBO>
    {
        BookingConverter bookConv = new BookingConverter();
        DALFacade facade;

        public BookingService(DALFacade facade)
        {
            this.facade = facade;
        }

        public BookingBO Create(BookingBO book)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newBook = uow.BookingRepository.Create(bookConv.Convert(book));
                uow.Complete();
                return bookConv.Convert(newBook);
            }
        }

        public BookingBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var removeBook = uow.BookingRepository.Delete(Id);
                uow.Complete();
                return bookConv.Convert(removeBook);
            }
        }

        public BookingBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var getBook = uow.BookingRepository.Get(Id);
                getBook.SingleRoom = uow.SingleRoomRepository.Get(getBook.SingleRoomId);
                getBook.DoubleRoom = uow.DoubleRoomRepository.Get(getBook.DoubleRoomId);
                getBook.Suite = uow.SuiteRepository.Get(getBook.SuiteId);
                getBook.Guest = uow.GuestRepository.Get(getBook.GuestId);
                return bookConv.Convert(getBook);
            }
        }

        public List<BookingBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.BookingRepository.GetAll().Select(bookConv.Convert).ToList();
            }
        }

        public BookingBO Update(BookingBO book)
        {
            using (var uow = facade.UnitOfWork)
            {
                var updateBook = uow.BookingRepository.Get(book.Id);
                if (updateBook == null)
                {
                    throw new InvalidOperationException("booking not found");
                }

                updateBook.CheckIn = book.CheckIn;
                updateBook.CheckOut = book.CheckOut;
                updateBook.SingleRoomId = book.SingleRoomId;
                updateBook.DoubleRoomId = book.DoubleRoomId;
                updateBook.SuiteId = book.SuiteId;
                updateBook.GuestId = book.GuestId;
                uow.Complete();
                return bookConv.Convert(updateBook);
            }
;
        }
    }
}