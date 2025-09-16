using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    //public InterstitialAdExample adManager;
    public LevelPlaySample levelPlaySample;
    private static int deathCount = 0;
    private static int nextAdThreshold;

    // DeathCount deathCount;
    private UIManager uiManager;

    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [HideInInspector]
    public bool canHurt = false;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        uiManager = FindFirstObjectByType<UIManager>();
        SetNextAdThreshold(); 
    }

    public void TakeDamage(float _damage)
    {
        if (canHurt) return;

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }

        else
        {
            if (!dead)
            {
                anim.SetTrigger("dead");

                //Player
                if (GetComponent<movement>() != null)
                {
                    //adManager.OnCharacterDeath();
                    OnCharacterDeath();
                    GetComponent<movement>().enabled = false;
                    ObstacleMovement[] scripts = FindObjectsByType<ObstacleMovement>(FindObjectsSortMode.None);
                    foreach (ObstacleMovement script in scripts)
                    {
                        script.enabled = false;
                    }
                    DetectMovement[] scrips = FindObjectsByType<DetectMovement>(FindObjectsSortMode.None);
                    foreach (DetectMovement script in scrips)
                    {
                        script.enabled = false;
                    }
                    StartCoroutine(GameOverShow());
                }
                //Enemy
                if (GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;

                if (GetComponent<RangedEnemy>() != null)
                    GetComponent<RangedEnemy>().enabled = false;

                dead = true;
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            TakeDamage(2);
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    private IEnumerator GameOverShow()
    {
        yield return new WaitForSeconds(0.75f);
        Time.timeScale = 0;
        uiManager.GameOver();
    }
     
    private void OnCharacterDeath()
    {
        Debug.Log(deathCount);
        deathCount++;

        if (deathCount >= nextAdThreshold)
        {
            levelPlaySample.InterAdShow();
            levelPlaySample.BannerAdHide();
            Debug.Log("Set an ad");
            deathCount = 0; // Reset the death counter after showing the ad
            SetNextAdThreshold();
        }
    }

    private void SetNextAdThreshold()
    {
        nextAdThreshold = Random.Range(3, 6); // Random number between 3 and 5
    }

 }
