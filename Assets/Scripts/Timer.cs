using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float maxTime = 120;
    public TextMeshProUGUI timeText;
    public bool paused = false;

    [SerializeField]
   // public string playDeath = "YouDeadScene";


    
    void Update()
    {
        if (!paused)
        {
            if (maxTime > 0)
            {
                maxTime -= Time.deltaTime;
            }
            else
            {
                maxTime = 0;
            }

            DisplayTime(maxTime);
        }
       
    }

    void DisplayTime(float time)
    {
        if ( time < 0 )
        {
            time = 0;
        }

        float mins = Mathf.FloorToInt( time / 60 );
        float secs = Mathf.FloorToInt( time % 60 ); //makes whole mins secs ???
        float milliSecs = time % 1 * 1000;

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", mins, secs, milliSecs); //c

    }
}
