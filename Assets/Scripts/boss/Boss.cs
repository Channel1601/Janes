using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Core")]
    public Animator anim;
    public GameObject bossBar;
    public Health health;
    public float stageTwoHealth;
    
    [Header("Distance")]
    public Transform ninjaPos;
    public float maxDistance;

    [Header("Tornado Attack")]
    public Transform nadoPoint;
    public GameObject tornadoPrefab;

    [Header("Beam Attack")]
    public Transform Mouth;
    public GameObject beamPrefab;

    [Header("Spin Attack")]
    public Transform FeatherPoint;
    public GameObject[] feathers;

    private Vector3 targetPosition;
    private float distance;

    private bool shiftup;
    private bool shiftdown;

    void Awake()
    {
        gameObject.SetActive(false);
        bossBar.SetActive(false);
        tornadoPrefab.SetActive(false);
        beamPrefab.SetActive(false);
    }

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if(health.currentHealth == stageTwoHealth){
            anim.SetTrigger("stageTwo");
            StopCoroutine(Attacks());
            StartCoroutine(StageTwo());
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 20 * Time.deltaTime);

        distance = Mathf.Abs(transform.position.x - ninjaPos.position.x);
        if(distance>maxDistance) Framing();        
    }

    public void SpawnBoss()
    {
        gameObject.SetActive(true);
        anim.SetTrigger("Spawn");
        bossBar.SetActive(true);
        StartCoroutine(Attacks());
    }

    private IEnumerator Attacks()
    {
        //Attack 1: Tornado (Goes up after)
        yield return new WaitForSeconds(4.5f);
        shiftup = true;
        anim.SetTrigger("tornado");
        

        //Attack 2: Beam (Goes down after)
        yield return new WaitForSeconds(3.5f);
        shiftdown = true;
        anim.SetTrigger("beam");
        

        //Attack 3: Tornado (Goes up again)
        yield return new WaitForSeconds(4f);
        shiftup = true;
        anim.SetTrigger("tornado");

        //Attack 4: Spin
        yield return new WaitForSeconds(2.5f);
        anim.SetTrigger("spin");

        //Attack 5: Beam (Goes Down)
        yield return new WaitForSeconds(5f);
        shiftdown = true;
        anim.SetTrigger("beam");
    }

    private IEnumerator StageTwo()
    {
        yield return new WaitForSeconds(5f);
        
    }

    #region attacks
    private void tornadoAttack()
    {
        tornadoPrefab.transform.position = nadoPoint.position;
        tornadoPrefab.GetComponent<BossProjectile>().ActivateProjectile();
    }

    private void beamAttack()
    {
        beamPrefab.transform.position = Mouth.position;
        beamPrefab.GetComponent<BossProjectile>().ActivateProjectile();
    }

    private void spinAttack()
    {   
        feathers[FindFireball()].transform.position = FeatherPoint.position;
        feathers[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireball(){
        for(int i = 0; i < feathers.Length; i++){
            if(!feathers[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    #endregion

    #region moving
    public void MoveUp()
    {
        if(shiftup){
            targetPosition += new Vector3(0f, 3.5f, 0);
            shiftup = false;
        }
    }

    public void MoveDown()
    {
        if(shiftdown){
            targetPosition -= new Vector3(0f, 3.5f, 0);
            shiftdown = false;
        }
    }

    private void Framing()
    {
        targetPosition = new Vector3(ninjaPos.position.x + maxDistance, transform.position.y, 0);
    }
    #endregion
}
