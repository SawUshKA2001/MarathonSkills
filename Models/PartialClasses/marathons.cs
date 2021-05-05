namespace MarathonSkills.Models
{
    public partial class marathons
    {
        public string YearName
        {
            get
            {
                return marathon_name + " " + marathon_year.ToString();
            }
        }
    }
}
