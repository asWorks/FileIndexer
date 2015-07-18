namespace FilesLogic.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using FilesLogic;
    using System.IO;
    using System.ComponentModel.DataAnnotations.Schema;
    using Services;
    using System.Collections.Generic;



    public class Szenes : BaseTypes.BasicModel
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public int Actress { get; set; }
        public int Series { get; set; }
        public int Region { get; set; }
        public int Kategorie { get; set; }
        public int Quality { get; set; }
        public string Remark { get; set; }

        public string FileNameOnly { get; set; }
        public virtual List<Files> files { get; set; }

        public Szenes()
        {
            files = new List<Files>();
        }



    }
}
