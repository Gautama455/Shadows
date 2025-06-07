using UnityEngine;
using XNode;

namespace Game.Data
{
    public abstract class XNodeModel : Node
    {
        [Input]
        public bool StartPort;

        [Output]
        public bool EndPort;
    }
}
