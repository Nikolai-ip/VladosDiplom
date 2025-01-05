using System.Collections.Generic;
using System.IO;
using System.Text;
using DefaultNamespace.Entities;

namespace DefaultNamespace.Data
{
    public class TriangleSaver
    {
        public void SaveTriangles(List<Triangle> triangles)
        {
            File.WriteAllText(FilePath.TRIANGLES_PATH, string.Empty);
            StringBuilder fileContent = new();
            foreach (var triangle in triangles)
            {
                fileContent.AppendLine(triangle.ToString());
            }
            File.WriteAllText(FilePath.TRIANGLES_PATH, fileContent.ToString());
        }
    }
}