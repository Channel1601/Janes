using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string nextSceneName; // Assign your scene name in the Inspector
    public float transitionDelay = 0.5f; // Delay before starting the gameplay (optional)

    public void PlayButtonClicked()
    {
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        // Pause the game
        Time.timeScale = 0f;

        // Start loading the scene asynchronously but do not activate it
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);
        asyncLoad.allowSceneActivation = false;

        // Wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                // Scene is ready, wait for the optional delay
                yield return new WaitForSecondsRealtime(transitionDelay);

                // Activate the scene
                asyncLoad.allowSceneActivation = true;

                // Resume the game
                Time.timeScale = 1f;
            }

            yield return null;
        }
    }
}
