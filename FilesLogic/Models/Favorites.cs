namespace FilesLogic.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using FilesLogic;

    public class Favorites
    {
        public Guid ID { get; set; }
        public int Kategorie { get; set; }
    }
}
