using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Web.Models.v1;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Mappers
{
    /// <summary>
    /// Mapping profile using auto mapper. 
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateApplicantModel, Applicant>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<UpdateApplicantModel, Applicant>();
            CreateMap<DeleteApplicantModel, Applicant>();
        }
    }
}