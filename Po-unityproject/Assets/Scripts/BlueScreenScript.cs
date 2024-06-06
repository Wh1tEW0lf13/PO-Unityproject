using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueScreenScript : MonoBehaviour
{
    [SerializeField]
    private float time = 10f; 

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time<0)
        {
            SceneManager.LoadScene("Simulation");
        }
    }
    
}