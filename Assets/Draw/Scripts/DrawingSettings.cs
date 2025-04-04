using UnityEngine;

public class DrawingSettings : MonoBehaviour
{
    public static bool isCursorOverUI = false;
    public float Transparency = 1f;

    // Changing pen settings is easy as changing the static properties Drawable.Pen_Colour and Drawable.Pen_Width
    public void SetMarkerColour(Color new_color)
    {
        //Drawable.Pen_Colour = new_color;
    }

    // new_width is radius in pixels
    public void SetMarkerWidth(int new_width)
    {
        Drawable_.Pen_Width = new_width;
    }

    public void SetMarkerWidth(float new_width)
    {
        SetMarkerWidth((int)new_width);
    }

    public void SetTransparency(float amount)
    {
        Transparency = amount;
        // Color c = Drawable.Pen_Colour;
        // c.a = amount;
        // Drawable.Pen_Colour = c;
    }


    // Call these these to change the pen settings
    public void SetPenRed()
    {
        Color c = Color.red;
        c.a = Transparency;
        SetMarkerColour(c);
        Drawable_.drawable.SetPenBrush();
    }

    public void SetPenGreen()
    {
        Color c = Color.green;
        c.a = Transparency;
        SetMarkerColour(c);
        Drawable_.drawable.SetPenBrush();
    }

    public void SetPenBlue()
    {
        Color c = Color.blue;
        c.a = Transparency;
        SetMarkerColour(c);
        Drawable_.drawable.SetPenBrush();
    }

    public void SetEraser()
    {
        SetMarkerColour(new Color(255f, 255f, 255f, 0f));
    }

    public void PartialSetEraser()
    {
        SetMarkerColour(new Color(255f, 255f, 255f, 0.5f));
    }

    public void SetFillBrush()
    {
        Drawable_.drawable.SetFillBrush();
    }
}