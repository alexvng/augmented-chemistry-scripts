using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

	public DataStorage persistent;

	void Start() {
	}

    public void ToSelector() {
		// Ctrl + shift + B in unity to see what the scenes are numbered as
		// or, file >> build settings
    	SceneManager.LoadSceneAsync(2);
    }

    public void ToExperiment1() {
    	persistent.set1();
    	SceneManager.LoadSceneAsync(0);
    }

    public void ToExperiment2() {
    	persistent.set2();
    	SceneManager.LoadSceneAsync(0);
    }

    public void ToExperiment3() {
    	persistent.set3();
    	SceneManager.LoadSceneAsync(0);
    }

    public void ToMenu() {
    	SceneManager.LoadSceneAsync(1);
    }
}
