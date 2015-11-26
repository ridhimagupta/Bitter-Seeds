using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour {

	// Use this for initialization
	bool paused;
	GameObject reports;
	Transform[] transforms;
	GameObject[] children;
	void Start () 
	{
		
		paused = false;
		reports = (GameObject)Instantiate(Resources.Load("Reports"));
		children = new GameObject[reports.transform.childCount];

		int i = 0;
		foreach(Transform child in reports.transform)
		{
			
			
			if(child.name=="LowPricesReport")
			{
				
			}
			children[i] = child.gameObject;
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!paused)
		{
			string t = GetComponent<Text>().text;
			t = ""+ Mathf.Floor(Time.time);
			
			GetComponent<Text>().text = t;	
			if(t=="2")
			{
				int r = Random.Range(0,children.Length);
				Debug.Log (r);
				GameObject report = children[r];
				Debug.Log (report);
				report.transform.parent = gameObject.transform.parent;
				report.transform.position = gameObject.transform.parent.position;
				paused = true;
			}
		}
		
	}
	private string ResolveTextSize(string input, int lineLength){
		
		// Split string by char " "         
		string[] words = input.Split(" "[0]);
		
		// Prepare result
		string result = "";
		
		// Temp line string
		string line = "";
		
		// for each all words        
		foreach(string s in words){
			// Append current word into line
			string temp = line + " " + s;
			
			// If line length is bigger than lineLength
			if(temp.Length > lineLength){
				
				// Append current line into result
				result += line + "\n";
				// Remain word append into new line
				line = s;
			}
			// Append current word into current line
			else {
				line = temp;
			}
		}
		
		// Append last line into result        
		result += line;
		
		// Remove first " " char
		return result.Substring(1,result.Length-1);
	}
}
