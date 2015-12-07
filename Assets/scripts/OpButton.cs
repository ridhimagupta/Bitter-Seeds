using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class OpButton : MonoBehaviour, IPointerClickHandler  
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnPointerClick(PointerEventData data)
	{
		if(gameObject.name=="Accept")
			GameObject.Find ("Opportunity").GetComponent<Opportunity>().Accept();
		else if(gameObject.name=="Deny")
			GameObject.Find ("Opportunity").GetComponent<Opportunity>().Deny();
	}
}
