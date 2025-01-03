using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class EdgeContainer:MonoBehaviour
    {
        [SerializeField] DotLineDrawer dotLineDrawer;
        private List<(Dot, Dot)> _edges = new();
        public List<(Dot, Dot)> Edges => _edges;
        public event Action<(Dot, Dot)> EdgeContainerChanged;
        private TriangleFinder _triangleFinder = new();
        private void Start()
        {
            dotLineDrawer.EdgeCreated += OnEdgeCreated;
        }

        private void OnDisable()
        {
            dotLineDrawer.EdgeCreated -= OnEdgeCreated;
        }

        private void OnEdgeCreated((Dot, Dot) edge)
        {
            _edges.Add(edge);
            foreach (var triangle in _triangleFinder.FindTriangles(_edges))
            {
                Debug.Log(triangle);
            }
            EdgeContainerChanged?.Invoke(edge);
        }
    }
}