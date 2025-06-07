using UnityEngine;

namespace Game.Data
{
    public interface IModelBackground
    {
        public Sprite Sprite { get; }
    }

    public class BackgroundModel : XNodeModel, IModelBackground
    {
        [field: SerializeField]
        public Sprite Sprite { get; private set; }
    }
}
