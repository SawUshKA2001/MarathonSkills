using MarathonSkills.Controllers;

namespace MarathonSkills.Models
{
    public partial class runners
    {
        readonly DonationsController donObj = new DonationsController();
        public int AllDonationsAmount
        {
            get
            {
                int donationSumm = 0;
                foreach (donations item in donObj.GetCurrentRunnerDonations(runner_id))
                {
                    donationSumm += item.donation_amount;
                }
                return donationSumm;
            }
        }
    }
}
