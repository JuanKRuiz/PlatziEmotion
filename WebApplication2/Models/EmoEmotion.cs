using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EmoEmotion
    {
        public int Id { get; set; }
        public EmoEmotionEnum EmotionType { get; set; }
        public float Score { get; set; }


        public int EmoFaceId { get; set; }

        public virtual EmoFace Face { get; set; }
    }
}
