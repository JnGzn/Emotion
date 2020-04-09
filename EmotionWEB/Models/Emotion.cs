using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmotionWEB.Models
{
    public class Emotion
    {
        int id;
        float score;
        int faceId;
        EmotionEnum emotionType;
        public virtual Face faces { get; set; }
        
        public int Id { get => id; set => id = value; }
        public float Score { get => score; set => score = value; }
        internal EmotionEnum EmotionType { get => emotionType; set => emotionType = value; }
    }
}