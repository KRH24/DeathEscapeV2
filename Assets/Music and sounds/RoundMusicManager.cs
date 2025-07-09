using UnityEngine;

public class RoundMusicManager : MonoBehaviour
{
    public AudioSource musicSource;

    public void StartRound()
    {
        musicSource.Play();
        Debug.Log("Round started and music is playing.");
        // Add other round-start logic here if needed
    }
}
