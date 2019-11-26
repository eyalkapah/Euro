using Euro.Domain.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.API.Base
{
    public class ApiResponse
    {
        public string ErrorMessage { get; set; }
        public RegisterCredentialsResultApiModel Response { get; internal set; }
    }
}