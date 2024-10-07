using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //public TextMeshProUGUI finalTimeText; cant get this to work

    public Timer freezeTime;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        freezeTime = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }

    void Update()
    {
        
    }

    /*public void PrintScore()
    {
        if (freezeTime != null)
        {
            finalTimeText.text = freezeTime.timeText.ToString() + " Final Time! ";  same here (tried to print score)
        }
    }*/
}
