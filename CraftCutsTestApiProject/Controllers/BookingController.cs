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
        private readonly IIdGetterRepository _idGetterRepository;
        private readonly IPromocodeRepository _promocodeRepository;
        
        public BookingController(IBookingRepository bookingRepository , IIdGetterRepository idGetterRepository, IPromocodeRepository promocodeRepository)
        {
            _bookingRepository = bookingRepository;
            _idGetterRepository = idGetterRepository;
            _promocodeRepository = promocodeRepository;
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingConstructor bookingConstructor)
        {
            try
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
                if(barber_id != 0 && customer_id != 0 && price != 0)
                {

                    if (promo == null)
                    {
                        await _bookingRepository.CreateBooking(barber_id, customer_id, price, bookingConstructor.Date, is_paid, null);
                    }
                    else
                    {
                        await _bookingRepository.CreateBooking(barber_id, customer_id, price, bookingConstructor.Date, is_paid, null);
                        await _promocodeRepository.DeletePromocode(promo.Promocode_id);
                    }
                    

                    return Ok("Ok");

                }
                return BadRequest("Что-то пошло не так");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("Web")]
        public async Task<IActionResult> CreateBookingWeb([FromBody]BookingConstructor bookingConstructor)
        {
            try
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
                    }
                    else
                    {
                        await _bookingRepository.CreateBooking(barber_id, customer_id, price, bookingConstructor.Date, is_paid, null);
                        await _promocodeRepository.DeletePromocode(promo.Promocode_id);
                    }


                    return Ok("Ok");

                }
                return BadRequest("Что-то пошло не так");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            try
            {
                var bookings = await _bookingRepository.GetBookings();
                return Ok(bookings);
            }
            catch(Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            try
            {
                var booking = await _bookingRepository.GetBooking(id);
                return Ok(booking);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id,Booking booking)
        {
            try
            {
                var book = await _bookingRepository.GetBooking(id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    await _bookingRepository.UpdateBooking(id, booking);
                    return Ok("Ok");
                }
                
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            try
            {
                var booking = await _bookingRepository.GetBooking(id);
                if (booking == null)
                {
                    return NotFound();
                }
                else
                {
                    await _bookingRepository.DeleteBooking(id);
                    return Ok("Ok");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("List/{id}")]
        public async Task<IActionResult> GetBookingsById(int id)
        {
            try
            {
                var bookings = await _bookingRepository.GetBookingsByCustomerId(id);
                return Ok(bookings);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
