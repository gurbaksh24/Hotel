using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int NoOfRooms { get; set; }
        public string HotelAddress { get; set; }
        public string AirportCode { get; set; }
    }
}