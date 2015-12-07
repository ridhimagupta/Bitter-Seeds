using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyEventListener : MonoBehaviour, IPointerClickHandler
{
	private float clickTime;            // time of click
	public bool onClick = true;            // is click allowed on button?
	public bool onDoubleClick = false;    // is double-click allowed on button?
	BlocksController bc;
	int init=0, savings;
	int price;
	bool guiOn;
	Harvest harvest;
	Rect windowRect;
	int flag;
	void Start()
	{
		bc = GameObject.Find ("Blocks").GetComponent<BlocksController>();
		harvest = GameObject.Find ("Harvest").GetComponent<Harvest>();
		guiOn = false;
		int width = 700, height = 80;
		savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
		windowRect = new Rect((Screen.width-width)/2,(Screen.height-height)/2,width,height);
		flag = -1;
		
	}
	public void OnPointerClick(PointerEventData data)
	{
		//Debug.Log (savings);		      
		if(onClick)
		{
			foreach(GameObject block in bc.blocks)
			{
				if(block.GetComponent<BlockProperties>().isPlanted==false)
				{
				
					block.GetComponent<BlockProperties>().isPlanted=true;
					block.GetComponent<BlockProperties>().crop = gameObject.name;
					
					if(gameObject.name=="Wheat")
						harvest.Wheat++;
					else if(gameObject.name=="BTCotton")
						harvest.BTcotton++;
					else if(gameObject.name=="Cotton")
						harvest.Cotton++;
					else if(gameObject.name=="Rice")
						harvest.Rice++;
					
					
					GameObject crop = (GameObject)Instantiate(Resources.Load(gameObject.name));
					crop.transform.position = new Vector3(block.transform.position.x,block.transform.position.y,block.transform.position.z);
					crop.transform.parent = block.transform;
					savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
					savings -= price;
					if(savings<harvest.WheatPrice)
					{
						guiOn = true;
						flag=-1;
						//Debug.Log ("Ghusa");
					}
					GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text = "" + savings;
						break;
					
				}
			}
		}	
		

		
	}
	void Update ()
	{
		savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
		
		if(bc.blocks[bc.blocks.Length-1].GetComponent<BlockProperties>().isPlanted==true || savings<price)
		{
		
			
			GetComponent<Button>().interactable=false;
			onClick = false;
			
		}
		else
		{
			GetComponent<Button>().interactable=true;
			onClick = true;
		}
		Debug.Log (flag);

		if(gameObject.name == "Wheat")
		{
			price = harvest.WheatPrice;
		}
		else if(gameObject.name == "Cotton")
		{
			price = harvest.CottonPrice;
		}
		else if(gameObject.name == "BTCotton")
		{
			price = harvest.BTCottonPrice;
		}
		else if(gameObject.name == "Rice")
		{
			price = harvest.RicePrice;
		}
		
		
	}
	void OnGUI()
	{ 
		if (guiOn && flag==-1)
		{ 
			
			GUI.Window(1, windowRect, DoMyWindow2, "You are out of funds, you must now take a loan. \nYour money will increase by Rs.3000, but your seasonal fixed expenditure will also increase by Rs.1000");
			Debug.Log ("MyWindow");
		} 
	}
	void DoMyWindow2(int windowID) {
		if (GUI.Button(new Rect((windowRect.xMax-windowRect.xMin-100)/2, 40, 100, 20), "OK"))
		{
			
			guiOn = false;
			savings = savings + 3000;
			GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text = "" + savings;
			harvest.fixedExpenditures=harvest.fixedExpenditures+1000;
			int fixedExpenditures = harvest.fixedExpenditures;
			harvest.livingExpenditures = new int[]{fixedExpenditures, fixedExpenditures+1200, fixedExpenditures + 2000, fixedExpenditures + 3000};
			flag = 1;
				
			
		}
		
	}
}