using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaesTechnical.Domain.Models
{
    public class CreateResponse
    {
        public CreateResponse(string message)
        {
            Message = message;
        }

        [JsonProperty]
        public string Message { get; set; }
    }
}
