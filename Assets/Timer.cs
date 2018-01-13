using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {


   // Text[] DMY;

    public Text Date;


    // Use this for initialization
    void Start () {


        //   for (int i = 0; i < DMY.length() ; i++) {

        //Day = gameObject.GetComponent<Text>();
        //Month = gameObject.GetComponent<Text>();
        //Year = gameObject.GetComponent<Text>();
        //    }

        Date = gameObject.GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {

        //Day.text = System.DateTime.Today.Day.ToString();
        Date.text = System.DateTime.Today.ToString("dd/MM/yy") + ("\n") + System.DateTime.Now.ToString("hh:mm:ss");
    //    Date.text = System.DateTime.Now.ToString("hh:mm:ss");

  //      Debug.Log(System.DateTime.Today);
        //Month.text = System.DateTime.Today.Month.ToString();
        //Year.text = System.DateTime.Today.Year.ToString();
        
    }
}
