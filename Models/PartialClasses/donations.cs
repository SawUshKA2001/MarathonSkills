namespace MarathonSkills.Models
{
    public partial class donations
    {
        public string DonatorFullName
        {
            get
            {
                return donator_lastname + " " + donator_firstname + " " + donator_othername;
            }
        }
    }
}
