using UnityEngine;
using XNode;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    private NodeGraph _graph;
    private Node _currentNode;
    private int _currentNodeID;
    private string _sceneName;

    public void SetCurrentNode(Node node)
    {
        _currentNode = node;
        _currentNodeID = node.GetInstanceID();
        _sceneName = SceneManager.GetActiveScene().name;
        Debug.Log($"»гра сохранена: —цена {_sceneName}, нода {_currentNode.name}, ID ноды {_currentNodeID}");
    }

    public void SetNodeGraph(NodeGraph graph)
    {
        _graph = graph;
    }

    private void Start()
    {
        if (SaveSystem.Load(out var saveData))
        {
            _currentNode = _graph.nodes.Find(n => n.GetInstanceID() == saveData.CurrentNodeID);
        }
        else
        {
            _currentNode = _graph.nodes[0]; // стартовый узел
        }
    }

    public void SaveGame()
    {
        SaveSystem.Save(_sceneName,_currentNode);
    }
}
