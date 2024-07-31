using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHelper : MonoBehaviour
{
    private const string GameScene = "Game";
    private const string MenuScene = "Menu";

    public void GameStarter()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void MenuStarter()
    {
        SceneManager.LoadScene(MenuScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}