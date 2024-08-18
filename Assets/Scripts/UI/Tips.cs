using UnityEngine;

public class Tips : MonoBehaviour
{
    public GameObject enemy;
    public GameObject attackTip;
    public GameObject goodLuck;

    void Start()
    {
        goodLuck.SetActive(false);    
    }

    void Update()
    {
        if(enemy == null){
            Destroy(attackTip);
            goodLuck.SetActive(true);
        }
    }
}
