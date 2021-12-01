using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Logic;
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
        private readonly IBookingLogic _bookingLogic;
        
        
        public BookingController(IBookingRepository bookingRepository, IBookingLogic bookingLogic)
        {
            _bookingRepository = bookingRepository;
            _bookingLogic = bookingLogic;
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingConstructor bookingConstructor)
        {
            try
            {
                var answer = await _bookingLogic.CreateBookingLogic(bookingConstructor);
                if (answer == "Ok")
                {
                    return Ok(answer);
                }
                return BadRequest(answer);
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
               var answer = await _bookingLogic.CreateBookingLogic(bookingConstructor);
                if(answer == "Ok")
                {
                    return Ok(answer);
                }
                return BadRequest(answer);
                
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
