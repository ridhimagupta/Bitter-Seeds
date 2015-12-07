using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour {

	// Use this for initialization
	Harvest harvest;
	void Start () 
	{
		harvest = GameObject.Find ("Harvest").GetComponent<Harvest>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		string t = GetComponent<Text>().text;
		t = "Season:"+harvest.counter;
		
		GetComponent<Text>().text = t;	

		
	}

}
