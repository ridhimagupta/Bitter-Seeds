using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Harvest : MonoBehaviour, IPointerClickHandler 
{

	// Use this for initialization
	public bool onClick = true;    
	bool paused;
	GameObject reports;
	Transform[] transforms;
	GameObject[] children;
	public int Wheat, BTcotton, Cotton, Rice;
	public int WheatPrice, BTCottonPrice, CottonPrice, RicePrice;
	public bool irrigation, fertilizer, pesticide, harvest;
	BlocksController bc;
	int houseExpenditures;
	int savings;
	int totalSavings;
	
	void Start () 
	{
		
		bc = GameObject.Find ("Blocks").GetComponent<BlocksController>();
		paused = false;
		
		Init ();
		
	}
	public void Init()
	{
		harvest = false;
		Wheat = 0;
		BTcotton = 0;
		Cotton = 0;
		Rice = 0;
		WheatPrice = 500;
		BTCottonPrice = 500;
		CottonPrice = 500;
		RicePrice = 500;
		houseExpenditures = 1500;
		irrigation = false;
		fertilizer = false;
		pesticide = false;
		savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
		Debug.Log (savings);
		foreach(GameObject block in bc.blocks)
		{
			block.GetComponent<BlockProperties>().isPlanted=false;
			block.GetComponent<BlockProperties>().crop = null;
			if(block.transform.childCount>0)
				Destroy(block.transform.GetChild(0).gameObject);
		}
		reports = (GameObject)Instantiate(Resources.Load("Reports"));
		children = new GameObject[reports.transform.childCount];
		int i = 0;
		foreach(Transform child in reports.transform)
		{
//			
//			
//			if(child.name=="LowPricesReport")
//			{
//				
//			}
			children[i] = child.gameObject;
			i++;
		}
		
	}
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log(savings);
		if(savings<houseExpenditures)
		{
			Debug.Log ("You do not have enough savings. Game over");
			//GameObject GameOver = (GameObject)Instantiate(Resources.Load("GameOver"));
			
			//crop.transform.position = new Vector3(block.transform.position.x,block.transform.position.y,block.transform.position.z);
			//crop.transform.parent = block.transform;
		}
		
	}
	public void OnPointerClick(PointerEventData data)
	{
		harvest = true;
		//Debug.Log ("Harvest");
		int r = Random.Range(0,children.Length);
		GameObject report = children[r];
		
		report.transform.SetParent(gameObject.transform.parent.parent.parent);//;
		report.transform.position = gameObject.transform.parent.parent.parent.position;
		
		
		if(report.name=="LowPricesReport")
		{
			WheatPrice = 600;
			BTCottonPrice = 850; 
			CottonPrice = 850;
			RicePrice = 750;
		}
		
		else if(report.name=="InfestationReport")
		{
			WheatPrice = 200;
			BTCottonPrice = 250; 
			CottonPrice = 0;
			RicePrice = 250;
		}
		
		else if(report.name=="DroughtReport")
		{
			WheatPrice = 300;
			BTCottonPrice = 200; 
			CottonPrice = 200;
			RicePrice = 100;
		}
		int sum=Wheat*WheatPrice + BTcotton*BTCottonPrice + Cotton*CottonPrice + Rice*RicePrice;
		savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
		savings = savings + sum - houseExpenditures;
		totalSavings = sum - houseExpenditures;
		report.transform.FindChild("Amount").gameObject.GetComponent<Text>().text = "" + sum;
		report.transform.FindChild("TotalSavings").gameObject.GetComponent<Text>().text = "" + totalSavings;
		GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text = "" + savings;
		foreach(Transform child in report.transform)
		{

			if(child.name=="WheatNumber")
				child.GetComponent<Text>().text = "" + Wheat + " X " + WheatPrice + " = Rs. " + Wheat*WheatPrice;
			else if(child.name=="BTNumber")
				child.GetComponent<Text>().text = "" + BTcotton +  " X " + BTCottonPrice + " = Rs. " + BTcotton*BTCottonPrice ;
			else if(child.name=="CottonNumber")
				child.GetComponent<Text>().text = "" + Cotton + " X " + CottonPrice + " = Rs. " + Cotton*CottonPrice;
			else if(child.name=="RiceNumber")
				child.GetComponent<Text>().text = "" + Rice + " X " + RicePrice + " = Rs. " + Rice*RicePrice;
			
		}
		//GameObject.Find("Wheat");
		paused = true;	
		//Init ();
	}
//	private string ResolveTextSize(string input, int lineLength){
//		
//		// Split string by char " "         
//		string[] words = input.Split(" "[0]);
//		
//		// Prepare result
//		string result = "";
//		
//		// Temp line string
//		string line = "";
//		
//		// for each all words        
//		foreach(string s in words){
//			// Append current word into line
//			string temp = line + " " + s;
//			
//			// If line length is bigger than lineLength
//			if(temp.Length > lineLength){
//				
//				// Append current line into result
//				result += line + "\n";
//				// Remain word append into new line
//				line = s;
//			}
//			// Append current word into current line
//			else {
//				line = temp;
//			}
//		}
//		
//		// Append last line into result        
//		result += line;
//		
//		// Remove first " " char
//		return result.Substring(1,result.Length-1);
//	}
}
