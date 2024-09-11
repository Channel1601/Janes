using UnityEngine;

public class BossAttackColls : MonoBehaviour
{
    public Boss bossScript;
    public int attackIndex;
    public int shift;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(enabled){
            if (other.CompareTag("Player") && other.GetComponent<Health>() != null)
            {
                TriggerAttack();
            }
        }
    }

    void TriggerAttack()
    {
        if(attackIndex == 3 && shift == 2)
        {
            StartCoroutine(bossScript.SpinSpecial());
            return;
        }

        if(attackIndex == 0 && shift == 1)
        {
            bossScript.shiftup = true;
            bossScript.MoveUp();
            return;
        }
        
        if(attackIndex == 0 && shift == 2)
        {
            bossScript.shiftdown = true;
            bossScript.MoveDown();
            return;
        }

        switch (attackIndex)
        {
            case 1:
                bossScript.NadoAttack();
                Destroy(gameObject);
                break;
            case 2:
                bossScript.BeamAttack();
                break;
            case 3:
                bossScript.SpinAttack();
                break;
            case 4:
                bossScript.LightAttack();
                break;
            case 5:
                bossScript.CrowAttack();
                break;
            default:
                break;
        }

        switch(shift)
        {
            case 1:
                bossScript.shiftup = true;
                break;
            case 2:
                bossScript.shiftdown = true;
                break;
            case 3:
                break;
            default:
                break;
        }
    } 
}
