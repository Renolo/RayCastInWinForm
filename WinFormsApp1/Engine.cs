
using Raycasting;
using Vectors;
using WinFormsApp1;
using Monitor = WinFormsApp1.Monitor;
public class Engine
{
    private char[,] map = {
        {'#','#','#','#','#','#','#','#','#'},
        {'#',' ',' ','#',' ',' ','#',' ','#'},
        {'#',' ',' ','#',' ',' ','#',' ','#'},
        {'#',' ','#',' ',' ',' ',' ',' ','#'},
        {'#',' ',' ','#',' ',' ','#',' ','#'},
        {'#',' ',' ','#','#',' ',' ',' ','#'},
        {'#',' ','#','#','#',' ','#',' ','#'},
        {'#',' ',' ',' ',' ','#','#',' ','#'},
        {'#',' ',' ','#',' ','#',' ',' ','#'},
        {'#',' ',' ','#',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ','#',' ','#',' ',' ','#'},
        {'#','#','#','#',' ',' ',' ',' ','#'},
        {'#',' ',' ','#',' ','#',' ',' ','#'},
        {'#','#','#','#','#','#','#','#','#'}
    };

    private Bitmap Buffer;
    private int Height; 
    private int Width;
    private RayCast _raycast = new RayCast();
    private float _fov = 90; 
    public float _playerAngle = 0;
    private Vector2 _playerPosition = new Vector2(5, 1);
    PlayerController playerController = new PlayerController();
    private NewRender renderGraphics = new NewRender();




    public void Start(Graphics g, int Height, int Width)
    {
        this.Height = Height;
        this.Width = Width;
        ScreenInit();
        Game(g);
    }
    public void ScreenInit()
    {
        Buffer = new Bitmap(Width, Height);
    }
    public void Game(Graphics g)
    {
        renderGraphics.Render(new Monitor(Height,Width),new Player(_playerPosition,_playerAngle,_fov),g,_raycast,map);
    }

    public void SetPlayerAngle(float value)
    {

        _playerAngle += value;

        if (_playerAngle > 360 || _playerAngle < -360)
        {
            _playerAngle = 0;
        }
        
    }
    public void SetPlayerPos()
    {
        var cal = new Thread(() =>
        {
            var newX = _playerPosition.X += (float)Math.Cos(_playerAngle * Math.PI / 180) * 0.2f;

            var newY = _playerPosition.Y += (float)Math.Sin(_playerAngle * Math.PI / 180) * 0.2f;

            _playerPosition = new Vector2(newX, newY);
        });
        cal.Start();
    }

    public void LogInConsole()
    {
     
    }

  
    
   
}