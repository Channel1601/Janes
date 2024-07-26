using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject infoScreen;

    void Awake()
    {
        infoScreen.SetActive(false);
    }

    public void PlayScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void InfoScreenOn()
    {
        infoScreen.SetActive(true);
    }

    public void InfoScreenOff()
    {
        infoScreen.SetActive(false);
    }
}
