using UnityEngine;
using System.Collections;


public class NextScene : MonoBehaviour 
{

	public void NextSceneButton(string levelName)
	{
		Application.LoadLevel(levelName);
	}
}

