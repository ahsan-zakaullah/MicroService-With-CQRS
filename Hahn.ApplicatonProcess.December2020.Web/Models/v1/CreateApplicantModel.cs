using System;
using Newtonsoft.Json;

namespace Hahn.ApplicatonProcess.December2020.Web.Models.v1
{
    public class CreateApplicantModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("familyName", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyName { get; set; }
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }
        [JsonProperty("countryOfOrigin", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryOfOrigin { get; set; }
        [JsonProperty("emailAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; set; }
        [JsonProperty("age", NullValueHandling = NullValueHandling.Ignore)]
        public int Age { get; set; }
        [JsonProperty("hired", NullValueHandling = NullValueHandling.Ignore)]
        public bool Hired { get; set; }
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