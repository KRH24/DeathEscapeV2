using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private Image HealthBarSprite;

    private Camera cam;

    void Start() {

    cam = Camera.main;

    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {

        HealthBarSprite.fillAmount = currentHealth / maxHealth;

    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);

    }


}
