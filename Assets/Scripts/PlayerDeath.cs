using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeath : MonoBehaviour
{
    [SerializeField] string playDeath = "YouDeadScene";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            SceneManager.LoadScene(playDeath);
            
        }
    }
}
