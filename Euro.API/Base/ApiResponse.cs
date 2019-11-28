using Euro.Domain.ApiModels;
using System.Collections.Generic;

namespace Euro.API.Base
{
    public class ApiResponse
    {
        public List<ErrorApiModel> Errors { get; set; }
        public bool IsSucceeded { get; internal set; }
        public RegisterCredentialsResultApiModel Response { get; internal set; }
    }
}