using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class Skin : Upgrade<SkinChanger>
    {
        public Color MainColor;
        public Color DotsColor;
        public Color GlassColor;
        
        public override void Apply(SkinChanger element)
        {
            element.UpdateSkin(this);
        }
    }
}