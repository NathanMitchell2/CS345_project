using UnityEngine;
using System.Collections;
using TMPro; // Import TextMeshPro
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public bool canDie = true;
    public float startingHealth = 100.0f;
    public float maxHealth = 100.0f;
    private float currentHealth;

    public bool replaceWhenDead = false;
    public GameObject deadReplacement;
    public bool makeExplosion = false;
    public GameObject explosion;

    public bool isPlayer = false;
    public GameObject deathCam;

    private bool dead = false;
    private int currentKills = 0;
    private bool upgraded = false;

    // Reference to the TMP_Text component where the health will be displayed
    public TMP_Text healthText;
    public TMP_Text killCounter;
    [SerializeField] HealthBar healthBar;

    void Start()
    {
        currentHealth = startingHealth;
        UpdateHealthUI(); // Update the health UI when the game starts
        healthBar = GetComponentInChildren<HealthBar>();
    }

    void Update()
    {
        Debug.Log(currentKills);
        Debug.Log(upgraded);
        if (int.Parse(killCounter.text) == 2 && !upgraded && isPlayer)
        {
            Debug.Log("Reached 20 kills. Triggering TMP movement.");
            upgraded = true;

            GameObject pistol = transform.Find("Pistol").gameObject;
            if (pistol != null)
            {
                // Disable the "Pistol" GameObject
                pistol.SetActive(false);
            }

            // Check if the GameObject "FullAutoPistol" exists
            GameObject fullAutoPistol = transform.Find("FullAutoPistol").gameObject;
            if (fullAutoPistol != null)
            {
                // Enable the "FullAutoPistol" GameObject
                fullAutoPistol.SetActive(true);
            }
        }
    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;

        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0 && !dead && canDie)
            Die();
        else if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthUI(); // Update the health UI after changing health
    }

    public void Die()
    {
        dead = true;

        if (replaceWhenDead)
            Instantiate(deadReplacement, transform.position, transform.rotation);
        if (makeExplosion)
            Instantiate(explosion, transform.position, transform.rotation);

        if (isPlayer && deathCam != null)
            deathCam.SetActive(true);
            GoToNextScene();

        if (killCounter != null && !isPlayer)
        {
            currentKills = int.Parse(killCounter.text);
            currentKills++;
            killCounter.text = currentKills.ToString();
        }

        Destroy(gameObject);
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            // Update TMP text to display current health
            healthText.text = currentHealth.ToString();
        }
    }

    void GoToNextScene()
    {
        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene
        SceneManager.LoadScene(currentSceneIndex - 1);
    }
}
