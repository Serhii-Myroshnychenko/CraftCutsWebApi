using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingListRepository _bookingListRepository;
        public BookingController(IBookingRepository bookingRepository , IBookingListRepository bookingListRepository)
        {
            _bookingRepository = bookingRepository;
            _bookingListRepository = bookingListRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingConstructor bookingConstructor)
        {
            try
            {
                var barber_id = _bookingRepository.GetBarberIdByName(bookingConstructor.BarberName);
                var customer_id = _bookingRepository.GetCustomerIdByName(bookingConstructor.CustomerEmail);
                var promocode_id = _bookingRepository.GetPromocodeIdByName(bookingConstructor.PromocodeName);
                var price = _bookingRepository.GetPriceByName(bookingConstructor.ServiceName);
                var service_id = _bookingRepository.GetServiceIdByName(bookingConstructor.ServiceName);
                bool is_paid = false;
                if(barber_id != null && customer_id != null && price != null)
                {
                    
                    

                    await _bookingRepository.CreateBooking(Convert.ToInt32(barber_id),Convert.ToInt32(customer_id),Convert.ToDecimal(price),bookingConstructor.date,is_paid,Convert.ToInt32(promocode_id));
                    return Ok("Ok");

                }
                return BadRequest("Что-то пошло не так");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
