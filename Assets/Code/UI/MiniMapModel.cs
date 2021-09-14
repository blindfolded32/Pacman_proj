using UnityEngine;
 public class MiniMapModel : IMinimapModel
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public RenderTexture Texture { get; set; }
      
        public MiniMapModel(RenderTexture texture, Camera camera)
        {
            Texture = texture;
          
            camera.targetTexture = Texture;
            camera.depth = -5;
        }


    }
