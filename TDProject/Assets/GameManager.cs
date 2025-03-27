using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject shop;
    public GameObject gameOverScreen;
    public static bool GameEnded;
    public GameObject roundsCounter;
    void Start()
    {
        shop.SetActive(true);
        gameOverScreen.SetActive(false);
        GameEnded = false;
    }
    void Update()
    {
        if (GameEnded)
        {
            return;
        }
        if (PlayerStats.Lives <= 0){
            EndGame();
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    private void EndGame()
    {
        Debug.Log("GAME OVER!");
        shop.SetActive(false);
        gameOverScreen.SetActive(true);
        GameEnded = true;
        roundsCounter.GetComponent<TextMeshProUGUI>().text = "Rounds survived: " + PlayerStats.Rounds.ToString();
    }
}
