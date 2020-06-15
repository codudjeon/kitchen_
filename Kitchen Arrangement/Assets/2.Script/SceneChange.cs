using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour

{
	public string loadLevel;

	private void ButtonClick()

	{

		SceneManager.LoadScene("loadLevel");

	}

}

    // Start is called before the first frame update
    //public void ChangeFirstScene()
    //{
    //  SceneManager.LoadScene("Practice");
    //}

    // Update is called once per frame
    //public void ChangeSecondScene()
    //{
    //    SceneManager.LoadScene("Main");
    //}