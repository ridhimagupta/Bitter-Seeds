using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IPF : MonoBehaviour, IPointerClickHandler
{

	// Use this for initialization
	Harvest harvest;
	int savings;
	bool clicked;
	public Rect windowRect; 
	int Icost, Pcost, Fcost;
	//public bool done = false;
	bool guiOn;
	Rect rect;
	void Start () 
	{
		harvest = GameObject.Find ("Harvest").GetComponent<Harvest>();
		guiOn = false;
		clicked = true;
		int width = 300, height = 50;
		Icost = 4000;
		Pcost = 600;
		Fcost = 250;
		windowRect = new Rect((Screen.width-width)/2,(Screen.height-height)/2,width,height);
		Debug.Log(Screen.height);
		savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!harvest.irrigation && gameObject.name == "Irrigation" && savings>=Icost)
		{
			GetComponent<Button>().interactable = true;

			clicked = true;
		}
		else
		{
			GetComponent<Button>().interactable = false;
			clicked = false;
		}
			
		if(!harvest.pesticide && gameObject.name == "Pesticide" && savings>=Pcost)
		{
			GetComponent<Button>().interactable = true;
			clicked = true;
		}
		else
		{
			GetComponent<Button>().interactable = false;
			clicked = false;
		}
		if(!harvest.fertilizer && gameObject.name == "Fertilizer" && savings>=Fcost)
		{
			GetComponent<Button>().interactable = true;
			clicked = true;
		}
		else
		{
			GetComponent<Button>().interactable = false;
			clicked = false;
		}
	
	}
	public void OnPointerClick(PointerEventData data)
	{
		savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
		
		
		if(clicked)
		{
			
			if(gameObject.name == "Irrigation"  && savings>=Icost && !harvest.irrigation)
			{
				guiOn = true;
				harvest.irrigation = true;
				GetComponent<Button>().interactable = false;
				
				savings = savings - Icost;
				
				
			}
			if(gameObject.name == "Pesticide" && savings>=Pcost && !harvest.pesticide)
			{
				guiOn = true;
				harvest.pesticide = true;
				GetComponent<Button>().interactable = false;
				
				savings = savings - Pcost;
			}
			if(gameObject.name == "Fertilizer" && savings>=Fcost && !harvest.fertilizer)
			{
				guiOn = true;
				harvest.fertilizer = true;
				GetComponent<Button>().interactable = false;
			
				savings = savings - Fcost;
			}
			clicked = false;
			GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text = "" + savings;
			guiOn = false;
		}
	}
	
	void OnGUI()
	{ 
		if (guiOn)
		{ 
			GUI.Window(0, windowRect, DoMyWindow, gameObject.name + " done");
			
		} 
	}
	void DoMyWindow(int windowID) {
		if (GUI.Button(new Rect(windowRect.x-windowRect.width/2, 20, 100, 20), "OK"))
		{
			guiOn = false;
			
		}
		
	}
}
