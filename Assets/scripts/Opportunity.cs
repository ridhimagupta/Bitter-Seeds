using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Opportunity : MonoBehaviour
{
	// Use this for initialization
	GameObject ops,op;
	GameObject[] children;
	int r;
	public void Deny()
	{
		
		Destroy (op.gameObject);
		Init();
		
	}
	public void Accept()
	{
		if(op.name == "Opportunity 1" || op.name == "Opportunity 3")
		{	
			Application.LoadLevel(2);
		}
		else
		{
			Application.LoadLevel(1);
		}
	}
	void Start () 
	{
		Init();
		
	}
	public void Init()
	{
		ops = (GameObject)Instantiate(Resources.Load("Opportunities"));
		children = new GameObject[ops.transform.childCount];
		int i = 0;
		foreach(Transform child in ops.transform)
		{
			children[i] = child.gameObject;
			i++;
		}
		r = Random.Range(0,children.Length);
		op = children[r];
		
//		op.transform.SetParent(gameObject.transform.parent);//;
//		op.transform.position = gameObject.transform.parent.position;
//		
	
	}
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void display()
	{
		
		op.transform.SetParent(gameObject.transform.parent);//;
		op.transform.position = gameObject.transform.parent.position;
		
	}
	

}
