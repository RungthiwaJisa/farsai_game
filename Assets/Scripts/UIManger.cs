using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour
{
    [SerializeField] TMP_Text healhText;
    [SerializeField] Player con;
    public bool isGamePaused = false;
    public GameObject lossScreen;
    public GameObject winScreen;
    public GameObject settingScreen;


    void Update()
    {
        if (con != null)
        {
            if (con.isGameWin)
            {
                PauseGame();
                winScreen.SetActive(true);
            }

            if (con.isGameOver)
            {
                PauseGame();
                lossScreen.SetActive(true);
            }

            if (con.setting.triggered)
            {
                PauseGame();
                settingScreen.SetActive(true);
            }
        }
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GotoNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadSceneAsync(currentSceneIndex + 1, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReStart()
    {
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    public void HealthDisplay(int health)
    {
        healhText.text = $"= {health}";
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        isGamePaused = true;
        con.isGamePause = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        isGamePaused = false;
        con.isGamePause = false;
        settingScreen.SetActive(false);
    }
}
