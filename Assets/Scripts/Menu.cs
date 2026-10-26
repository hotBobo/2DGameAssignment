using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject howToPlayPanel;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1.0f;
    void Start()
    {
        if (creditsPanel != null) // Make sure in case I left creditsPanel blank we dont explode
        {
            creditsPanel.SetActive(false);
        }
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
        }
        if (fadeCanvasGroup != null)
        {
            fadeCanvasGroup.alpha = 0f;
            fadeCanvasGroup.blocksRaycasts = false;
        }
    }
    public string mainScene = "MainScene";
    public void PlayGame()
    {
        StartCoroutine(FadeAndLoadScene(mainScene));
    }
    IEnumerator FadeAndLoadScene(string sceneName)
    {
        if (fadeCanvasGroup != null)
        {
            fadeCanvasGroup.blocksRaycasts = true; // Want to block clicks during fade
        }
        float timeElapsed = 0f;
        // Smoothly fade transparency from 0 to 1 over time
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            if (fadeCanvasGroup != null)
            {
                fadeCanvasGroup.alpha = Mathf.Clamp01(timeElapsed / fadeDuration); // Essentially get percentage of time elapsed
            }
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Debug.Log("Player Quit the game."); // So I can see it works in the editor
        Application.Quit(); // Actually quit the game
    }
    public void OpenCredits()
    {
        if (creditsPanel != null) creditsPanel.SetActive(true);
    }
    public void CloseCredits()
    {
        if (creditsPanel != null) creditsPanel.SetActive(false);
    }
    public void OpenHowToPlay()
    {
        if (howToPlayPanel != null) howToPlayPanel.SetActive(true);
    }
    public void CloseHowToPlay()
    {
        if (howToPlayPanel != null) howToPlayPanel.SetActive(false);
    }
}
