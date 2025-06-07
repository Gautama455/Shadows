using Game.Data;
using Game.View;
using XNode;

namespace Game.Controller
{
    public interface IControllerChoice : ICommand
    {
        public void OnCallBackView(Node node);
    }

    public class ChoicesController : IControllerChoice
    {
        public event ICommand.CompleteHandler Complete;

        private IViewChoice _view;
        private IModelChoices _model;

        public ChoicesController(IModelChoices model, IViewChoice view)
        {
            _model = model;
            _view = view;
        }

        public void Execute()
        {
            _view.ChoiceCallback += OnCallBackView;
            _view.Show(_model.Choices, _model.Nodes);
        }

        public void OnCallBackView(Node node)
        {
            _model.SetEndPort(node);
            _view.ChoiceCallback -= OnCallBackView;
            Complete?.Invoke();
        }
    }
}