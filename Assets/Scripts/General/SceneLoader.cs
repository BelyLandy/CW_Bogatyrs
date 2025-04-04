using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene
    {
        IntroScene,
        MenuScene,
        GameScene,
        SettingsScene,
        VictoryScene
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}

