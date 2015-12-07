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
	int[] livingExpenditures;
	int fixedExpenditures;
	int savings;
	int totalSavings;
	string[] livingExpenseText;
	void Start () 
	{
		
		bc = GameObject.Find ("Blocks").GetComponent<BlocksController>();
		paused = false;
		Init ();
		livingExpenseText = new string[]{
		
		"Living expenses stayed close to the average expenses this year.",
		"There was a high inflation rate this year, and living expenses increased by Rs. 1200.",
		"Due to ill health of a family member, you had to pay Rs. 2000 for treatment.",
		"Due to ill health of a family member, you had to pay Rs. 3000 for treatment."};
		livingExpenditures = new int[]{fixedExpenditures, fixedExpenditures+1200, fixedExpenditures + 2000, fixedExpenditures + 3000};
		
		
		
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
		fixedExpenditures=1000;
		//livingExpenditures = 1500;
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

			children[i] = child.gameObject;
			i++;
		}
		
	}
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log(savings);
//		if(savings<0)
//		{
//			
//			Application.LoadLevel(1);
//			//GameObject GameOver = (GameObject)Instantiate(Resources.Load("GameOver"));
//			
//			//crop.transform.position = new Vector3(block.transform.position.x,block.transform.position.y,block.transform.position.z);
//			//crop.transform.parent = block.transform;
//		}
		
	}
	public void OnPointerClick(PointerEventData data)
	{
		harvest = true;
		//Debug.Log ("Harvest");
		int r = Random.Range(0,children.Length);
		GameObject report = children[r];
		
		int r2 = Random.Range(0,livingExpenseText.Length*4);
		r2 = r2 - livingExpenseText.Length*3;
		if(r2<0)
			r2=0;
		report.transform.SetParent(gameObject.transform.parent.parent.parent);//;
		report.transform.position = gameObject.transform.parent.parent.parent.position;
		//livingExpenditures[r2] = 1000;
		
		if(report.name=="LowPricesReport")
		{
			WheatPrice = 200;
			BTCottonPrice = 400; 
			CottonPrice = 250;
			RicePrice = 350;
			
		}
		
		else if(report.name=="InfestationReport")
		{
			WheatPrice = 500;
			BTCottonPrice = 0; 
			CottonPrice = 600;
			RicePrice = 800;
			
		}
		
		else if(report.name=="DroughtReport")
		{
			WheatPrice = 300;
			BTCottonPrice = 200; 
			CottonPrice = 200;
			RicePrice = 100;
			
		}
		else if(report.name=="GoodPricesReport")
		{
			WheatPrice = 600;
			BTCottonPrice = 1000; 
			CottonPrice = 700;
			RicePrice = 900;
			
		}
		int sum=Wheat*WheatPrice + BTcotton*BTCottonPrice + Cotton*CottonPrice + Rice*RicePrice;
		savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
		savings = savings + sum - livingExpenditures[r2];
		//totalSavings = sum - livingExpenditures;
		report.transform.FindChild("Amount").gameObject.GetComponent<Text>().text = "" + sum;
		report.transform.FindChild("Expenditure").gameObject.GetComponent<Text>().text = "" + livingExpenditures[r2];
		int difference = sum - livingExpenditures[r2];
		report.transform.FindChild("Difference").gameObject.GetComponent<Text>().text = "" + difference;
		GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text = "" + savings;
		foreach(Transform child in report.transform)
		{
			if(child.name=="LivingExpenses")
				child.GetComponent<Text>().text = livingExpenseText[r2];
			if(child.name=="WheatNumber")
				child.GetComponent<Text>().text = "Wheat " + Wheat + " X " + WheatPrice + " = Rs. " + Wheat*WheatPrice;
			else if(child.name=="BTNumber")
				child.GetComponent<Text>().text = "BTNumber " + BTcotton +  " X " + BTCottonPrice + " = Rs. " + BTcotton*BTCottonPrice;
			else if(child.name=="CottonNumber")
				child.GetComponent<Text>().text = "Cotton " + Cotton + " X " + CottonPrice + " = Rs. " + Cotton*CottonPrice;
			else if(child.name=="RiceNumber")
				child.GetComponent<Text>().text = "Rice " + Rice + " X " + RicePrice + " = Rs. " + Rice*RicePrice;
			
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
