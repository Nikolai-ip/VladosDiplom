using System;
using System.Collections.Generic;
using DefaultNamespace.Entities;
using Unity.VisualScripting;
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
        public event Action<IEnumerable<(Dot, Dot, Dot)>> TrianglesFound;
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
            var triangles = _triangleFinder.FindTriangles(_edges);
            if (triangles.Count > 0)TrianglesFound?.Invoke(triangles);

            EdgeContainerChanged?.Invoke(edge);
        }
    }
}