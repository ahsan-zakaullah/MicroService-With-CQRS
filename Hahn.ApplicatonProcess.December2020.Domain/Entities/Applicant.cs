using System;

namespace Hahn.ApplicatonProcess.December2020.Domain.Entities
{
    public class Applicant
    {
        public Applicant()
        {
            
        }

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
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }
        public int? InsertedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
