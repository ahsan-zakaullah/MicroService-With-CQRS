using System;
using System.Net;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Web.Controllers.V1;
using Hahn.ApplicatonProcess.December2020.Web.Models.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Hahn.ApplicationProcess.December2020.Web.Tests.Controllers
{
    public class ApplicantControllerTests
    {
        private readonly IMediator _mediator;
        private readonly ApplicantV1Controller _test;
        private readonly CreateApplicantModel _createApplicantModel;
        private readonly UpdateApplicantModel _updateApplicantModel;
        private readonly int _id = 1;

        public ApplicantControllerTests()
        {
            var mapper = A.Fake<IMapper>();
            _mediator = A.Fake<IMediator>();
            var appLogger = A.Fake<ILogger<ApplicantV1Controller>>();
            var localize = A.Fake<IStringLocalizer<ApplicantV1Controller>>();
            _test = new ApplicantV1Controller(mapper, _mediator, appLogger, localize);

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
                Name = "JJ",
                FamilyName = "Kotze",
                Address = "Berlin",
                EmailAddress = "ahsan.raza@intagleo.com",
                CountryOfOrigin = "Germany",
                Age = 26,
                Hired = true
            };
            var applicant = new Applicant
            {
                Id = 3,
                Name = "Carl",
                FamilyName = "Hibbard",
                Address = "Liverpool",
                EmailAddress = "ahsan.raza@intagleo.com",
                CountryOfOrigin = "UK",
                Age = 55,
                Hired = true
            };

            A.CallTo(() => mapper.Map<Applicant>(A<Applicant>._)).Returns(applicant);
            A.CallTo(() => _mediator.Send(A<CreateApplicantCommand>._, default)).Returns(true);
            A.CallTo(() => _mediator.Send(A<UpdateApplicantCommand>._, default)).Returns(true);
        }

        [Theory]
        [InlineData("CreateApplicantAsync: Applicant is null")]
        public async void Post_WhenAnExceptionOccurs_ShouldReturnBadRequest(string exceptionMessage)
        {
            A.CallTo(() => _mediator.Send(A<CreateApplicantCommand>._, default)).Throws(new ArgumentException(exceptionMessage));

            var result = await _test.Create(_createApplicantModel);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(exceptionMessage);
        }

        [Theory]
        [InlineData("UpdateApplicantAsync: Applicant is null")]
        [InlineData("No user with this id found")]
        public async void Put_WhenAnExceptionOccurs_ShouldReturnBadRequest(string exceptionMessage)
        {
            A.CallTo(() => _mediator.Send(A<UpdateApplicantCommand>._, default)).Throws(new Exception(exceptionMessage));

            var result = await _test.Update(_updateApplicantModel);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(exceptionMessage);
        }

        [Fact]
        public async void Post_ShouldReturnApplicant()
        {
            var result = await _test.Create(_createApplicantModel);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<Applicant>();
            result.Value.Id.Should().Be(_id);
        }

        [Fact]
        public async void Put_ShouldReturnApplicant()
        {
            var result = await _test.Update(_updateApplicantModel);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<Applicant>();
            result.Value.Id.Should().Be(_id);
        }
    }
}
