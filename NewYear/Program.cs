using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Diagnostics;

public interface ISmallPaint
{
    void Paint(Graphics g);
}
class Snow : ISmallPaint
{
    public void Paint(Graphics g)
    {
        Random rand = new Random();
        for (int i = 0; i < 350; i++)
        {
            Random rnd = new Random();
            int x = rnd.Next(0, 1000);
            int y = rnd.Next(0, 500);
            Pen pen = new Pen(Color.White, 2);
            g.DrawEllipse(pen, x, y, 2, 2);
        }
    }
}  

class Tree : ISmallPaint
{
    public void Paint(Graphics g)
    {
        g.FillClosedCurve(Brushes.SaddleBrown, new Point[] { new Point(360, 437), new Point(426, 300), new Point(470, 437) }); 
        g.FillClosedCurve(Brushes.ForestGreen, new Point[] { new Point(290, 237), new Point(426, 120), new Point(544, 237) });
        g.FillClosedCurve(Brushes.ForestGreen, new Point[] { new Point(250, 337), new Point(426, 200), new Point(580, 337) });

    }

}
class DedushkaMoroz : ISmallPaint
{
    public void Paint(Graphics g)
    {
        g.FillEllipse(Brushes.Red, 480, 437, 50, 50);
        g.FillEllipse(Brushes.WhiteSmoke, 480, 417, 45, 45);
    }

}
class Gift : ISmallPaint
{
    public void Paint(Graphics g)
    {
        g.FillRectangle(Brushes.Red, 350, 437, 40, 40);
    }

}
class Snowman : ISmallPaint
{
    public void Paint(Graphics g)
    {
        Pen pen = new Pen(Color.White, 30);
        g.DrawEllipse(pen, 300, 437, 30, 30);
        Pen pen2 = new Pen(Color.White, 25);
        g.DrawEllipse(pen2, 303, 407, 25, 25);
    }

}
class NewYearPaint
{
    Graphics graphics;
    public NewYearPaint()
    {
        graphics = Graphics.FromHwnd(Process.GetCurrentProcess().MainWindowHandle);
    }
    private List<ISmallPaint> paintObjects = new List<ISmallPaint>();

    public void Create()
    {
        foreach (var paintObject in paintObjects)
        {
            paintObject.Paint(graphics);
        }
    }

    public void AddPaintObject(ISmallPaint newPaintObject)
    {
        paintObjects.Add(newPaintObject);
    }
}
class Program
{
    static void Main(string[] args)
    {
        NewYearPaint newYearPaint = new NewYearPaint();
        newYearPaint.AddPaintObject(new Snow());
        newYearPaint.AddPaintObject(new Tree());
        newYearPaint.AddPaintObject(new DedushkaMoroz());
        newYearPaint.AddPaintObject(new Gift());
        newYearPaint.AddPaintObject(new Snowman());

        newYearPaint.Create();
    }
}