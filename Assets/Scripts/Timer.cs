using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float MaxTime = 120f;
    public float currentTime; 

    //make sense of this
    private void Awake()
    {

        currentTime = MaxTime;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
    }
}
