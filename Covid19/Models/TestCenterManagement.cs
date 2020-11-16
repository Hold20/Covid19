using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Covid19
{
    [Table("Testcentermanagement")]
    class TestCenterManagement
    {
        [Key]
        public int PhoneNum { get; set; }

        public string Email { get; set; }
        public TestCenter testCenter { get; set; }
        public int CenterID { get; set; }

    }
}