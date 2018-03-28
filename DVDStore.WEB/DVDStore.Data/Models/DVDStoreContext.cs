using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DVDStore.Data.Models
{
    public class DVDStoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DVDStoreContext() : base("name=DVDStoreContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<DVDStore.Data.Models.Actor> Actors { get; set; }
        public System.Data.Entity.DbSet<DVDStore.Data.Models.ActorsinMovies> ActorsinMovies { get; set; }
        public System.Data.Entity.DbSet<DVDStore.Data.Models.DVD> DVDs { get; set; }
        public System.Data.Entity.DbSet<DVDStore.Data.Models.Genres> Genres { get; set; }
        public System.Data.Entity.DbSet<DVDStore.Data.Models.Ratings> Ratings { get; set; }
        public System.Data.Entity.DbSet<DVDStore.Data.Models.SalesInfo> Sales { get; set; }

 

    }
}
