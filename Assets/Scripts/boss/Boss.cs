using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Core")]
    public Animator anim;
    public GameObject bossBar;
    public Image bossBarFill;
    public GameObject stageTwoBeam;
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

    [Header("Attack Detect")]
    public GameObject stageOneColl;
    public GameObject stageTwoColl;

    private Vector3 targetPosition;
    private float distance;

    [HideInInspector] public bool shiftup;
    [HideInInspector] public bool shiftdown;

    void Awake()
    {
        gameObject.SetActive(false);
        bossBar.SetActive(false);
        tornadoPrefab.SetActive(false);
        beamPrefab.SetActive(false);
        stageTwoBeam.SetActive(false);
        stageTwoColl.SetActive(false);
    }

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if(health.currentHealth == stageTwoHealth){
            anim.SetTrigger("stageTwo");
            StageTwo();
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
    }

    #region Attacks

    public void NadoAttack()
    {
        anim.SetTrigger("tornado");
    }

    public void BeamAttack()
    {
        anim.SetTrigger("beam");
    }

    public void SpinAttack()
    {
        anim.SetTrigger("spin");
    }

    public IEnumerator SpinSpecial()
    {
        targetPosition -= new Vector3(0f, 2.5f, 0);
        FeatherPoint.transform.position -= new Vector3(0, 1, 0);
        anim.SetTrigger("spin");   

        yield return new WaitForSeconds(3.8f);
        targetPosition += new Vector3(0f, 2.5f, 0);
        FeatherPoint.transform.position += new Vector3(0, 1, 0);
    }

    private void StageTwo()
    {
       Destroy(stageOneColl);
       stageTwoColl.SetActive(true);        
    }
    #endregion

    #region other
    private void ChangeColour()
    {
        Color newColor;
        if (ColorUtility.TryParseHtmlString("#930000", out newColor))
        {
            bossBarFill.color = newColor;
        }
    }

    private void startBeam()
    {
        stageTwoBeam.SetActive(true);
    }

    private void stopBeam()
    {
        stageTwoBeam.SetActive(false);
    }
    #endregion

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
