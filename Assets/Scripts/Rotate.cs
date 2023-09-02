using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{


    public float SpeedControler;



    // Start is called before the first frame update


    void Update()
    {
        transform.Rotate(new Vector3(0f, SpeedControler * Time.deltaTime, 0f));

    }

}
