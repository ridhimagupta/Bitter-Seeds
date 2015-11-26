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
	Harvest harvest;
	void Start()
	{
		bc = GameObject.Find ("Blocks").GetComponent<BlocksController>();
		harvest = GameObject.Find ("Harvest").GetComponent<Harvest>();
		
		savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
		
		if(gameObject.name == "Cotton")
		{
			price = harvest.CottonPrice;
		}
		else if(gameObject.name == "Wheat")
		{
			price = harvest.WheatPrice;
		}
		else if(gameObject.name == "BTCotton")
		{
			price = harvest.BTCottonPrice;
		}
		
	}
	public void OnPointerClick(PointerEventData data)
	{      
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
					savings -= price;
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
		
	}
}