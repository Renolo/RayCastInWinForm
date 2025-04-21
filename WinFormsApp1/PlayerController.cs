namespace WinFormsApp1;
using Vectors;
public class PlayerController
{
    public void Controller(Vector2 playerPosition,float playerAngle,Engine engine)
    {
        engine.LogInConsole();

        var key = Console.ReadKey();

        if (key.Key == ConsoleKey.W)
        {
            var newX = playerPosition.X += (float)Math.Cos(playerAngle * Math.PI / 180) * 0.2f;

            var newY = playerPosition.Y += (float)Math.Sin(playerAngle * Math.PI / 180) * 0.2f;

            playerPosition = new Vector2(newX, newY);
        }



        if (key.Key == ConsoleKey.LeftArrow)
        {
            engine.SetPlayerAngle(5f);
        }
        if (key.Key == ConsoleKey.RightArrow)
        {
            engine.SetPlayerAngle(-5f);
        }

    }

}