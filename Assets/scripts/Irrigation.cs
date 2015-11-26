using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Irrigation : MonoBehaviour, IPointerClickHandler
{

	// Use this for initialization
	Harvest harvest;
	void Start () 
	{
		harvest = GameObject.Find ("Harvest").GetComponent<Harvest>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerClick(PointerEventData data)
	{
		harvest.irrigation = true;
	}
}
