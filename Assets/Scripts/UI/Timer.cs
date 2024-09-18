using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    private float timeDuration = 2.5f * 60f;
    
    [HideInInspector]
    public float timer;
    
    [SerializeField] private TextMeshProUGUI firstMin;
    [SerializeField] private TextMeshProUGUI secMin;
    [SerializeField] private TextMeshProUGUI seperate;
    [SerializeField] private TextMeshProUGUI firstSec;
    [SerializeField] private TextMeshProUGUI secondSec;

    [SerializeField] private CanvasGroup redFlashCanvas; 
    [SerializeField] private float flashDuration = 0.5f;

    private bool isFlashing = false;

    void Start()
    {
        ResetTimer();
        redFlashCanvas.alpha = 0f;
    }

    void Update()
    {
        if(timer > 0){
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);

            if(timer <= 5f && !isFlashing)
            {
                StartCoroutine(FlashRedScreen());
                isFlashing = true; // Ensure the flash starts only once
            }

        } else {
            timer = 0;
            UpdateTimerDisplay(timer);
        }
    }

    private void ResetTimer()
    {
        timer = timeDuration;
    }

    private void UpdateTimerDisplay (float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}",minutes, seconds);
        
        firstMin.text = currentTime[0].ToString();
        secMin.text = currentTime[1].ToString();
        firstSec.text = currentTime[2].ToString();
        secondSec.text = currentTime[3].ToString();
    }

    private IEnumerator FlashRedScreen()
    {
        while(timer <= 5f)
        {
            // Fade in
            float t = 0f;
            while(t < flashDuration)
            {
                redFlashCanvas.alpha = Mathf.Lerp(0f, 1f, t / flashDuration);
                t += Time.deltaTime;
                yield return null;
            }

            // Fade out
            t = 0f;
            while(t < flashDuration)
            {
                redFlashCanvas.alpha = Mathf.Lerp(1f, 0f, t / flashDuration);
                t += Time.deltaTime;
                yield return null;
            }
        }

        redFlashCanvas.alpha = 0f; // Ensure canvas is invisible after flashing
    }

}
