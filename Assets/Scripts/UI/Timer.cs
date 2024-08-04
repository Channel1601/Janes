using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeDuration = 3f * 60f;
    
    [HideInInspector]
    public float timer;
    
    [SerializeField] private TextMeshProUGUI firstMin;
    [SerializeField] private TextMeshProUGUI secMin;
    [SerializeField] private TextMeshProUGUI seperate;
    [SerializeField] private TextMeshProUGUI firstSec;
    [SerializeField] private TextMeshProUGUI secondSec;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if(timer > 0){
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
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
}
