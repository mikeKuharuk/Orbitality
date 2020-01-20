using UnityEngine;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameManager gameManager;
    
    // todo: Refactor timeScale to be in 1 place
    public void PauseGame()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        gameManager.ReloadLevel();
    }

    public void ShowWinPanel()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

    public void ExitGame()
    {
        gameManager.ExitGame();
    }
}
