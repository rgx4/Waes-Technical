using System;
using System.Collections.Generic;
using System.Text;

namespace WaesTechnical.Domain.Models
{
    public class GetResponse
    {
        public string Message { get; set; }
        public List<DifferencesResponse> Differences { get; set; }

        public GetResponse(string message, List<DifferencesResponse> differences)
        {
            Message = message;
            Differences = differences;
        }

        public GetResponse(string message)
        {
            Message = message;
        }

        public GetResponse() { }
       
    }
}



