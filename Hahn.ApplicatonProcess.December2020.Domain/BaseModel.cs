using System;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    public class BaseModel
    {
        public int Id { get; set; }
        public int? InsertedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
