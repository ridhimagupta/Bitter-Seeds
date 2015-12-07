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
	int flag=-1;
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
		GetComponent<Button>().interactable = true;
		clicked = true;
		flag=-1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
		if(!harvest.irrigation && gameObject.name == "Irrigation")
		{
			if(savings>=Icost)
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
			
		if(!harvest.pesticide && gameObject.name == "Pesticide" )
		{
			if(savings>=Pcost)
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
		if(!harvest.fertilizer && gameObject.name == "Fertilizer" )
		{
			if(savings>=Fcost)
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

	
	}
	public void OnPointerClick(PointerEventData data)
	{
		
		if(clicked)
		{
			
			if(gameObject.name == "Irrigation"  && savings>=Icost && !harvest.irrigation)
			{
				guiOn = true;
				harvest.irrigation = true;
				GetComponent<Button>().interactable = false;
				savings = savings - Icost;
				flag=1;
				
			}
			if(gameObject.name == "Pesticide" && savings>=Pcost && !harvest.pesticide)
			{
				guiOn = true;
				harvest.pesticide = true;
				GetComponent<Button>().interactable = false;
				
				savings = savings - Pcost;
				flag=1;
			}
			if(gameObject.name == "Fertilizer" && savings>=Fcost && !harvest.fertilizer)
			{
				guiOn = true;
				harvest.fertilizer = true;
				GetComponent<Button>().interactable = false;
			
				savings = savings - Fcost;
				flag=1;
			}
			clicked = false;
			GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text = "" + savings;
			
		}
	}
	
	void OnGUI()
	{ 
		if (guiOn && flag==1)
		{ 
			
			GUI.Window(0, windowRect, DoMyWindow, gameObject.name + " done");
				
		} 
	}
	void DoMyWindow(int windowID) {
		if (GUI.Button(new Rect((windowRect.xMax-windowRect.xMin-100)/2, 20, 100, 20), "OK"))
		{
			Debug.Log ("MyWindow");
			guiOn = false;
			flag=-1;
			
		}
		
	}
}
