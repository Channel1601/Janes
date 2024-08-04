using TMPro;
using UnityEngine;

public class TimerPause : MonoBehaviour
{
    public GameObject mainTimer;
    private Timer timer;

    [SerializeField] private TextMeshProUGUI firstMin;
    [SerializeField] private TextMeshProUGUI secMin;
    [SerializeField] private TextMeshProUGUI seperate;
    [SerializeField] private TextMeshProUGUI firstSec;
    [SerializeField] private TextMeshProUGUI secondSec;

    void Start()
    {
        timer = mainTimer.GetComponent<Timer>();
    }
    
    void Update()
    {
        UpdateTimerDisplay(timer.timer);
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
