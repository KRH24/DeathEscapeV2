using System.Collections;
using TMPro;
using UnityEngine;

public class LevelIntroTextController : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public float displayTime = 3f;

    void Start()
    {
        StartCoroutine(ShowIntroText());
    }

    IEnumerator ShowIntroText()
    {
        introText.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        introText.gameObject.SetActive(false);
    }
}
