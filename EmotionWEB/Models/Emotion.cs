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

        public virtual Face faces { get; set; }
        public EmotionEnum emotionType { get; set; }
        
        public int Id { get => id; set => id = value; }
        public float Score { get => score; set => score = value; }
        public int FaceId { get => faceId; set => faceId = value; }
       

    }
}