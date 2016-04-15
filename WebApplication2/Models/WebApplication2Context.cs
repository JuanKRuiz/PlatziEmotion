using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class WebApplication2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public WebApplication2Context() : base("name=AzureDB")
        //base("name=WebApplication2Context")
        {
            Database.SetInitializer<WebApplication2Context>(
                new DropCreateDatabaseIfModelChanges<WebApplication2Context>()
                );
        }

        public System.Data.Entity.DbSet<WebApplication2.Models.EmoPicture> EmoPictures { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.EmoFace> EmoFaces { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.EmoEmotion> EmoEmotions { get; set; }
    }
}
