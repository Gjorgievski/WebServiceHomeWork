using Renting.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renting
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Private filed for service
        /// </summary>
        private ServiceReference1.ServiceRentClient objService;
        /// <summary>
        /// Private field for list of cars
        /// </summary>
        private Car[] cars;

        public Form1()
        {
            InitializeComponent();

            objService = new ServiceReference1.ServiceRentClient();
        }

        /// <summary>
        /// Getting cars from service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetCars_Click(object sender, EventArgs e)
        {
            cars = objService.getCars();

            lbCars.Items.Clear();

            foreach (Car c in cars)
            {
                lbCars.Items.Add(carToString(c));
            }
        }


        /// <summary>
        /// User frendly presentaon for car
        /// </summary>
        /// <param name="car">car</param>
        /// <returns>car in string format</returns>
        private string carToString(Car car)
        {
            
            string result = String.Format("{0} - {1}  ( {2} )",car.Brand,car.Model,car.Registration);

            return result;
        }

        /// <summary>
        /// Manipulation with list box item selection 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbCars_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lbCars.SelectedIndex != -1)
            {
                Car tmp = cars[lbCars.SelectedIndex];
                tbBrand.Text = tmp.Brand;
                tbModel.Text = tmp.Model;
                tbRegistration.Text = tmp.Registration;
                tbYear.Text = tmp.Year.ToString();

                CarRent[] reservations = objService.getCarReservations(tmp);

                lbReservations.Items.Clear();

                foreach (CarRent c in reservations)
                {
                    lbReservations.Items.Add(carRentToString(c));
                }
            }

        }

        /// <summary>
        /// User frendly presentaon for reservation
        /// </summary>
        /// <param name="car">car rent</param>
        /// <returns>reservation in string format</returns>
        private string carRentToString(CarRent carRent)
        {
            return string.Format("{0} {1:0.0} x {2:0.0} = {3:0.0}", carRent.Car.Registration, carRent.Hours, carRent.PricePerHour, carRent.Hours * carRent.PricePerHour);
        }

        /// <summary>
        /// Calculating cost for renting specifc car for certain time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (lbCars.SelectedIndex != -1)
            {
                Car car = cars[lbCars.SelectedIndex];
                decimal hours=numHours.Value;

                CarRent rent=new CarRent();
                rent.Car = car;
                rent.Hours = hours;
                rent.PricePerHour = car.Year;

                decimal cost = objService.calculateCost(rent);

                tbResult.Text = string.Format("It will cost you: {0:0.0}", cost);
            }
            else
            {
                tbResult.Text = "Please select a car";
            }
        }
    }
}
