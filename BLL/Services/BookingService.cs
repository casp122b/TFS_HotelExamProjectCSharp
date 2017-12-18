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

        //Makes the facade available in the class
        public BookingService(DALFacade facade)
        {
            this.facade = facade;
        }

        //Converts booking and goes through the facade to create and save it, then returns the booking converted back
        public BookingBO Create(BookingBO book)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newBook = uow.BookingRepository.Create(bookConv.Convert(book));
                uow.Complete();
                return bookConv.Convert(newBook);
            }
        }

        //Goes through the facade to delete booking by it's id and save the change, then returns the booking converted back, the id must already exsist
        public BookingBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var removeBook = uow.BookingRepository.Delete(Id);
                if (removeBook == null)
                {
                    throw new InvalidOperationException("booking not found");
                }

                uow.Complete();
                return bookConv.Convert(removeBook);
            }
        }

        //Goes through the facade to get a booking by it's id, it returns a converted booking, the id must already exsist
        public BookingBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var getBook = uow.BookingRepository.Get(Id);
                return bookConv.Convert(getBook);
            }
        }

        //Goes through the facade  to get a list of bookings and return them converted
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