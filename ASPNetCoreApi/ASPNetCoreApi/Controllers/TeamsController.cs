using System.Collections.Generic;
using ASPNetCoreApi.DataConversion;
using ASPNetCoreApi.Models;
using ASPNetCoreApi.Models.Factory;
using DataTransition.DataManagement;
using DataTransition.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreApi.Controllers
{
    /// <summary>
    /// Controller for Teams operations
    /// </summary>
    [Route("teams/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        /// <summary>
        /// Try to add a new Team to the base
        /// </summary>
        /// <param name="title">New team title</param>
        /// <returns>Adding operation response code and messageS</returns>
        [HttpPost]
        public ObjectResult AddTeam(string title)
        {
            int responseCode = 0;
            string responseMessage = string.Empty;
            if (!string.IsNullOrEmpty(title))
            {
                List<string> props = new List<string> { title };
                TeamModel model = ModelFactory.Instance.GetTeamModel(props);
                //TeamDTO dto = new TeamDTO();
                //dto.Title = model.Title;
                TeamDTO dto = ModelConverter.Instance.GetDTO(model) as TeamDTO;
                responseCode = DataManager.Instance.Save(dto);

            }
            else
            {
                responseCode = 400;
            }

            switch (responseCode)
            {
                case (200):
                    responseMessage = $"Team {title} successfully added to base.";
                    break;
                case (400):
                    responseMessage = $"Bad request";
                    break;
                case (401):
                    responseMessage = $"Team was not added to base. Name {title} is allready taken.";
                    break;
                default:
                    if (responseCode == 0)
                    {
                        responseCode = 490;
                    }
                    responseMessage = "Unknown error. Try again later";
                    break;
            }

            return StatusCode(responseCode, responseMessage);

        }


    }
}