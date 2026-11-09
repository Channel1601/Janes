using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [Header("Play Button")]
    [SerializeField] private Button playButton;

    [Header("Level Images")]
    [SerializeField] private GameObject levelCover;
    [SerializeField] private GameObject level1Img;
    [SerializeField] private GameObject level2Img;

    private void Awake()
    {
        levelCover.gameObject.SetActive(true);
        level1Img.gameObject.SetActive(false);
        level2Img.gameObject.SetActive(false);
        playButton.interactable = false; 
    }

    public void exit()
    {
        SceneManager.LoadScene(0);
    }

    #region Level 1
    public void Level1Select()
    {
        levelCover.gameObject.SetActive(false);
        level2Img.gameObject.SetActive(false);
        level1Img.gameObject.SetActive(true);
        playButton.interactable = true; 
    }

    public void Level1Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    #endregion

    #region Level 2
    public void Level2Select()
    {
        levelCover.gameObject.SetActive(false);
        level2Img.gameObject.SetActive(true);
        level1Img.gameObject.SetActive(false);
        playButton.interactable = true; 
    }

    public void Level2Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
    #endregion
}
