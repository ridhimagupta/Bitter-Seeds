using UnityEngine;
using System.Collections;

public class Opportunity : MonoBehaviour {

	// Use this for initialization
	GameObject ops;
	GameObject[] children;
	void Start () {
		ops = (GameObject)Instantiate(Resources.Load("Reports"));
		children = new GameObject[ops.transform.childCount];
		int i = 0;
		foreach(Transform child in ops.transform)
		{
			children[i] = child.gameObject;
			i++;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
