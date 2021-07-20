using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpdateReadout : MonoBehaviour
{
    public TMP_Text rTimeSeconds;
    public TMP_Text rFireState;
	public TMP_Text rTempValue;
    public TMP_Text rJoules;

    public Slider tTempSlider;
    public Toggle tFlameToggle;
    public Toggle tPauseToggle;
	
	public Button reset;

    private float fTimeRaw;
    private float joulesAccumulator;
    private bool bPaused;

    public DataStorage persistent;

    void Start()
    {
        bPaused = false;
        InvokeRepeating("UpdateJoules", 0.0f, 1.0f);
    }

    void Update()
    {	
    	if (!bPaused) {
            fTimeRaw += Time.deltaTime;
        }

        rTimeSeconds.text = string.Format("Time elapsed: {0:00}:{1:00}",
            Mathf.FloorToInt(fTimeRaw / 60), Mathf.FloorToInt(fTimeRaw % 60));

        UpdateTemp();
    }

    public void UpdateFlame() {
        if (tFlameToggle.isOn) {
            rFireState.text = "Burner lit";
        } else {
            rFireState.text = "Burner extinguished";
        }
    }

    public void UpdateTemp() {
        if (tFlameToggle.isOn) {
            rTempValue.text = "Burner Heat Input: " + (tTempSlider.value * 0.4f + 0.8f).ToString("F2") + " MJ/s";
        } else {
            rTempValue.text = "Burner Heat Input: 0 MJ/s";
        }
    }

    public void UpdatePauseState() {
        bPaused = tPauseToggle.isOn;
    }

    public void UpdateJoules() {

        if (tFlameToggle.isOn && !bPaused) {
            joulesAccumulator += (tTempSlider.value * 2f + 0.2f);
        }

        if (persistent.getActive() == 1) {
            // F2 means 2 decimal places displayed
            // 0.1, 0.5, 2, are arbitary, should be changed
            rJoules.text = "Fluid Temperature: " + (joulesAccumulator * 0.1).ToString("F2") + "°C";
        } else if (persistent.getActive() == 2) {
            rJoules.text = "Fluid Temperature: " + (joulesAccumulator * 0.5).ToString("F2") + "°C";
        } else if (persistent.getActive() == 3) {
            rJoules.text = "Fluid Temperature: " + (joulesAccumulator * 2).ToString("F2") + "°C";
        }
    }
	
	public void Reset() 
	{
        joulesAccumulator = 0;
		fTimeRaw = 0;
        UpdateJoules();
    }

}
