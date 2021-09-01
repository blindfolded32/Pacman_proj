
    using UnityEngine;

    public interface IMinimapModel
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public RenderTexture Texture { get; set; }
    }
