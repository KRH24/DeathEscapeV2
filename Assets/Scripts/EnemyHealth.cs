using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Image HealthBarSprite;
    [SerializeField] private float maxHealth = 3f;
    [SerializeField] private GameObject levelCompleteScreen;

    private float currentHealth;
    private Camera cam;
    private bool isDead = false;

    void Start()
    {
        cam = Camera.main;
        currentHealth = maxHealth;

        if (levelCompleteScreen != null)
            levelCompleteScreen.SetActive(false);
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        UpdateHealthBar(maxHealth, currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        if (HealthBarSprite != null)
            HealthBarSprite.fillAmount = currentHealth / maxHealth;
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Enemy dead");

        if (levelCompleteScreen != null)
            levelCompleteScreen.SetActive(true);

        
    }
}
