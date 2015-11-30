using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IPF : MonoBehaviour, IPointerClickHandler
{

	// Use this for initialization
	Harvest harvest;
	int savings;
	bool clicked = true;
	//public bool done = false;
	void Start () 
	{
		harvest = GameObject.Find ("Harvest").GetComponent<Harvest>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!harvest.irrigation && gameObject.name == "Irrigation")
		{
			GetComponent<Button>().interactable = true;
			clicked = true;
		}
		if(!harvest.pesticide && gameObject.name == "Pesticide")
		{
			GetComponent<Button>().interactable = true;
			clicked = true;
		}
		if(!harvest.fertilizer && gameObject.name == "Fertilizer")
		{
			GetComponent<Button>().interactable = true;
			clicked = true;
		}
	
	}
	public void OnPointerClick(PointerEventData data)
	{
		savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
		if(clicked)
		{
			
			if(gameObject.name == "Irrigation")
			{
				
				harvest.irrigation = true;
				GetComponent<Button>().interactable = false;
				
				savings = savings - 200;
				
			}
			if(gameObject.name == "Pesticide")
			{
			
				harvest.pesticide = true;
				GetComponent<Button>().interactable = false;
				
				savings = savings - 200;
			}
			if(gameObject.name == "Fertilizer")
			{
			
				harvest.fertilizer = true;
				GetComponent<Button>().interactable = false;
				
				savings = savings - 200;
			}
			clicked = false;
		}
		GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text = "" + savings;
	}
}
