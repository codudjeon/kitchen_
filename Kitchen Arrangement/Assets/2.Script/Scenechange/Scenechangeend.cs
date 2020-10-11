using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechangeend : MonoBehaviour

{
    // Start is called before the first frame update
    private string End;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Door")
    {
            SceneManager.LoadScene("End");
    }
  }
}