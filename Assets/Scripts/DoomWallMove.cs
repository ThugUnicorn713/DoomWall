using UnityEngine;

public class DoomWallMove : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public Vector2 end = new Vector2(0f,0f);
    public float accel;
    
    

    void Start()
    {
        end.y = transform.position.y;//makes sure the obj stays on same y position at start
    }

    void Update()
    {
        speed += (Time.deltaTime * accel) / 50;
        transform.position = Vector2.Lerp(transform.position, end, (speed * Time.deltaTime)/100);        
    }
}
