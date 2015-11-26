using UnityEngine;
using System.Collections;

public class BlocksController : MonoBehaviour {

	// Use this for initialization
	public GameObject[] blocks;
	void Start () 
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
