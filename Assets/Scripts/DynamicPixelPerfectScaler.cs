using UnityEngine;

public class PixelPerfectAdjuster : MonoBehaviour
{
    private const int BASE_RESOLUTION_X = 480;
    private const int BASE_RESOLUTION_Y = 270;
    private const float BASE_ASPECT_RATIO = (float)BASE_RESOLUTION_X / BASE_RESOLUTION_Y;

    void Start()
    {
        AdjustCamera();
    }

    void AdjustCamera()
    {
        Camera.main.aspect = BASE_ASPECT_RATIO;

        Rect rect = new Rect(0f, 0f, 1f, 1f);

        // Вычисляем зум как целое значение
        int zoomX = Screen.width / BASE_RESOLUTION_X;
        int zoomY = Screen.height / BASE_RESOLUTION_Y;
        int zoom = Mathf.Max(1, Mathf.Min(zoomY, zoomX));

        // Устанавливаем pixelRect для точной привязки к пиксельной сетке
        rect.width = zoom * BASE_RESOLUTION_X;
        rect.height = zoom * BASE_RESOLUTION_Y;

        rect.x = (Screen.width - (int)rect.width) / 2;
        rect.y = (Screen.height - (int)rect.height) / 2;

        Camera.main.pixelRect = rect;
    }
}