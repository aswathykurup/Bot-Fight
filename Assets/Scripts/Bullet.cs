using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f;
    public float damage = 25f;
    private Rigidbody rb;
    public ParticleSystem explosion;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.forward * ScoreManager.Instance.GetBulletSpeed();
        Destroy(gameObject, lifetime);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.LookRotation(contact.normal);
        ParticleSystem Instance = Instantiate(explosion, contact.point,rotation);
        float totalDuration = Instance.main.duration + Instance.main.startLifetime.constantMax;
        Destroy (Instance.gameObject,totalDuration);


        if (collision.gameObject.CompareTag("Enemy"))
        {
            ScoreManager.Instance.UpdateScore();
            Destroy(collision.gameObject);
        }
        
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
