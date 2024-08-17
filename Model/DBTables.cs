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
        public int Submittal_ID { get; set; }

        public int Submittal_Number { get; set; }

        [ForeignKey("PROJECTS")]
        public int Project_ID { get; set; }

        public Project Project { get; set; }
    }

    [Table("CLIENTS")]
    public class Client
    {
        [Key]
        public int Client_ID { get; set; }

        public string Client_name { get; set; }
    }

    [Table("PROJECTS")]
    public class Project
    {
        [Key]
        public int Project_ID { get; set; }
        public string Project_Name { get; set; }
        public int Client_ID { get; set; }
        public Client Client { get; set; }
        public ICollection<Submittal> Submittals { get; set; }

    }

    [Table("SUBMITTAL_INFO")]
    public class SubmittalInfo
    {
        [Key]
        public int Submittal_Info_ID { get; set; }
        public int Submittal_ID { get; set; }
        public string Who_Prepared {  get; set; }
        public string Date {  get; set; }
        public string Filter { get; set; }
        public string Submittal_Title { get; set; }
        public Submittal Submittal { get; set; }

    }
}
