using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class DotUI:MonoBehaviour
    {
        private Dot _dot;
        [SerializeField] private TextMeshProUGUI _textPrefab;
        private Canvas _canvas;
        [SerializeField] private Vector2 _offset;
        private void Awake()
        {
            _canvas = FindObjectOfType<Canvas>();
            _dot = GetComponent<Dot>();
            _dot.Initialized += OnInitialized;
        }

        private void OnInitialized(Dot dot)
        {
            var text = Instantiate(_textPrefab, _canvas.transform);
            text.transform.position = dot.transform.localPosition + (Vector3)_offset;
            text.text = $"T. {dot.name}";
            text.gameObject.name = $"Dot {dot.name}";
        }
    }
}