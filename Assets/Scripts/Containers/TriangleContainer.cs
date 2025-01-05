using System;
using System.Collections.Generic;
using DefaultNamespace.Data;
using DefaultNamespace.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class TriangleContainer:MonoBehaviour
    {
        private EdgeContainer _edgeContainer;
        [SerializeField] private List<Triangle> _triangles = new();
        private TriangleSaver _saver = new();
        private void Start()
        {
            _edgeContainer = FindObjectOfType<EdgeContainer>();
            _edgeContainer.TrianglesFound += OnTrianglesFound;
        }

        private void OnDisable()
        {
            _edgeContainer.TrianglesFound -= OnTrianglesFound;
        }

        private void OnTrianglesFound(IEnumerable<(Dot, Dot, Dot)> triangles)
        {
            _triangles.Clear();
            int triangleIndex = 0;
            foreach (var dots in triangles)
            {
                triangleIndex++;
                var triangle = new Triangle(dots.Item1, dots.Item2, dots.Item3,triangleIndex);
                _triangles.Add(triangle);
            }
            _saver.SaveTriangles(_triangles);
        }
        
    }
}