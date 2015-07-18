using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesLogic.Models
{
    public class Files
    {

        [Key]
        public Guid FileID { get; set; }


        public string Uri { get; set; }
        public long size { get; set; }
        public DateTime Date { get; set; }
        public string strDate { get; set; }
        public long FileTime { get; set; }

        public Guid SzenesID { get; set; }
        public virtual Szenes Szene { get; set; }
    }
}
