using Microsoft.Maui.Graphics;
using System;
using Font = Microsoft.Maui.Graphics.Font;

namespace ControlGallery.Drawables
{
    public class GraphicsDrawable : IDrawable
    {
	    private readonly Font _font;
	    private readonly AutoResetEvent _event;

	    public GraphicsDrawable()
	    {
			_font = new Font(Font.Default.Name, 60, FontStyleType.Normal);
			_event = new AutoResetEvent(false);
	    }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeLineCap = LineCap.Round;
            canvas.FillColor = Colors.Gray;

            // Translation and scaling
            canvas.Translate(dirtyRect.Center.X, dirtyRect.Center.Y);
            float scale = Math.Min(dirtyRect.Width / 200f, dirtyRect.Height / 200f);
            canvas.Scale(scale, scale);

            // Hour and minute marks
            for (int angle = 0; angle < 360; angle += 6)
            {
                canvas.FillCircle(0, -90, angle % 30 == 0 ? 4 : 2);
                canvas.Rotate(6);
            }

            DateTime now = DateTime.Now;

            // Hour hand
            canvas.StrokeSize = 20;
            canvas.SaveState();
            canvas.Rotate(30 * now.Hour + now.Minute / 2f);
            canvas.DrawLine(0, 0, 0, -50);
            canvas.RestoreState();

            // Minute hand
            canvas.StrokeSize = 10;
            canvas.SaveState();
            canvas.Rotate(6 * now.Minute + now.Second / 10f);
            canvas.DrawLine(0, 0, 0, -70);
            canvas.RestoreState();

            // Second hand
            canvas.StrokeSize = 2;
            canvas.SaveState();
            canvas.Rotate(6 * now.Second);
            canvas.DrawLine(0, 10, 0, -80);
            canvas.RestoreState();
            canvas.ResetState();

            var rect = new Rect(0, 0, 200, 40);
            canvas.Translate(0, 0);
            canvas.FillColor = Colors.White;
            canvas.FillRectangle(rect);
            canvas.Font = _font;
            canvas.FontSize = 20;
            canvas.DrawString($"{now:hh:mm:ss.fff}", rect, HorizontalAlignment.Left, VerticalAlignment.Center);
            _event.WaitOne(500);
        }
    }
}