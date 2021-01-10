using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Query;
using Hahn.ApplicatonProcess.December2020.Data.Utils;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Web.Models.v1;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers.V1
{
    [ApiController, Route("api/[controller]")]
    public class ApplicantV1Controller : BaseController
    {
        private readonly ILogger<ApplicantV1Controller> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<ApplicantV1Controller> _localizer;
        public ApplicantV1Controller(IMapper mapper, IMediator mediator, ILogger<ApplicantV1Controller> logger, IStringLocalizer<ApplicantV1Controller> localizer)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
            _localizer = localizer;
            //string currentCulture = Request.Query["culture"];
            //if (!string.IsNullOrEmpty(currentCulture))
            //{
            //    CultureInfo.CurrentCulture = new CultureInfo(currentCulture);
            //}
        }

        /// <summary>
        /// Action to create a new applicant in the database.
        /// </summary>
        /// <returns>Returns the created applicant</returns>
        /// <response code="200">Returned if the applicant was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or the applicant couldn't be saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Applicant>>> GetAll()
        {
            try
            {
                var response = await Mediator.Send(new GetAllApplicantsQuery()
                );
                return Ok(response);
            }
            catch (HahnException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest($"{_localizer["UnableToRetrieve"]}");
            }

        }
        /// <summary>
        /// Action to create a new applicant in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the created applicant</returns>
        /// <response code="200">Returned if the applicant was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or the applicant couldn't be saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Applicant>>> GetById(int id = 1)
        {
            try
            {
                var response = await Mediator.Send(new GetApplicantByIdQuery
                {
                    Id = id
                }
                );
                return Ok(response);
            }
            catch (HahnException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest($"{_localizer["UnableToRetrieve"]}");
            }

        }


        /// <summary>
        /// Action to create a new applicant in the database.
        /// </summary>
        /// <param name="createApplicantModel">Model to create a new applicant</param>
        /// <returns>Returns the created applicant</returns>
        /// <response code="200">Returned if the applicant was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or the applicant couldn't be saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("Create")]
        public async Task<ActionResult<Applicant>> Create([FromBody] CreateApplicantModel createApplicantModel)
        {
            try
            {
                return await _mediator.Send(new CreateApplicantCommand
                {
                    Applicant = _mapper.Map<Applicant>(createApplicantModel)
                });

            }
            catch (HahnException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"{_localizer["UnableToSave"]}");
            }
        }

        /// <summary>
        /// Action to update an existing applicant
        /// </summary>
        /// <param name="updateApplicantModel">Model to update an existing applicant</param>
        /// <returns>Returns the updated applicant</returns>
        /// <response code="200">Returned if the applicant was updated</response>
        /// <response code="400">Returned if the model couldn't be parsed or the applicant couldn't be found</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("Update")]
        public async Task<ActionResult<Applicant>> Update([FromBody] UpdateApplicantModel updateApplicantModel)
        {
            try
            {
                var applicant = await _mediator.Send(new GetApplicantByIdQuery
                {
                    Id = updateApplicantModel.Id
                });

                if (applicant == null)
                {
                    return NotFound($"{_localizer["NotFoundApplicant"]} {updateApplicantModel.Id}");
                }

                return await _mediator.Send(new UpdateApplicantCommand
                {
                    Applicant = _mapper.Map(updateApplicantModel, applicant)
                });
            }
            catch (HahnException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"{_localizer["UnableToUpdate"]}");
            }
        }


        /// <summary>
        /// Action to update an existing applicant
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returns the updated applicant</returns>
        /// <response code="200">Returned true if the applicant was deleted</response>
        /// <response code="400">Returned if the model couldn't be parsed or the applicant couldn't be found</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> Delete(Applicant model)
        {
            try
            {
                var applicant = await _mediator.Send(new GetApplicantByIdQuery
                {
                    Id = model.Id
                });

                if (applicant == null)
                {
                    return BadRequest($"{_localizer["UnableToRetrieve"]} { model.Id}");
                }
                var result = await _mediator.Send(new DeleteApplicantCommand
                {
                    Applicant = applicant
                });
                if (result)
                {
                    return Ok($"{_localizer["RecordDeleted"]}");
                }

                return BadRequest($"{_localizer["UnableToDelete"]}");
            }
            catch (HahnException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"{_localizer["UnableToDelete"]}");
            }
        }

    }
}
