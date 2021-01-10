using System;
using Newtonsoft.Json;

namespace Hahn.ApplicatonProcess.December2020.Web.Models.v1
{
    /// <summary>
    /// request model for applicant
    /// </summary>
    public class CreateApplicantModel
    {
        /// <summary>
        /// Id for applicant
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        /// <summary>
        /// First name of applicant
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        /// <summary>
        /// Last name for applicant
        /// </summary>
        [JsonProperty("familyName", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyName { get; set; }
        /// <summary>
        /// Complete address for applicant
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }
        /// <summary>
        /// Country of applicant
        /// </summary>
        [JsonProperty("countryOfOrigin", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryOfOrigin { get; set; }
        /// <summary>
        /// Email address of applicant
        /// </summary>
        [JsonProperty("emailAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; set; }
        /// <summary>
        /// Age of applicant
        /// </summary>
        [JsonProperty("age", NullValueHandling = NullValueHandling.Ignore)]
        public int Age { get; set; }
        /// <summary>
        /// Hired status of applicant
        /// </summary>
        [JsonProperty("hired", NullValueHandling = NullValueHandling.Ignore)]
        public bool Hired { get; set; }
        /// <summary>
        /// Ignore while submitting the request
        /// </summary>
        [JsonIgnore]
        public int? InsertedBy { get; set; }
        [JsonIgnore]
        public int? UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
    }
}