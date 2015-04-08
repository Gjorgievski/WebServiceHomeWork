using RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RentCar
{
    /// <summary>
    /// Service class that implement service functionality
    /// </summary>
    public class ServiceRent : IServiceRent
    {
        /// <summary>
        /// list of cars
        /// </summary>
        private List<Car> cars = new List<Car>();
        /// <summary>
        /// list of reservations
        /// </summary>
        private List<CarRent> reservations = new List<CarRent>();


        /// <summary>
        /// Method for generating cars
        /// </summary>
        private void generateCars()
        {
            Car e1 = new Car("BMW", "M5", "GE0001AA", 2010);
            Car e2 = new Car("Audi", "A8", "BT0001AA", 2011);
            Car e3 = new Car("Mercedes", "S500", "SK0001AA", 2012);
            Car e4 = new Car("Zastava", "101", "PP0001BB", 1968);

            cars.Add(e1);
            cars.Add(e2);
            cars.Add(e3);
            cars.Add(e4);
        }

        /// <summary>
        /// Method for generating reservations
        /// </summary>
        private void generateReservation()
        {

            CarRent e1 = new CarRent(cars[0], 12);
            CarRent e2 = new CarRent(cars[0], 48);
            CarRent e3 = new CarRent(cars[0], 48);
            CarRent e4 = new CarRent(cars[1], 36);
            CarRent e5 = new CarRent(cars[1], 12);
            CarRent e6 = new CarRent(cars[2], 64);
            CarRent e7 = new CarRent(cars[2], 48);
            CarRent e8 = new CarRent(cars[3], 6);
            CarRent e9 = new CarRent(cars[3], 12);

            reservations.Add(e1);
            reservations.Add(e2);
            reservations.Add(e3);
            reservations.Add(e4);
            reservations.Add(e5);
            reservations.Add(e6);
            reservations.Add(e7);
            reservations.Add(e8);
            reservations.Add(e9);

        }


        /// <summary>
        /// Methods for getting all cars
        /// </summary>
        /// <returns>list od cars</returns>
        public List<Model.Car> getCars()
        {
            generateCars();
            generateReservation();

            return cars;
        }

        /// <summary>
        /// Method for getting reservations for specific car
        /// </summary>
        /// <param name="car">car</param>
        /// <returns>list of reservations</returns>
        public List<Model.CarRent> getCarReservations(Model.Car car)
        {
            List<CarRent> result = new List<CarRent>();

            generateCars();
            generateReservation();

            foreach (CarRent c in reservations)
            {
                if (c.Car.Registration.Equals(car.Registration))
                {
                    result.Add(c);
                }
            }

            return result;
        }

        /// <summary>
        /// Method for calculating cost for reservation
        /// </summary>
        /// <param name="carRent">renting information</param>
        /// <returns>cost for renting</returns>
        public decimal calculateCost(Model.CarRent carRent)
        {
            decimal cost = carRent.PricePerHour*carRent.Hours;

            return cost;

        }
    }
}
