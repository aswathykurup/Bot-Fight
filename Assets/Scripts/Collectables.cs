using UnityEngine;

public class Collectables : MonoBehaviour
{
    public float speed = 5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Health"))
            {
                ScoreManager.Instance.UpdateHealth(0, true);
            }
            if (gameObject.CompareTag("Speed"))
            {
                ScoreManager.Instance.UpdateSpeed();
            }
            if (gameObject.CompareTag("Reload"))
            {
                ScoreManager.Instance.UpdatebulletSpeed();
            }

            Destroy(gameObject);
        }
        
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * -1f);
    }

}
