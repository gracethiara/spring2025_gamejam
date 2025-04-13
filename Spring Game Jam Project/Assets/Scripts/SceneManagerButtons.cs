using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerButtons : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainScene()
    {
        GameStateManager.IsPaused = false;
        LoadScene(SceneName.Main);
    }

    public void LoadTitleScene()
    {
        LoadScene(SceneName.Title);
    }

    private void LoadScene(SceneName p_sceneNameEnum)
    {
        SceneManager.LoadScene(p_sceneNameEnum.ToString());
    }
}
