using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenegointro : MonoBehaviour

{
    // Start is called before the first frame update
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("Admin");
    }

    // Update is called once per frame
    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("Intro");
    }
}

