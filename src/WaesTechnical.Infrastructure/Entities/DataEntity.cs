using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WaesTechnical.Infrastructure.Entities
{
    public class DataEntity
    {
        [Key]
        public int Id { get; set; }
        public int DiffId { get; set; }
        public string StringData { get; set; }
        public int Side { get; set; }
    }
}
