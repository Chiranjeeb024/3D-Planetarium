using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, -.025f, 0f);
    }
}
