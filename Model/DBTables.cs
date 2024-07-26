using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepareSubmittalTool.Model
{
    [Table("SUBMITTAL")]
    public class Submittal
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }
    }

    [Table("CLIENT")]
    public class Client
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
    }

    [Table("PROJECT")]
    public class Project
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
