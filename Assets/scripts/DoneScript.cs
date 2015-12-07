using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DoneScript : MonoBehaviour, IPointerClickHandler 
{

	// Use this for initialization
	Harvest harvest;
	Opportunity ops;
	int savings;
	void Start () {
	
		harvest = GameObject.Find ("Harvest").GetComponent<Harvest>();
		ops = GameObject.Find ("Opportunity").GetComponent<Opportunity>();

	}
	
	// Update is called once per frame
	void Update () {
		savings = int.Parse(GameObject.FindGameObjectWithTag("Savings").GetComponent<Text>().text);
	
	}
	public void OnPointerClick(PointerEventData data)
	{	
		if(savings<2000 || harvest.counter%3==0)
		{
			ops.display();
		}
		harvest.Init();
		Destroy(gameObject.transform.parent.gameObject);
		
		
	}
}