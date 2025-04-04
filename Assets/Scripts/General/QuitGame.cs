#if UNITY_EDITOR
using UnityEditor;
#endif

public static class QuitGame
{
    public static void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}