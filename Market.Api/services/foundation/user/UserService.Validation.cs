﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Users;
using Market.Api.Models.Foundation.Users.exceptions;

namespace Market.Api.services.foundation.user
{
    public partial class UserService
    {
        private void ValidateUserOnAdd(Users users)
        {
            ValidateUserNotNull(users);

            Validate(
                (Rule: IsInvalid(users.Id), Parameter: nameof(Users.Id)),
                (Rule: IsInvalid(users.Name), Parameter: nameof(Users.Name)),
                (Rule: IsInvalid(users.Email), Parameter: nameof(Users.Email))
                );
        }

        private void ValidateUserNotNull(Users users)
        {
            if (users is null)
            {
                throw new NullUserException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };


        private static void Validate(params (dynamic Rule, string Parametr)[] validations)
        {
            var invalidUserException = new InvalidUserException();

            foreach ((dynamic rule, string parametr) in validations)
            {
                if (rule.Condition)
                {
                    invalidUserException.UpsertDataList(
                        key: parametr,
                        value: rule.Message);
                }
            }

            invalidUserException.ThrowIfContainsErrors();
        }
    }
};
