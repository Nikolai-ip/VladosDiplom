using UnityEngine;

public class DotFabric : MonoBehaviour
{
    private void Awake()
    {
        TextAsset textFile = Resources.Load<TextAsset>("Dots");
        if (textFile != null)
        {
            string fileContent = textFile.text;
            Debug.Log(fileContent); 
        }
        else
        {
            Debug.LogError("Файл Dot.txt не найден в папке Resources!");
        }
    }
}
