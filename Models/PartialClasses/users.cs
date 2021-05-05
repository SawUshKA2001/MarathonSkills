namespace MarathonSkills.Models
{
    public partial class users
    {
        public string UserFullName
        {
            get
            {
                return user_lastname + " " + user_firstname + " " + user_othername;
            }
        }
    }
}
