using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DotLineDrawer : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private LineDrawer _lineDrawer;
        public Action<(Dot, Dot)> EdgeCreated;
        private Dot _firstDot;

        private void Start()
        {
            _inputController.FirstDotSelected += OnFirstDotSelected;
            _inputController.SecondDotSelected += OnSecondDotSelected;
        }

        private void Update()
        {
            if (_firstDot)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = _firstDot.transform.position.z;
                _lineDrawer.SetLine(_firstDot.transform.position, mousePos);
            }
        }

        private void OnDisable()
        {
            _inputController.FirstDotSelected -= OnFirstDotSelected;
            _inputController.SecondDotSelected -= OnSecondDotSelected;
        }

        private void OnFirstDotSelected(Dot dot)
        {
            if (dot == null)
            {
                _firstDot = null;
                _lineDrawer.SetLine(Vector3.zero, Vector3.zero);
            }
            else
            {
                _firstDot = dot;
            }
        }

        private void OnSecondDotSelected(Dot dot)
        {
            if (_firstDot != null && dot != null)
            {
                _lineDrawer.SetLine(_firstDot.transform.position, dot.transform.position);
                EdgeCreated.Invoke((_firstDot, dot));
                _firstDot = null;
            }
        }
    }
}