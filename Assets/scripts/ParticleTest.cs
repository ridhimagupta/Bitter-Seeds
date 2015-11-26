using UnityEngine;
using System.Collections;

public class ParticleTest : MonoBehaviour {

	// Use this for initialization
	ParticleSystem ps;
	int flag=0;
	void Start () 
	{
		
		ps = GetComponent<ParticleSystem>();
		//ps.enableEmission=false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetKey(KeyCode.A))
		{
			ps.Emit(10);
			
		}
//		if(flag==1)
//		{
//			
//			ps.Play();
//			Debug.Log("Laddu");
//			
//			flag=0;
//			ps.enableEmission=false;
////			if(ps.particleCount>10)
////			{
////				ps.enableEmission=false;
////				flag=0;
////			}
//		} 
		
		
	}
}
