using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject logotext;
    void Start()
    {
        logotext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        logotext.SetActive(true);
    }

    public void OnMouseExit()
    {
        logotext.SetActive(false);
    }
}
