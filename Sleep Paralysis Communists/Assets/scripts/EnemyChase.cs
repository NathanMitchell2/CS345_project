using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float damageAmount = 10f;

    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player != null)
        {
            // Direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Rotate to look at the player
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);

            // Move towards the player
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.ChangeHealth(-damageAmount);
            }
        }
    }
}
