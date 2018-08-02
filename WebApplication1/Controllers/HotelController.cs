using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HotelController : ApiController
    {
        int count = 3;
        private static List<Hotel> hoteList = new List<Hotel>()
        {
            new Hotel(){HotelId=101,HotelName="ABC",HotelAddress="Viman Nagar",NoOfRooms=5,AirportCode="PNQ"},
            new Hotel(){HotelId=101,HotelName="PQR",HotelAddress="Delhi",NoOfRooms=10,AirportCode="IGI"},
            new Hotel(){HotelId=101,HotelName="XYZ",HotelAddress="Mumbai",NoOfRooms=11,AirportCode="MUM"}
        };


        [HttpGet]
        [Route("api/Hotel")]
        public ApiResponse GetAllHotels()
        {
            try
            {
                return new ApiResponse()
                {
                    Hotels = hoteList,
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        StatusCode = 200,
                        ErrorMessage = ""
                    }
                };
            }
            catch (Exception e)
            {
                return new ApiResponse()
                {
                    Hotels = null,
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Failure,
                        StatusCode = 500,
                        ErrorMessage = "Something went wrong"
                    }
                };
            }
        }
        [HttpGet]
        [Route("api/Hotel/{id}")]
        public ApiResponse GetHotelById(int id)
        {
            var hotel = hoteList.Find(x => x.HotelId == id);
            try
            {
                return new ApiResponse()
                {
                    Hotels = new List<Hotel>() { new Hotel() { HotelId = hotel.HotelId, HotelName = hotel.HotelName, HotelAddress = hotel.HotelAddress, NoOfRooms = hotel.NoOfRooms, AirportCode = hotel.AirportCode } },
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        StatusCode = 200,
                        ErrorMessage = ""
                    }
                };
            }
            catch (Exception e)
            {
                return new ApiResponse()
                {
                    Hotels = null,
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Failure,
                        StatusCode = 404,
                        ErrorMessage = "Nothing Found"
                    }
                };
            }
        }


        [HttpPost]
        [Route("api/Hotel")]
        public ApiResponse PostAMovie([FromBody]Hotel value)
        {

            try
            {
                count++;
                value.HotelId = count;
                hoteList.Add(value);
                return new ApiResponse()
                {
                    Hotels = hoteList,
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        StatusCode = 200,
                        ErrorMessage = "Hotel added successfully"
                    }
                };
            }
            catch (Exception e)
            {
                return new ApiResponse()
                {
                    Hotels = hoteList,
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Failure,
                        StatusCode = 500,
                        ErrorMessage = "Please enter a valid hotel"
                    }
                };
            }
        }
        [HttpDelete]
        [Route("api/Hotel/{id}")]
        public ApiResponse DeleteAHotel(int id)
        {
            var hotel = hoteList.Find(x => x.HotelId == id);
            try
            {
                hoteList.Remove(hotel);
                return new ApiResponse()
                {
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        StatusCode = 200,
                        ErrorMessage = "Hotel"
                    }
                };
            }
            catch (Exception e)
            {
                return new ApiResponse()
                {
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Failure,
                        StatusCode = 404,
                        ErrorMessage = "Resource not found"
                    }
                };
            }
        }
        [HttpPut]
        [Route("api/Hotel/{id}")]
        public ApiResponse BookAHotel(int id)
        {
            var hotel = hoteList.Find(x => x.HotelId == id);
            try
            {
                hotel.NoOfRooms--;
                return new ApiResponse()
                {
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        StatusCode = 200,
                        ErrorMessage = "Hotel Successfully Booked"
                    }
                };
            }
            catch(Exception e)
            {
                return new ApiResponse()
                {
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Failure,
                        StatusCode = 404,
                        ErrorMessage = "Hotel Id not found"
                    }
                };
            }
        }
    }
}
