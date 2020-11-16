using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Covid19
{
    class CitizenLocation
    {
        [Key]
        public string SSN { get; set; }

        public DateTime Date { get; set; }
        public Location location { get; set; }
        public Citizen citizen { get; set; }
        public string Addr { get; set; }

    }
}