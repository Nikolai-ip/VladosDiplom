using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineDrawer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
        _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        _lineRenderer.startColor = Color.red;
        _lineRenderer.endColor = Color.red;
    }
    
    public void SetLine(Vector3 startPoint, Vector3 endPoint)
    {
        _lineRenderer.SetPosition(0 , startPoint);
        _lineRenderer.SetPosition(1, endPoint);
    }
    
}