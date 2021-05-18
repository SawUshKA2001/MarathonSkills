namespace MarathonSkills.Models
{
    /// <summary>
    /// Объект таблицы donations
    /// </summary>
    public partial class donations
    {
        /// <summary>
        /// Высчитываемое значение полного имени пользователя
        /// </summary>
        public string DonatorFullName
        {
            get
            {
                return donator_lastname + " " + donator_firstname + " " + donator_othername;
            }
        }
    }
}
