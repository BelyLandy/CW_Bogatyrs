/*
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneUI : MonoBehaviour
{
    private void StartGame()
    {
        SceneLoader.Load(SceneLoader.Scene.GameScene);
        Debug.Log("GameScene");
    }

    private void TerminateGame()
    {
        Debug.Log("Exit");
        QuitGame.ExitGame();
    }

    public void Blank()
    {
        Destroy(GameObject.Find("SelectProfile"));
    }
    
    private void Awake()
    {
        transform.Find("StartGameBtn").GetComponent<Button>().onClick.AddListener(StartGame);
        transform.Find("QuitGameBtn").GetComponent<Button>().onClick.AddListener(TerminateGame);
    }

}
*/
