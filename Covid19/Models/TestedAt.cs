using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Covid19
{
    class TestedAt
    {
        [Key]
        public string SSN { get; set; }

        public string Status { get; set; }
        public DateTime Date { get; set; }
        public bool Result { get; set; }
        public Citizen citizen { get; set; }
        public TestCenter testCenter { get; set; }
        public int CenterID { get; set; }

    }
}