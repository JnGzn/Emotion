using EmotionWEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmotionWEB.Data
{
    public class EmotionWEBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EmotionWEBContext() : base("name=EmotionWEBContext")
        {
        }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Face> Faces { get; set; }
        public DbSet<Emotion> Emotions { get; set; }
    }
}
