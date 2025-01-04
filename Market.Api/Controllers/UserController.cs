//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Users;
using Market.Api.services.foundation.user;
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
        public async ValueTask<ActionResult<Users>> PostUserAsync(Users user)
        {
            try
            {
                Users persistedUser = await this.userService.AddUsersAsync(user);
                return Created(persistedUser);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
    }
}
