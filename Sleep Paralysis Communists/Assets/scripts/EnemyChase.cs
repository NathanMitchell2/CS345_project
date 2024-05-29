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
        // Direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Move towards the player
        rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
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
