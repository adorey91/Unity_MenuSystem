using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public UIManager _uiManager;

    public void LoadScene(string sceneName)
    {

        if(sceneName == "MainMenu")
        {
            _uiManager.UI_MainMenu();
        }
        if(sceneName == "Gameplay_field")
        {
            _uiManager.UI_GamePlay();
        }
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game..");
    }
}
