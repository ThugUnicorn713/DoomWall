using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Timer pauseTimer;
    public GameObject winPanel;
    

    private void Start()
    {
       pauseTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            pauseTimer.GetComponent<Timer>().paused = true;
            winPanel.SetActive(true);
            //GameManager.instance.PrintScore(); Cant get it to work!
        }
    }
}
