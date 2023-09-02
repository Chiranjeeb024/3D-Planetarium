using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenemanager : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void frontscene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);



    }


    public void overview()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
     }

    public void iconplanet()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void mercury()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void venus()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);

    }
    public void earth()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }
    public void moon()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }
    public void Mars()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(7);
    }

    public void jupiter()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(8);
    }

    public void saturn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(9);
    }

    public void uranus()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(10);

    }

    public void neptune()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(11);
    }

    public void loading()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(12);
    }

        public void Quit()
    {
        Application.Quit();
        Debug.Log("Game is closed");
    }
}
