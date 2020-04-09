using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace EmotionWEB.Models
{
    public class Picture
    {
        int id;
        string name;
        string path;
        public virtual ObservableCollection<Face> faces { get; set; }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
    }
}