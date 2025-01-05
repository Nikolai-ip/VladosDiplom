using System.Collections.Generic;
using System.Linq;

public class TriangleFinder
{
    public List<(Dot, Dot, Dot)> FindTriangles(List<(Dot, Dot)> edges)
    {
        var triangles = new List<(Dot, Dot, Dot)>();

        for (int i = 0; i < edges.Count; i++)
        {
            for (int j = i + 1; j < edges.Count; j++)
            {
                var edge1 = edges[i];
                var edge2 = edges[j];
                
                Dot commonDot = FindCommonDot(edge1, edge2);
                if (commonDot == null)
                    continue;
                
                Dot first = edge1.Item1 == commonDot ? edge1.Item2 : edge1.Item1;
                Dot second = edge2.Item1 == commonDot ? edge2.Item2 : edge2.Item1;
                
                if (edges.Any(e => (e.Item1 == first && e.Item2 == second) || (e.Item1 == second && e.Item2 == first)))
                {
                    if (!triangles.Any(t => IsSameTriangle(t, (commonDot, first, second))))
                    {
                        triangles.Add((commonDot, first, second));
                    }
                }
            }
        }

        return triangles;
    }

    private Dot FindCommonDot((Dot, Dot) edge1, (Dot, Dot) edge2)
    {
        if (edge1.Item1 == edge2.Item1 || edge1.Item1 == edge2.Item2)
            return edge1.Item1;
        if (edge1.Item2 == edge2.Item1 || edge1.Item2 == edge2.Item2)
            return edge1.Item2;

        return null;
    }

    private bool IsSameTriangle((Dot, Dot, Dot) triangle1, (Dot, Dot, Dot) triangle2)
    {
        var set1 = new HashSet<Dot> { triangle1.Item1, triangle1.Item2, triangle1.Item3 };
        var set2 = new HashSet<Dot> { triangle2.Item1, triangle2.Item2, triangle2.Item3 };

        return set1.SetEquals(set2);
    }
}