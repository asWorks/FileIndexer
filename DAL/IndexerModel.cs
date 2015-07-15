namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using FilesLogic.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public class IndexerModel : DbContext
    {
        // Your context has been configured to use a 'IndexerModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.IndexerModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'IndexerModel' 
        // connection string in the application configuration file.
        public IndexerModel()
            : base("name=IndexerModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Szenes> Szenes { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Qualities> Qualities { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<Protocoll> Protocoll { get; set; }

   
    }
}