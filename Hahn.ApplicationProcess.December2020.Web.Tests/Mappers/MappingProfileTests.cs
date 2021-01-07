using AutoMapper;
using FluentAssertions;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Mappers;
using Hahn.ApplicatonProcess.December2020.Web.Models.v1;
using Xunit;

namespace Hahn.ApplicationProcess.December2020.Web.Tests.Mappers
{
    public class MappingProfileTests
    {
        private readonly CreateApplicantModel _createApplicantModel;
        private readonly UpdateApplicantModel _updateApplicantModel;
        private readonly IMapper _mapper;

        public MappingProfileTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mockMapper.CreateMapper();

            _createApplicantModel = new CreateApplicantModel
            {
                Id = 1,
                Name = "Ahsan",
                FamilyName = "Raza",
                Address = "Berlin",
                EmailAddress = "ahsan.raza@intagleo.com",
                CountryOfOrigin = "Germany",
                Age = 30,
                Hired = true
            };
            _updateApplicantModel = new UpdateApplicantModel
            {
                Id = 2,
                Name = "Ahsan",
                FamilyName = "Raza",
                Address = "Berlin",
                EmailAddress = "ahsan.raza@intagleo.com",
                CountryOfOrigin = "Germany",
                Age = 30,
                Hired = true
            };
        }

        [Fact]
        public void Map_Applicant_CreateApplicantModel_ShouldHaveValidConfig()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<Applicant, CreateApplicantModel>());

            configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void Map_Applicant_UpdateApplicantModel_ShouldHaveValidConfig()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<Applicant, UpdateApplicantModel>());

            configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void Map_Applicant_Applicant_ShouldHaveValidConfig()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<Applicant, Applicant>());

            configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void Map_CreateApplicantModel_Applicant()
        {
            var applicant = _mapper.Map<Applicant>(_createApplicantModel);

            applicant.Name.Should().Be(_createApplicantModel.Name);
            applicant.FamilyName.Should().Be(_createApplicantModel.FamilyName);
            applicant.Address.Should().Be(_createApplicantModel.Address);
            applicant.EmailAddress.Should().Be(_createApplicantModel.EmailAddress);
            applicant.CountryOfOrigin.Should().Be(_createApplicantModel.CountryOfOrigin);
            applicant.Age.Should().Be(_createApplicantModel.Age);
        }

        [Fact]
        public void Map_UpdateApplicantModel_Applicant()
        {
            var applicant = _mapper.Map<Applicant>(_updateApplicantModel);

            applicant.Id.Should().Be(_updateApplicantModel.Id);
            applicant.Name.Should().Be(_createApplicantModel.Name);
            applicant.FamilyName.Should().Be(_createApplicantModel.FamilyName);
            applicant.Address.Should().Be(_createApplicantModel.Address);
            applicant.EmailAddress.Should().Be(_createApplicantModel.EmailAddress);
            applicant.CountryOfOrigin.Should().Be(_createApplicantModel.CountryOfOrigin);
            applicant.Age.Should().Be(_createApplicantModel.Age);
        }
    }
}