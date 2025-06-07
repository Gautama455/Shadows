using XNode;

namespace Game.View
{
    public interface IViewChoice
    {
        public delegate void ChoiceHandler(Node nextNode);
        public event ChoiceHandler ChoiceCallback;
        public void Show(string[] texts, Node[] nodes);
        public void Hide();
    }
}
