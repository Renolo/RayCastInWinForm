

namespace Vectors
{
    public struct Vector2
    {
        public float X;
        public float Y;
        
        public Vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
            
        }
        public static Vector2 operator +(Vector2 vector, Vector2 other) => new Vector2(vector.X + other.X, vector.Y + other.Y);

        public static Vector2 operator -(Vector2 vector, Vector2 other) => new Vector2(vector.X - other.X, vector.Y - other.Y);

        public static Vector2 operator *(Vector2 vector, Vector2 other) => new Vector2(vector.X * other.X, vector.Y * other.Y);

    }
    
}
