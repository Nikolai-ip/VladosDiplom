using UnityEngine;

namespace DefaultNamespace
{
    public class EdgeDrawer:MonoBehaviour
    {
        EdgeContainer _edgeContainer;
        [SerializeField] private EdgesLineDrawer _lineDrawer;
        private void Start()
        {
            _edgeContainer = FindObjectOfType<EdgeContainer>();
            _edgeContainer.EdgeContainerChanged += OnEdgeCreated;
        }

        private void OnEdgeCreated((Dot, Dot) edge)
        {
            _lineDrawer.SetNewLine(edge.Item1.transform.position, edge.Item2.transform.position);
        }
    }
}