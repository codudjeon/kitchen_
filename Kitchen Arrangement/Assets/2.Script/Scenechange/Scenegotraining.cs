using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenegotraining : MonoBehaviour

{
    // Start is called before the first frame update
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("Intro");
    }

    // Update is called once per frame
    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("Training");
    }
}

