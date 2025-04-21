using Vectors;

namespace Raycasting
{
    public class RayCast
    {
        
        public RayCastHit ReleaseRay(Ray ray,char[,] map)
        {
            bool isHit = false;

            float distance = 0;

            float rayX = (float)Math.Cos(DegreesInRadian(ray.Angle));

            float rayY = (float)Math.Sin(DegreesInRadian(ray.Angle));

            while (distance < ray.MaxDistance && isHit == false)
            {
                distance += 0.01f;

                var X = CalculateRayPosition(rayX, ray.Position.X, distance);

                var Y = CalculateRayPosition(rayY, ray.Position.Y, distance);

                if (X < 0 || Y < 0 || X >= ray.MaxDistance || Y >= ray.MaxDistance)
                {
                    isHit = true;
                    distance = ray.MaxDistance;
                }
                else if (map[X, Y] == '#')
                {
                    isHit = true;
                }
            }

            return new RayCastHit(isHit,distance);
        }


        private float DegreesInRadian(float Angle)
        {
            return (float)(Angle * Math.PI / 180);
        }
        private int CalculateRayPosition(float rayPosition, float position, float currentDistance)
        {
            return (int)(position + rayPosition * currentDistance);
        }
    }
    
}

public struct Ray(Vector2 position, float angle, int maxDistance)
{
    public Vector2 Position = position;

    public float Angle = angle;

    public int MaxDistance = maxDistance;
}

public struct RayCastHit(bool IsHit, float Distance)
{
    public bool IsHit = IsHit;

    public float Distance = Distance;
}
