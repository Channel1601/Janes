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
    public GameObject endScreen;

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

    [Header("Light Attack")]
    public Transform holymoly;
    public GameObject lightPrefab;

    [Header("Crow Attack")]
    public Transform CrowPoint;
    public GameObject[] crows;

    [Header("Attack Detect")]
    public GameObject stageOneColl;
    public GameObject stageTwoColl;

    private Vector3 targetPosition;
    private float distance;
    private bool specbooUp = false;

    [HideInInspector] public bool shiftup;
    [HideInInspector] public bool shiftdown;

    void Awake()
    {
        gameObject.SetActive(false);
        bossBar.SetActive(false);
        tornadoPrefab.SetActive(false);
        beamPrefab.SetActive(false);
        lightPrefab.SetActive(false);
        stageTwoBeam.SetActive(false);
        endScreen.SetActive(false);
    }

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if(health.currentHealth == stageTwoHealth){
            StageTwo();
            anim.SetTrigger("stageTwo");
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

    public void LightAttack()
    {
        anim.SetTrigger("light");
    }

    public void CrowAttack()
    {
        anim.SetTrigger("crow");
    }

    public IEnumerator SpinSpecial()
    {
        targetPosition -= new Vector3(0f, 2.5f, 0);
        FeatherPoint.transform.position -= new Vector3(0, 1, 0);
        anim.SetTrigger("spin");   

        yield return new WaitForSeconds(4f);
        targetPosition += new Vector3(0f, 2.5f, 0);
        FeatherPoint.transform.position += new Vector3(0, 1, 0);
    }

    private void StageTwo()
    {
       Destroy(stageOneColl); 
       if(transform.position.y <= 1f)
       {
        shiftup = true;
       }
       if(transform.position.y <= -2f)
       {
        specbooUp = true;
       }
    }
    private void specUp()
    {
        if(specbooUp == true){
            targetPosition += new Vector3(0f, 2.5f, 0);
            FeatherPoint.transform.position += new Vector3(0, 1, 0);
        }
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

    private void LevelDone()
    {
        endScreen.SetActive(true);
    }

    private void Remove()
    {
        Destroy(gameObject);
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

    private void lightAttack()
    {
        lightPrefab.transform.position = holymoly.position;
        lightPrefab.GetComponent<BossProjectile>().ActivateProjectile();
    }

    private void crowAttack()
    {   
        crows[FindCrows()].transform.position = CrowPoint.position;
        crows[FindCrows()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindCrows(){
        for(int i = 0; i < crows.Length; i++){
            if(!crows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    #endregion

    #region moving
    public void MoveUp()
    {
        if(shiftup && transform.position.y <= 1f){
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
