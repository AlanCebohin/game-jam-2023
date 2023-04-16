using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private bool isGameOver = false;
    //public GameObject gameOverPanel;

    private void Awake()
    {
        instance = this;
        //gameOverPanel = GameObject.Find("GameOverPanel");
        //gameOverPanel.SetActive(false);
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameOver = false;
        GameObject.Find("Player").GetComponent<PlayerController>().IsMoving = true;
    }

    public void GameOver()
    {
        isGameOver = true;
        GameObject.Find("Player").GetComponent<PlayerController>().IsMoving = false;
        //gameOverPanel.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
