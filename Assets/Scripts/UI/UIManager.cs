using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverMusic;
    
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Boss")]
    [SerializeField] private GameObject boss;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if(boss == null)
        {
            Time.timeScale = 0;
        }
    }

    #region Game Over Screen

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        audioSource.Stop();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        if(Time.timeScale == 0) Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverScreen.SetActive(false);
    }
   #endregion 

    #region Pause Screen
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        audioSource.Pause();

        if (status){
            Time.timeScale = 0;
        }
        else{    
            audioSource.Play();
            Time.timeScale = 1;
        }

    }

    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }

    #endregion
}
