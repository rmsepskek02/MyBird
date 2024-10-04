using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public GameObject grounds;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        grounds.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);

        if(grounds.transform.position.x <= -8.4f)
        {
            grounds.transform.position = Vector3.zero;
        }
    }
}
