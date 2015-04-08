using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Model
{
    /// <summary>
    /// Class for Car that describes the custom data type which is exposed to the client
    /// </summary>
    [DataContract]
    public class Car
    {
        /// <summary>
        /// Property for car brand
        /// </summary>
        [DataMember]
        public string Brand { get; set; }

        /// <summary>
        /// Property for car model
        /// </summary>
        [DataMember]
        public string Model { get; set; }

        /// <summary>
        /// Property for car registration
        /// </summary>
        [DataMember]
        public string Registration { get; set; }

        /// <summary>
        /// Property for year of manufacturing
        /// </summary>
        [DataMember]
        public int Year { get; set; }


        /// <summary>
        /// Constructor for car with 4 parametars
        /// </summary>
        /// <param name="brand">car brand</param>
        /// <param name="model">car model</param>
        /// <param name="registration">registration</param>
        /// <param name="year">year of manufacturing</param>
        public Car(string brand, string model, string registration, int year)
        {
            this.Brand = brand;
            this.Model = model;
            this.Registration = registration;
            this.Year = year;
        }
    }
}
