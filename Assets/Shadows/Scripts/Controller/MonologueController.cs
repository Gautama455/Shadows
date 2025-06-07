using Game.Data;
using Game.View;

namespace Game.Controller

{
    public interface IControllerMonologue : ICommand { }

    public class MonologueController : IControllerMonologue
    {
        public event ICommand.CompleteHandler Complete;

        private IModelMonologue _model;
        private IViewMonologue _view;

        public MonologueController(IModelMonologue model, IViewMonologue view)
        {
            _model = model;
            _view = view;
        }

        public void Execute()
        {
            _view.OnClick += OnCallBackView;
            _view.Show(_model.Name, _model.Text);
        }

        private void OnCallBackView()
        {
            _view.OnClick -= OnCallBackView;
            Complete?.Invoke();
        }
    }
}