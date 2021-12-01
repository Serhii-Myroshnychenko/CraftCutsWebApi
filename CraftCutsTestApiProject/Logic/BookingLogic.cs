using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Logic
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IIdGetterRepository _idGetterRepository;
        private readonly IPromocodeRepository _promocodeRepository;
        private readonly IBookingListRepository _bookingListRepository;

        public BookingLogic(IBookingRepository bookingRepository, IIdGetterRepository idGetterRepository, IPromocodeRepository promocodeRepository ,IBookingListRepository bookingListRepository)
        {
            _bookingListRepository = bookingListRepository;
            _bookingRepository = bookingRepository;
            _promocodeRepository = promocodeRepository;
            _idGetterRepository = idGetterRepository;
        }

        public async Task<string> CreateBookingLogic(BookingConstructor bookingConstructor)
        {
            int barber_id = await _idGetterRepository.GetBarberIdByName(bookingConstructor.BarberName);

            int customer_id = await _idGetterRepository.GetCustomerIdByName(bookingConstructor.CustomerEmail);

            var promo = await _promocodeRepository.GetPromocodeByName(bookingConstructor.PromocodeName);


            decimal price = await _idGetterRepository.GetPriceByName(bookingConstructor.ServiceName);
            if (promo != null)
            {
                price = price - ((price / 100) * promo.Sale_percent);
            }
            int service_id = await _idGetterRepository.GetServiceIdByName(bookingConstructor.ServiceName);

            bool is_paid = false;
            if (barber_id != 0 && customer_id != 0 && price != 0)
            {

                if (promo == null)
                {
                        await _bookingRepository.CreateBooking(barber_id, customer_id, price, bookingConstructor.Date, is_paid, null);
                        int booking = await _idGetterRepository.GetBookingIdByParams(barber_id, customer_id, price, bookingConstructor.Date);
                        await _bookingListRepository.CreateBookingList(booking, service_id);     
                }
                else
                {
                    await _bookingRepository.CreateBooking(barber_id, customer_id, price, bookingConstructor.Date, is_paid, null);
                    await _promocodeRepository.DeletePromocode(promo.Promocode_id);
                    int booking = await _idGetterRepository.GetBookingIdByParams(barber_id, customer_id, price, bookingConstructor.Date);
                    await _bookingListRepository.CreateBookingList(booking, service_id);
                }
                return "Ok";
            }
            return "Что-то пошло не так";
        }
    }
}
