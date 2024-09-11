using System.Collections;
using UnityEngine;

public class StageTwoChecker : MonoBehaviour
{
    public GameObject stageOne;
    private BossAttackColls bossAttack;

    void Start()
    {
        bossAttack = GetComponent<BossAttackColls>();
    }
    void Update()
    {
        if(stageOne != null)
        {
            bossAttack.enabled = false;
        }
        if(stageOne == null)
        {
            StartCoroutine(disable());
        }
    }

    private IEnumerator disable()
    {
        yield return new WaitForSeconds(10f);
        bossAttack.enabled = true;
    }
}
