using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private GameObject startText;
    private bool isGameStarted = false;

    private void Start()
    {
        StopGame();
    }

    private void Update()
    {
        if (!isGameStarted && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)))
        {
            isGameStarted = true;
            StartGame();
        }
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        startText.SetActive(false);
    }
    
    private void StopGame()
    {
        Time.timeScale = 0f;    
        startText.SetActive(true);
    }
}