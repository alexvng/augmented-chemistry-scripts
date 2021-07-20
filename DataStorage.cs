using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataStorage : MonoBehaviour
{
   	public static int activeLiquid; // 1=water, 2=purple, 3=ethanol

    void Start()
    {
        DontDestroyOnLoad(gameObject); // critical line, do not delete
        activeLiquid = 1;
    }

    public int getActive() {
        return activeLiquid;
    }

    public void set1() {
    	activeLiquid = 1;
        Debug.Log("1 gogo");
    }

    public void set2() {
    	activeLiquid = 2;
        Debug.Log("2 gogo");
    }

    public void set3() {
    	activeLiquid = 3;
        Debug.Log("3 gogo");
    }
}
