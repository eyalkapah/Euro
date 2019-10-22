﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Domain.ApiModels
{
    public class GroupApiModel
    {
        public int GroupId { get; set; }

        public string Name { get; set; }
    }
}