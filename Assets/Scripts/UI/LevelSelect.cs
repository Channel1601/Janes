using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [Header("Play Button")]
    [SerializeField] private Button playButton;

    [Header("Level Images")]
    [SerializeField] private GameObject level1Image;

    private void Awake()
    {
        level1Image.gameObject.SetActive(false);
        playButton.interactable = false; 
    }

    public void exit()
    {
        SceneManager.LoadScene(0);
    }

    #region Level 1
    public void Level1Select()
    {
        level1Image.gameObject.SetActive(true);
        playButton.interactable = true; 
    }

    public void Level1Play()
    {
        SceneManager.LoadScene(2);
    }
    #endregion
}
