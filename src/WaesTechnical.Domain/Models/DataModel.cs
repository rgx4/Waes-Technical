using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaesTechnical.Domain.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public string StringData { get; set; }
        public int DiffId { get; set; }
        public int Side { get; set; }

        public DataModel(int diffId, DataInput input, int side)
        {
            StringData = input.Data;
            Side = side;
            DiffId = diffId;
        }
    }
}

