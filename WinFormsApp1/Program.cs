using System;
using System.Drawing;
using System.Windows.Forms;

class PixelForm : Form
{
    Engine engine = new Engine();

    
    public PixelForm()
    {
        this.KeyPreview = true; 
        this.KeyDown += PixelForm_KeyDown; 
        this.Size = new Size(1920, 1080); 
        this.DoubleBuffered = true; 
    }

    // Îáðàáîòêà íàæàòèÿ êëàâèø
    private void PixelForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.W)
        {
            engine.SetPlayerPos();
        }
        if (e.KeyCode == Keys.Left)
        {
            engine.SetPlayerAngle(5.5f);
        }
        else if (e.KeyCode == Keys.Right)
        {
            engine.SetPlayerAngle(-5.5f);
        }

        this.Invalidate(); // Ïåðåðèñîâûâàåì ôîðìó ïîñëå èçìåíåíèÿ óãëà
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Game(e.Graphics);
        e.Dispose();
    }

    static void Main()
    {
        Application.Run(new PixelForm());
    }

    public void Game(Graphics g)
    {
        engine.Start(g, Size.Height, Size.Width);
    }
}
