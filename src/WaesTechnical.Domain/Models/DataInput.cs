using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WaesTechnical.Domain.Models
{
    public class DataInput
    {
        [Required]
        public string Data { get; set; }
    }
}
