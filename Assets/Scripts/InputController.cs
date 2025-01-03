using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
	public event Action<Dot> FirstDotSelected;
	public event Action<Dot> SecondDotSelected;

	private Dot _firstDot;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out var hit))
			{
				if (hit.collider.TryGetComponent(out Dot dot)) 
				{
					if (_firstDot == null)
					{
						_firstDot = dot;
						FirstDotSelected?.Invoke(dot);
					}
					else if (_firstDot != dot)
					{
						SecondDotSelected?.Invoke(dot);
						_firstDot = null;
					}
				}
			}
			else
			{
				ResetSelection();
			}
		}
	}

	private void ResetSelection()
	{
		_firstDot = null;
		FirstDotSelected?.Invoke(null);
	}
}
