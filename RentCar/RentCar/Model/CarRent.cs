using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Model
{
    /// <summary>
    /// Class for information about rent cars that describes the custom data type which is exposed to the client
    /// </summary>
    [DataContract]
    public class CarRent
    {
        /// <summary>
        /// Property for car which is rent
        /// </summary>
        [DataMember]
        public Car Car { get; set; }

        /// <summary>
        /// property for duration of renting
        /// </summary>
        [DataMember]
        public decimal Hours { get; set; }

        /// <summary>
        /// Property for price per hour for renting
        /// </summary>
        [DataMember]
        public decimal PricePerHour { get; set; }

       
        /// <summary>
        /// Constructor for renting
        /// </summary>
        /// <param name="car">car</param>
        /// <param name="hours">hours of renting</param>
        public CarRent(Car car,decimal hours)
        {
            this.Car = car;
            this.Hours = hours;
            this.PricePerHour = car.Year;
        }
    }
}
