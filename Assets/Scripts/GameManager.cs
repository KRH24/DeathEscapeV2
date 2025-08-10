using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int enemiesAlive = 0;
    public GameObject levelCompleteScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void EnemiesDefeated()
    {

        enemiesAlive -= 1; 

        if (enemiesAlive <= 0)
        {

            levelCompleteScreen.SetActive(true);
            Debug.Log("Level Complete!");
        }
    }
}
