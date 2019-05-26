using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using ASPNetCoreApi.DataConversion;
using ASPNetCoreApi.Models;
using ASPNetCoreApi.Models.Factory;
using ASPNetCoreApi.Token;
using ASPNetCoreApi.Util;
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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
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
        [HttpGet]
        public ObjectResult Authorize(string login, string password)
        {
            int responseCode = 0;
            string responseMessage = string.Empty;
            Response.ContentType = "application/json";
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                string passwordHash = PasswordHashing.ComputeHash(password,login);
                List<string> props = new List<string> { login, passwordHash };
                UserModel model = ModelFactory.Instance.GetUserModel(props);
                UserDTO dto = ModelConverter.Instance.GetDTO(model) as UserDTO;
                if(AuthorizationService.Instance.UserAuthorised(dto))
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

    }




}