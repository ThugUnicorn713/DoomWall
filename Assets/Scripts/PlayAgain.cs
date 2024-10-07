using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    [SerializeField] string playGame = "GameScene";
  public void StartGame()
    {
        SceneManager.LoadScene(playGame);
    }

    public void QuitGame()
    {
        Debug.Log("they gave up");
        Application.Quit();
    }

}
