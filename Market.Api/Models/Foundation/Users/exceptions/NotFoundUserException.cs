﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Users.exceptions
{
    public class NotFoundUserException : Xeption
    {
        public NotFoundUserException(Guid usersId)
            : base(message: $"Couldn't find client with id {usersId}.")
        { }
    }
}
