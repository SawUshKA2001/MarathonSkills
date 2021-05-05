namespace MarathonSkills.Models
{
    public partial class users
    {
        /// <summary>
        /// Высчитываемое значение полного имени пользователя
        /// </summary>
        public string UserFullName
        {
            get
            {
                return user_lastname + " " + user_firstname + " " + user_othername;
            }
        }
    }
}
