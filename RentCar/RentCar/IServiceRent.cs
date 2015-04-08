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
    /// Iterface that describe the operation that service can provide
    /// </summary>
    [ServiceContract]
    public interface IServiceRent
    {
        /// <summary>
        /// Methods for getting all cars
        /// </summary>
        /// <returns>list od cars</returns>
        [OperationContract]
        List<Car> getCars();

        /// <summary>
        /// Method for getting reservations for specific car
        /// </summary>
        /// <param name="car">car</param>
        /// <returns>list of reservations</returns>
        [OperationContract]
        List<CarRent> getCarReservations(Car car);

        /// <summary>
        /// Method for calculating cost for reservation
        /// </summary>
        /// <param name="carRent">renting information</param>
        /// <returns>cost for renting</returns>
        [OperationContract]
        decimal calculateCost(CarRent carRent);
    }


}
