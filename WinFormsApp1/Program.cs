using System;
using System.Drawing;
using System.Windows.Forms;

class PixelForm : Form
{
    Engine engine = new Engine();

    // Исправлено: конструктор должен иметь то же имя, что и класс, и не иметь возвращаемого типа
    public PixelForm()
    {
        this.KeyPreview = true; // Форма будет получать события клавиатуры
        this.KeyDown += PixelForm_KeyDown; // Подписываемся на событие
        this.Size = new Size(1920, 1080); // Перенесено из OnPaint в конструктор
        this.DoubleBuffered = true; // Добавлено для устранения мерцания
    }

    // Обработка нажатия клавиш
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

        this.Invalidate(); // Перерисовываем форму после изменения угла
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