using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameHandler : MonoBehaviour
{
    public ParticleSystem flameParticles;
    public Toggle tFlameToggle;
    public Toggle tPauseToggle;

    void Start() 
    {
    	flameParticles.Stop();
    }

    void Update() 
    {
    	if (tPauseToggle.isOn) 
	{
            	Time.timeScale = 0;
    		
    	} 
        else 
	{
		Time.timeScale = 1;
    		
    	}
        if (tFlameToggle.isOn) 
	{
            	flameParticles.Play();
    		
    	} 
        else 
	{
		flameParticles.Stop();
    		
    	}
    }
}
