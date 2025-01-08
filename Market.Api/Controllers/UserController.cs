//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Users;
using Market.Api.Models.Foundation.Users.exceptions;
using Market.Api.services.foundation.user;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Market.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : RESTFulController
    {
        private readonly IuserService userService;

        public UserController(IuserService userService) =>
            this.userService = userService;

        [HttpPost]
        public async ValueTask<ActionResult<Users>> PostUserAsync(Users users)
        {
            try
            {
                Users postedUser = await this.userService.AddUsersAsync(users);

                return Created(postedUser);
            }
            catch(UserValidationExcption userValidationException)
            {
                return BadRequest(userValidationException.InnerException);
            }
            catch(UserDependencyValidationException userDependencyException)
               when(userDependencyException.InnerException is AlreadyExisUserException)
            {
                return Conflict(userDependencyException.InnerException);
            }
            catch(UserDependencyValidationException userDeendencyValidationException)
            {
                return BadRequest(userDeendencyValidationException.InnerException);
            }
            catch(UserDependencyException userDependencyException)
            {
                return InternalServerError(userDependencyException.InnerException);
            }
            catch(UserserviceException userServiceException)
            {
                return InternalServerError(userServiceException.InnerException);
            }
        }
    }
}
