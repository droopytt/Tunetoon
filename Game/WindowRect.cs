namespace Tunetoon.Game;

public class WindowRect {
    private int x, y, width, height;

    public WindowRect(int x, int y, int width, int height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public int X => x;

    public int Y => y;

    public int Width => width;

    public int Height => height;

    public override string ToString()
    {
        return "TopLeftCorner: (" + X + ", " + Y + ") - WidthHeight: (" + Width + ", " + Height + ")";
    }
}