using MarathonSkills.Controllers;

namespace MarathonSkills.Models
{
    /// <summary>
    /// Класс таблицы runners
    /// </summary>
    public partial class runners
    {
        readonly DonationsController donObj = new DonationsController();
        /// <summary>
        /// Высчитываемое значение суммы пожертвований на бегуна
        /// </summary>
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
