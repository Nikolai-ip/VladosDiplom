namespace Resources
{
    public struct Vector3
    {
        public decimal X, Y, Z;

        public Vector3(decimal x, decimal y, decimal z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static explicit operator UnityEngine.Vector3(Vector3 v)
        {
            UnityEngine.Vector3 newVector = new UnityEngine.Vector3();
            newVector.x = (float)v.X;
            newVector.y = (float)v.Y;
            newVector.z = (float)v.Z;
            return newVector;
        }
        public static Vector3 operator -(Vector3 v, Vector3 n)
        {
            return new Vector3(v.X - n.X, v.Y - n.Y, v.Z - n.Z);
        }
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }
    }
}