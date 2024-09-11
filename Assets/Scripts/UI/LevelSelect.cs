using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [Header("Play Button")]
    [SerializeField] private Button playButton;

    [Header("Level Images")]
    [SerializeField] private GameObject level1Cover;

    private void Awake()
    {
        level1Cover.gameObject.SetActive(true);
        playButton.interactable = false; 
    }

    public void exit()
    {
        SceneManager.LoadScene(0);
    }

    #region Level 1
    public void Level1Select()
    {
        level1Cover.gameObject.SetActive(false);
        playButton.interactable = true; 
    }

    public void Level1Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    #endregion
}
