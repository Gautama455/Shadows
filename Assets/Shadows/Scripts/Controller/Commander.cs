using Game.Data;
using Game.View;
using UnityEngine;
using XNode;

namespace Game.Controller
{
    public class Commander : MonoBehaviour
    {
        [SerializeField] private NodeGraph _graph;
        [SerializeField] private MonologueView _monologueView;
        [SerializeField] private BackgroundView _backgroundView;
        [SerializeField] private ChoicesView _choicesView;

        [SerializeField] private SaveController _saveController;

        private (ICommand Command, Node Node) _curent;
        private (ICommand, Node) Packing(Node node)
        {
            (ICommand command, Node node) result;

            result.node = node;

            result.command = node switch
            {
                IModelMonologue dialogue => new MonologueController(dialogue, _monologueView),
                IModelBackground background => new BackgroundController(background, _backgroundView),
                IModelChoices choice => new ChoicesController(choice, _choicesView),
                _ => null
            };

            return result;
        }

        private void Next()
        {
            _curent.Command.Complete -= Next;
            NodePort port = _curent.Node.GetPort("EndPort").Connection;

            if (port == null) return;

            _curent = Packing(port.node);
            _saveController.SetCurrentNode(port.node);
            _curent.Command.Complete += Next;
            _curent.Command.Execute();

        }

        private void Start()
        {
            _curent = Packing(_graph.nodes[0]);
            _saveController.SetNodeGraph(_graph);
            _curent.Command.Complete += Next;
            _curent.Command.Execute();
        }
    }
}