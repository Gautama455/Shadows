using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Game.View
{

    public class ChoicesView : MonoBehaviour, IViewChoice
    {
        [SerializeField] private ChoicesButton _prefab;
        [SerializeField] private Transform[] _positions;

        public event IViewChoice.ChoiceHandler ChoiceCallback;
        private List<IChoiceButton> _buttons;

        public void Show(string[] texts, Node[] nodes)
        {
            _buttons ??= new List<IChoiceButton>(nodes.Length);

            for (int i = 0; i < nodes.Length; i++)
            {
                IChoiceButton button = GameObject.Instantiate(_prefab, _positions[i]); 
                button.Text.SetText(texts[i]);
                button.Node = nodes[i];
                button.Button.onClick.AddListener(() => OnCallback(button));
                _buttons.Add(button);
            }
        }

        private void OnCallback(IChoiceButton button)
        {
            ChoiceCallback?.Invoke(button.Node);
            Hide();
        }

        public void Hide()
        {
            _buttons.ForEach(Button => Destroy(Button.Button.gameObject));
            _buttons.Clear();
        }

    }
}
