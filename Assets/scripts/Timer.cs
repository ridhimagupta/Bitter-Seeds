using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	// Use this for initialization
	bool paused;
	void Start () {
	
	paused = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!paused)
		{
			string t = GetComponent<Text>().text;
			t = ""+ Mathf.Floor(Time.time*1.5f);
			
			GetComponent<Text>().text = t;	
			if(t=="5")
			{
				GameObject report = (GameObject)Instantiate(Resources.Load("Report"));
				report.transform.parent = gameObject.transform.parent.parent;
				report.transform.position = gameObject.transform.parent.parent.position;
				paused = true;
			}
		}
		
	}
}
