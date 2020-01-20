using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;


    public void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinGame()
    {
        uiManager.ShowWinPanel();
    }

    public void LoseGame()
    {
        uiManager.ShowLosePanel();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
