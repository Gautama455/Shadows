using UnityEngine;

namespace Game.Data
{
    public interface IModelMonologue
    {
        public string Name { get; }
        public string Text { get; }
    }

    public class MonologueModel : XNodeModel, IModelMonologue
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        [field: TextArea(5, 10)]
        public string Text { get; private set; }
    }
}