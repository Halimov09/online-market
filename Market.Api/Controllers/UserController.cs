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

        [HttpDelete]
        public async ValueTask<ActionResult<Users>> DeleteUserByIdAsync(Guid id)
        {
            try
            {
                Users deletedUser = await this.userService.DeleteUserByIdAsync(id);

                return Ok(deletedUser);
            }
            catch (UserValidationExcption userValidationExcption)
                when (userValidationExcption.InnerException is NotFoundUserException)
            {
                return NotFound(userValidationExcption.InnerException);
            }
            catch (UserValidationExcption userValidationExcption)
            {
                return BadRequest(userValidationExcption.InnerException);
            }
            catch (UserDependencyValidationException userDependencyValidationException)
            {
                return BadRequest(userDependencyValidationException.InnerException);
            }
            catch (UserDependencyException userDependencyException)
            {
                return InternalServerError(userDependencyException.InnerException);
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<Users>> GetAllGuests()
        {
            try
            {
                IQueryable<Users> allUsers = this.userService.RetrieveAllUsers();

                return Ok(allUsers);
            }
            catch (UserDependencyException locationDependencyException)
            {
                return InternalServerError(locationDependencyException.InnerException);
            }
            catch (UserserviceException locationServiceException)
            {
                return InternalServerError(locationServiceException.InnerException);
            }
        }
    }
}
