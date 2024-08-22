using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private BoxCollider2D boxCollide;
    private Animator animate;

    private void Awake()
    {
        boxCollide = GetComponent<BoxCollider2D>();
        animate = GetComponent<Animator>();

    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 1.5f) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy"){
            collision.GetComponent<Health>().TakeDamage(1);
            hit = true;
            boxCollide.enabled = false;
            animate.SetTrigger("slash");
        }

        if(collision.tag == "Block")
        {
            hit = true;
            boxCollide.enabled = false;
            animate.SetTrigger("slash");
        }
    }

    //followed a tuto so name isnt accurate 
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollide.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180);
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
