using Euro.Shared.In;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Euro.API.Extensions
{
    public static class ErrorHandlerExtensions
    {
        public static Dictionary<string, string> errorCodes = new Dictionary<string, string>
        {
            { "InvalidEmail", "Email" },
            { "DuplicateEmail", "Email" },
            { "PasswordMismatch", "Password" },
            { "UserAlreadyHasPassword", "Password" },
            { "PasswordTooShort", "Password" },
            { "PasswordRequiresNonAlphanumeric", "Password" },
            { "PasswordRequiresDigit", "Password" },
            { "PasswordRequiresLower", "Password" },
            { "PasswordRequiresUpper", "Password" },
            {"PasswordRequiresUniqueChars", "Password" },
            { "InvalidUserName", "Email" },
            { "DuplicateUserName", "Email" }
        };

        public static List<ErrorApiModel> ParseErrors(this IEnumerable<IdentityError> errors)
        {
            var result = new List<ErrorApiModel>();

            foreach (var error in errors)
            {
                var code = error.Code;
                var description = error.Description;

                result.Add(new ErrorApiModel
                {
                    Code = errorCodes[code],
                    Description = description
                });
            }

            return result;
        }
    }
}