using Comet.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comet.Data.Sqlite.Models
{
    public class TestDevice : EntityBase
    {
        public string? Name { get; set; }
        public string? OSVersion { get; set; }
        public int AssignedTo { get; set; }


    }
}
