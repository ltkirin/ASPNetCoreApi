using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreApi.DataConversion;
using ASPNetCoreApi.Models;
using ASPNetCoreApi.Models.Factory;
using ASPNetCoreApi.Token;
using ASPNetCoreApi.Util;
using DataTransition.common.DTO;
using DataTransition.DataManagement;
using DataTransition.DTO;
using DataTransition.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASPNetCoreApi.Controllers
{
    /// <summary>
    /// Controller for User operations
    /// </summary>
    [Route("/api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("/register")]
        public ObjectResult RegisterUser(string login, string password)
        {
            int responseCode = 0;
            string responseMessage = string.Empty;
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                string passwordHash = PasswordHashing.ComputePasswordHash(password);
                List<string> props = new List<string> { login, passwordHash };
                UserModel model = ModelFactory.Instance.GetUserModel(props);
                UserDTO dto = ModelConverter.Instance.GetDTO(model) as UserDTO;
                responseCode = DataManager.Instance.Save(dto);

            }
            else
            {
                responseCode = 400;
            }

            switch (responseCode)
            {
                case (200):
                    responseMessage = $"User {login} successfully added to base.";
                    break;
                case (400):
                    responseMessage = $"Bad request";
                    break;
                case (410):
                    responseMessage = $"User was not added to base. Name {login} is allready taken.";
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
        [Route("/authorize")]
        [HttpGet]
        public ObjectResult Authorize(string login, string password)
        {
            int responseCode = 0;
            string responseMessage = string.Empty;
            Response.ContentType = "application/json";
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                string passwordHash = PasswordHashing.ComputeHash(password, login);
                List<string> props = new List<string> { login, passwordHash };
                UserModel model = ModelFactory.Instance.GetUserModel(props);
                UserDTO dto = ModelConverter.Instance.GetDTO(model) as UserDTO;
                if (AuthorizationService.Instance.UserAuthorised(dto))
                {
                    responseCode = 200;

                }
                else
                {
                    responseCode = 402;
                }
                switch (responseCode)
                {
                    case (200):
                        responseMessage = TokenFactory.Instance.GetToken(login);

                        break;
                    case (402):
                        responseMessage = "Invalid login or password";
                        break;

                    default:
                        if (responseCode == 0)
                        {
                            responseCode = 490;
                        }
                        responseMessage = "Unknown error. Try again later";
                        break;
                }
            }
            return StatusCode(responseCode, responseMessage);
        }
        [Route("/usercallsign")]
        [HttpPut]
        public ObjectResult SetCallsign(string login, string callsign)
        {
            int responseCode = 0;
            string responseMessage = string.Empty;
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(callsign))
            {
                UserModel tempModel = ModelFactory.Instance.GetEmptyUserModel();
                tempModel.Login = login;
                UserDTO search = ModelConverter.Instance.GetDTO(tempModel) as UserDTO;
                IList<BaseDTO> searchresults = DataManager.Instance.Find(search);
                if (searchresults.Any())
                {
                    UserDTO updatedDTO = searchresults[0] as UserDTO;
                    updatedDTO.Callsign = callsign;
                    responseCode = DataManager.Instance.Update(updatedDTO);
                }
                else
                {
                    responseCode = 412;
                }

            }
            else
            {
                responseCode = 400;
            }
            switch (responseCode)
            {
                case (200):
                    responseMessage = $"User {login} successfully updated.";
                    break;
                case (400):
                    responseMessage = $"Bad request";
                    break;
                case (412):
                    responseMessage = $"User was not {login} found.";
                    break;
                case (413):
                    responseMessage = $"Search returned multiple user by login. No changes applied";
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

        [Route("/userteam")]
        [HttpPut]
        public ObjectResult SetTeam(string login, int teamId)
        {
            int responseCode = 0;
            string responseMessage = string.Empty;
            if (!string.IsNullOrEmpty(login) && teamId > 0)
            {
                UserModel tempUser = ModelFactory.Instance.GetEmptyUserModel();
                tempUser.Login = login;
                UserDTO search = ModelConverter.Instance.GetDTO(tempUser) as UserDTO;
                IList<BaseDTO> searchResults = DataManager.Instance.Find(search);
                if (searchResults.Any())
                {
                    UserDTO updatedDTO = searchResults[0] as UserDTO;

                    TeamModel tempTeam = ModelFactory.Instance.GetEmptyTeamModel();
                    tempTeam.Id = teamId;

                    TeamDTO teamSearch = ModelConverter.Instance.GetDTO(tempTeam) as TeamDTO;

                    IList<BaseDTO> foundTeams = DataManager.Instance.Find(teamSearch);
                    if(foundTeams.Any())
                    {
                        updatedDTO.Team = foundTeams.First() as TeamDTO;
                        responseCode = DataManager.Instance.Update(updatedDTO);
                    }

                }
                else
                {
                    responseCode = 412;
                }

            }
            else
            {
                responseCode = 400;
            }
            switch (responseCode)
            {
                case (200):
                    responseMessage = $"User {login} successfully updated.";
                    break;
                case (400):
                    responseMessage = $"Bad request";
                    break;
                case (412):
                    responseMessage = $"User was not {login} found.";
                    break;
                case (413):
                    responseMessage = $"Search returned multiple user by login. No changes applied";
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