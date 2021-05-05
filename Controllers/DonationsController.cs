using MarathonSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSkills.Controllers
{
    public class DonationsController
    {
        readonly Core db = new Core();
        public List<donations> GetDonations()
        {
            return db.context.donations.ToList();
        }

        public List<donations> GetCurrentRunnerDonations(int runnerId)
        {
            return GetDonations().Where(x => x.runner_id == runnerId).ToList();
        }

        public bool AddNewDonation(int donationAmount, string firstName, string lastName, string otherName, int runnerId)
        {
            try
            {
                donations donation = new donations
                {
                    donation_amount = donationAmount,
                    donator_firstname = firstName,
                    donator_lastname = lastName,
                    donator_othername = otherName,
                    runner_id = runnerId
                };
                db.context.donations.Add(donation);
                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при совершении пожертвования!");
            }
        }
    }
}
