using UnityEngine.UI;
using UnityEngine;
using TMPro;
using XNode;

namespace Game.View
{
    public class ChoicesButton : MonoBehaviour, IChoiceButton
    {
        [field: SerializeField]
        public Button Button { get; private set; }

        [field: SerializeField]
        public TextMeshProUGUI Text { get; private set; }

        public Node Node { get; set; }
    }
}
