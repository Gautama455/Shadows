using UnityEngine.UI;
using TMPro;
using XNode;

namespace Game.View
{
    public interface IChoiceButton
    {
        public Button Button { get; }
        public TextMeshProUGUI Text { get; }
        public Node Node { get; set; }
    }
}
