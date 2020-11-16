using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Covid19
{
    [Table("Nation")]
    class Nation
    {
        [Key]
        public string NationName { get; set; }

        public List<Municipality> municipalities { get; set; }
    }
}