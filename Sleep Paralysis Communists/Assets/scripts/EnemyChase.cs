using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float damageAmount = 10f;

    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();

        // Lock rotation on the X and Z axes to stay upright
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // Calculate the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Move towards the player using physics
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);

        // Calculate the look rotation
        Vector3 lookDirection = new Vector3(player.position.x, transform.position.y, player.position.z) - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
        rb.rotation = Quaternion.Slerp(rb.rotation, lookRotation, rotationSpeed * Time.fixedDeltaTime);
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
