using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class resetGame : MonoBehaviour
{
   
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
           StartCoroutine(timeReset());
        }
    }

    IEnumerator timeReset()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SampleScene");

    }
}
