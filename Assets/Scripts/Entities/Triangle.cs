using System;

namespace DefaultNamespace.Entities
{
    [Serializable]
    public class Triangle
    {
        public Dot A { get; private set; }
        public Dot B { get; private set; }
        public Dot C { get; private set; }
        public int Id { get; private set; }
        public Triangle(Dot a, Dot b, Dot c, int id)
        {
            A = a;
            B = b;
            C = c;
            Id = id;
        }

        public override string ToString()
        {
            return $"{Id} {A.GetPosition().ToString()} {B.GetPosition().ToString()} {C.GetPosition().ToString()}";
        }
    }
}