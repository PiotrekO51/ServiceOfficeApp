using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOfficeApp.Data.Entities
{
     public class Installer: EntitiBase
    {
        public string? Authorization { get; set; }
        public DateTime Date { get; set; }

    }
}
