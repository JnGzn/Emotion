using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace EmotionWEB.Models
{
    public class Face
    {

        int id;
        int pictureId;
        public virtual Picture picture { get; set; }
        public virtual ObservableCollection<Emotion> emotions{ get; set; }

        #region cordenadas
        int x;
        int y;
        int width;
        int height;
        #endregion

        public int Id { get => id; set => id = value; }
        public int PictureId { get => pictureId; set => pictureId = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
    }
}