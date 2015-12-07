using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DoneScript : MonoBehaviour, IPointerClickHandler 
{

	// Use this for initialization
	Harvest harvest;
	void Start () {
	
		harvest = GameObject.Find ("Harvest").GetComponent<Harvest>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerClick(PointerEventData data)
	{
		
		harvest.Init();
		//gameObject.transform.parent.gameObject.SetActive(false);
		Destroy(gameObject.transform.parent.gameObject);
//		DestroyImmediate(gameObject.transform.parent.parent);	
//		DestroyObject(gameObject.transform.parent.parent);
	}
}