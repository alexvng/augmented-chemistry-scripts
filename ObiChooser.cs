using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Obi;


public class ObiChooser: MonoBehaviour 
{

	public ObiEmitter water;
	public ObiEmitter purple;
	public ObiEmitter ethanol;
		
	public Button drain;
	public Button spawn;

	public GameObject bucket;

	public DataStorage persistent;
	
	private float emissionSpeed = 2;
	private int timeB;

	void Start () 
	{
		timeB = 3000;
	}
	
	void Update () {
		 
		if (persistent.getActive() == 1 && Input.GetKey(KeyCode.W)) {
			water.speed = emissionSpeed;
			purple.speed = 0;
			ethanol.speed = 0;
		} else if (persistent.getActive() == 2 && Input.GetKey(KeyCode.W)) {
			purple.speed = emissionSpeed;
			water.speed = 0;
			ethanol.speed = 0;
		} else if(persistent.getActive() == 3 && Input.GetKey(KeyCode.W)) {
			ethanol.speed = emissionSpeed;
			water.speed = 0;
			purple.speed = 0;
		}
		else {
			purple.speed = 0;
			water.speed = 0;
			ethanol.speed = 0;
		}
	}
	
	public void Drain() 
	{
		bucket.SetActive(false);			
    }
	public void Spawn() 
	{
		bucket.SetActive(true);
			
    }
}
