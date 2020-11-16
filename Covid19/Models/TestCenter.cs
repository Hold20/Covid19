using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Covid19
{
    [Table("Testcenter")]
    class TestCenter
    {
        [Key]
        public int CenterID { get; set; }

        public string Hours { get; set; }
        public List<TestedAt> testedAts { get; set; }
        public TestCenterManagement testCenterMangement { get; set; }
        public Municipality municipality { get; set; }
        public int MunicipalityID { get; set; }


    }
}