using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = Resources.Vector3;

public class DotsLoader : MonoBehaviour
{
    [SerializeField] private Dot _dotPrefab;
    [SerializeField] private Transform _dotContainer;
    [SerializeField] private Material _dotMaterial;
    [SerializeField] private Material _refetenceDotMaterial;
    

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        var lines = File.ReadAllLines(FilePath.DOTS_PATH);
        var dotPositions = GetDotPositions(lines);
        var referenceDot = Instantiate(_dotPrefab,_dotContainer);
        referenceDot.name = "ОП";
        referenceDot.Init(dotPositions[0]);
        referenceDot.GetComponent<Renderer>().material = _refetenceDotMaterial;
        for (var i = 1; i < dotPositions.Count; i++)
        {
            var dotPos = dotPositions[i];
            var dot = Instantiate(_dotPrefab,_dotContainer);
            dot.name = i.ToString();
            dot.Init(dotPos, referenceDot);
            dot.GetComponent<Renderer>().material = _dotMaterial;
        }
    }
    private List<Vector3> GetDotPositions(string[] lines)
    {
        List<Vector3> result = new List<Vector3>();
        foreach (var line in lines)
        { 
            var formatLine = line.Replace(",", ".");
            var positions = formatLine.Split(' ');
            if (decimal.TryParse(positions[0], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal x) &&
                decimal.TryParse(positions[1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal y) &&
                decimal.TryParse(positions[2], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal z))
            {
                result.Add(new Vector3(x, y, z));
            }
            else
            {
                Debug.LogError($"Could not parse line: {line}");
            }
        }
        return result;
    }
}
