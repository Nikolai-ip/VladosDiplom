using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class DotUI:MonoBehaviour
    {
        private Dot _dot;
        [SerializeField] private TextMeshProUGUI _textPrefab;
        private Canvas _canvas;
        private void Awake()
        {
            _canvas = FindObjectOfType<Canvas>();
            _dot = GetComponent<Dot>();
            _dot.Initialized += OnInitialized;
        }

        private void OnInitialized(Dot dot)
        {
            var text = Instantiate(_textPrefab, _canvas.transform);
            text.transform.position = dot.transform.localPosition;
            text.text = dot.name;
        }
    }
}