using UnityEngine;

public static class FilePath
{
    private static string ROOT_PATH = Application.dataPath;
    public static string DOTS_PATH = ROOT_PATH + @"/Resources/Dots.txt";
    public static string TRIANGLES_PATH = ROOT_PATH + @"/Resources/Triangles.txt";
}