
using Raycasting;
using System.Drawing.Drawing2D;
using Vectors;
namespace WinFormsApp1;

public class NewRender
{
    public void Render(Monitor monitor, Player player, Graphics g, RayCast rayCast, char[,] map)
    {
        int sky = monitor.Center;

        int floor = monitor.Center / 2;

        var Rectangles = new Rectangle[monitor.Width];

        var rect = Rectangle.Empty;
       
        Draw(g, GroupPixels(new Rectangle[] { new Rectangle(0, 0, monitor.Width, sky) }), Color.WhiteSmoke);

        Draw(g, GroupPixels(new Rectangle[] { new Rectangle(0, monitor.Center, monitor.Width, monitor.Height) }), Color.Brown);

        for (int x = 0; x < monitor.Width; x++)
        {
            float rayAngle = GetRayAngle(monitor, player, x);

            var ray = new Ray(player.Position, rayAngle, 100);

            var rayCastHit = rayCast.ReleaseRay(new Ray(player.Position, rayAngle,100), map);

            Rectangles[x] = CreateRect(monitor, rayCastHit.Distance, x);

            
        }
        Draw(g, GroupPixels(Rectangles), Color.AntiqueWhite);
    }
    public Rectangle CreateRect(Monitor monitor, float distanceToWall, int x)
    {

        int wallHeight = GetWallHeight(monitor, distanceToWall);

        int min = monitor.Center - wallHeight / 2;

        int max = monitor.Center + wallHeight / 2;

        return new Rectangle(x, min, 1, max - min);
    }
    public GraphicsPath GroupPixels(params Rectangle[][] elements)
    {

        GraphicsPath polygon = new GraphicsPath();

        for (int i = 0; i < elements.Length; i++)
        {
            var array = elements[i];

            for (int j = 0; j < array.Length; j++)
            {
                polygon.AddRectangle(array[j]);
            }
        }
        return polygon;
    }
    private void Draw(Graphics g, GraphicsPath graphicsPath, Color color)
    {
        using (var brush = new SolidBrush(color))
        {
            g.FillPath(brush, graphicsPath);
        }
        graphicsPath.Dispose();
    }
    private int GetWallHeight(Monitor monitor, float distanceToWall)
    {
        return (int)(monitor.Height / distanceToWall);
    }
    private float GetRayAngle(Monitor monitor, Player player, int x)
    {
        return player.Angle + player.Fov / 2 - x * player.Fov / monitor.Width;
    }
}

public struct Player(Vector2 Position,float Angle, float Fov)
{
    public Vector2 Position = Position;

    public float Angle = Angle;

    public float Fov = Fov;
}
public struct Monitor(int Height, int Width)
{
    public int Width = Width;

    public int Height = Height;

    public int Center = Height / 2;
}
