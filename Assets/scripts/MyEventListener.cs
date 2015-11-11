using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyEventListener : MonoBehaviour, IPointerClickHandler
{
	private float clickTime;            // time of click
	public bool onClick = true;            // is click allowed on button?
	public bool onDoubleClick = false;    // is double-click allowed on button?
	GameObject[] blocks;
	
	public void OnPointerClick(PointerEventData data)
	{      
		int clickCount = 1; // single click
		
		// get interval between this click and the previous one (check for double click)
		float interval = data.clickTime - clickTime;
		
		// if this is double click, change click count
		if (interval < 1.5 && interval > 0)
			clickCount = 2;
		
		// reset click time
		clickTime = data.clickTime;
		
		// single click
		if (onClick)
		{
			blocks = GameObject.FindGameObjectsWithTag("Block");
			for(int i=0;i<blocks.Length;i++)
			{
				for(int j=i;j<blocks.Length;j++)
				{
					if(int.Parse(blocks[i].name)>int.Parse(blocks[j].name))
					{
						GameObject temp = blocks[i];
						blocks[i]=blocks[j];
						blocks[j]=temp;	
					}
				}
				
			}
			foreach(GameObject block in blocks)
			{
				if(block.GetComponent<BlockProperties>().isPlanted==false)
				{
				
					block.GetComponent<BlockProperties>().isPlanted=true;
					
					GameObject crop = (GameObject)Instantiate(Resources.Load(gameObject.name));
					crop.transform.position = new Vector3(block.transform.position.x,block.transform.position.y,block.transform.position.z);
					
					int score = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
				
					GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text = "" + score;
						break;
					
				}
			}
		}
		
		// double click
		if (onDoubleClick && clickCount == 2)
		{
			// enter code here
		}
		
	}
}