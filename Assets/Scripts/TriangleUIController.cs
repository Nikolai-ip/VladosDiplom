using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class TriangleUIController: MonoBehaviour
    {
        private EdgeContainer _edgeContainer;
        [SerializeField] private TextMeshProUGUI _textUI;
        private Canvas _canvas;
        private List<TextMeshProUGUI> _texts = new();
        private void Start()
        {
            _edgeContainer = FindObjectOfType<EdgeContainer>();
            _edgeContainer.TrianglesFound += OnTrianglesFound;
            _canvas = FindObjectOfType<Canvas>();
        }

        private void OnDisable()
        {
            _edgeContainer.TrianglesFound -= OnTrianglesFound;
        }

        private void OnTrianglesFound(IEnumerable<(Dot, Dot, Dot)> triangles)
        {
            int index = 0;
            DestroyAllTexts();
            foreach (var dots in triangles)
            {
                index++;
                Vector3 sum = (dots.Item1.transform.position + dots.Item2.transform.position+ dots.Item3.transform.position);
                Vector3 averagePos = sum / 3;
                var text = Instantiate(_textUI, _canvas.transform);
                text.text = $"{index}";
                text.gameObject.name = $"Triangle {index}";
                text.transform.localPosition = averagePos;
                _texts.Add(text);
            }
        }

        private void DestroyAllTexts()
        {
            foreach (var text in _texts)
            {
                Destroy(text.gameObject);
            }
            _texts.Clear();
        }
    }
}