using UnityEngine;
public class EdgesLineDrawer : MonoBehaviour
{
    [SerializeField] private LineDrawer _lineRendererPrefab;
    
    public void SetNewLine(Vector3 startPoint, Vector3 endPoint)
    {
        var line = Instantiate(_lineRendererPrefab, transform);
        line.SetLine(startPoint, endPoint);
    }
}