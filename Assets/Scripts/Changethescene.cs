using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Changethescene : MonoBehaviour {

public Image img; 
	public void changeToScene(int changeTheScene)
	{
		SceneManager.LoadScene (changeTheScene);
	}
}
