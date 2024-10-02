using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pipe;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Debug.Log("TIME = " + time);
        if(time > 3.0f)
        {
            Debug.Log("pipe");
            GameObject pipeGo = Instantiate(pipe, transform);
            time = 0;
        }
    }
}
