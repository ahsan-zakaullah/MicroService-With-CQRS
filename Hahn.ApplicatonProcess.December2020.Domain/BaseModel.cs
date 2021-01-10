using System;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    /// <summary>
    /// base model of all models
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Id for applicant
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User Id that create specific applicant
        /// </summary>
        public int? InsertedBy { get; set; }
        /// <summary>
        /// User Id who updated the applicant record
        /// </summary>
        public int? UpdatedBy { get; set; }
        /// <summary>
        /// Creation date of applicant
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Updated date of applicant
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}
