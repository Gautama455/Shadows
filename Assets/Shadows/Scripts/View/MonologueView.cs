using TMPro;
using UnityEngine;

namespace Game.View
{
    public interface IViewMonologue
    {
        public delegate void ViewDialoqueHandler();
        public event ViewDialoqueHandler OnClick;
        public void Show(string name, string text);
        public void OnCallBack();
        public void Hide();
    }


    public class MonologueView : MonoBehaviour, IViewMonologue
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _text;

        public event IViewMonologue.ViewDialoqueHandler OnClick;

        public void Show(string name, string text)
        {
            _name.SetText(name);
            _text.SetText(text);
            _canvas.gameObject.SetActive(true);
        }

        public void OnCallBack()
        {
            OnClick?.Invoke();
        }

        public void Hide()
        {
            _canvas.gameObject.SetActive(false);
        }
    }
}
