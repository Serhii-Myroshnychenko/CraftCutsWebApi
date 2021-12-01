﻿using CraftCutsTestApiProject.Context;
using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DapperContext _dapperContext;
        

        public BookingRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            
        }
        public async Task CreateBooking(int barber_id,int customer_id,decimal price,DateTime date,bool is_paid,int? promocode_id)
        {
            var query = "INSERT INTO Booking (barber_id,customer_id,price,date,is_paid,promocode_id) VALUES (@barber_id,@customer_id,@price,@date,@is_paid,@promocode_id)";
            var parameters = new DynamicParameters();
            parameters.Add("barber_id", barber_id, DbType.Int64);
            parameters.Add("customer_id", customer_id, DbType.Int64);
            parameters.Add("price",price, DbType.Decimal);
            parameters.Add("date", date, DbType.DateTime);
            parameters.Add("is_paid", is_paid, DbType.Boolean);
            parameters.Add("promocode_id", promocode_id, DbType.Int64);


            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        
        public async Task<IEnumerable<Booking>> GetBookings()
        {
            var query = "SELECT * FROM Booking";
            using (var connection = _dapperContext.CreateConnection())
            {
                var bookings = await connection.QueryAsync<Booking>(query);
                return bookings.ToList();
            }
        }
        public async Task<Booking> GetBooking(int id)
        {
            var query = "SELECT * FROM Booking Where booking_id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var booking = await connection.QuerySingleOrDefaultAsync<Booking>(query, new { id });
                return booking;
            }
        }
        public async Task UpdateBooking(int id, Booking booking)
        {
            var query = "UPDATE Booking SET barber_id = @barber_id, customer_id = @customer_id, price = @price, date = @date, is_paid = @is_paid,promocode_id=@promocode_id WHERE booking_id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            parameters.Add("barber_id", booking.Barber_id, DbType.Int64);
            parameters.Add("customer_id",booking.Customer_id, DbType.Int64);
            parameters.Add("price",booking.Price, DbType.Decimal);
            parameters.Add("date",booking.Date, DbType.DateTime);
            parameters.Add("is_paid",booking.Is_paid, DbType.Boolean);
            parameters.Add("promocode_id",booking.Promocode_id, DbType.Int64);


            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteBooking(int id)
        {
            var query = "DELETE FROM Booking WHERE booking_id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
        public async Task<IEnumerable<BookingCustomerList>> GetBookingsByCustomerId(int id)
        {
            var query = "Select Service.name,Booking.price,Booking.date from Booking Join BookingList On Booking.booking_id = BookingList.booking_id Join Service On BookingList.service_id = Service.service_id Join Customer On Booking.customer_id = Customer.customer_id Where Booking.customer_id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var bookings = await connection.QueryAsync<BookingCustomerList>(query, new { id});
                return bookings.ToList();
            }
        }
        

    }
}
