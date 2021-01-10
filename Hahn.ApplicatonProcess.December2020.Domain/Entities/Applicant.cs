namespace Hahn.ApplicatonProcess.December2020.Domain.Entities
{
    /// <summary>
    /// Domain model for applicant
    /// </summary>
    public class Applicant : BaseModel
    {
        #region constructors
        // Default constructor
        public Applicant()
        {
            
        }
        // Parameterized constructor to seed the data in the applicant table of database.
        public Applicant(string name,string familyName,string address,string countryOfOrigin,string emailAddress, int age , bool hired )
        {
            Name = name;
            FamilyName = familyName;
            Address = address;
            CountryOfOrigin = countryOfOrigin;
            EmailAddress = emailAddress;
            Age = age;
            Hired = hired;
        }
        #endregion

        /// <summary>
        /// First name of applicant
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Last name for applicant
        /// </summary>
        public string FamilyName { get; set; }
        /// <summary>
        /// Complete address for applicant
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Country of applicant
        /// </summary>
        public string CountryOfOrigin { get; set; }
        /// <summary>
        /// Email address of applicant
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Age of applicant
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Hired status of applicant
        /// </summary>
        public bool Hired { get; set; }

    }
}
