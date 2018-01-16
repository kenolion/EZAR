using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class ModelSettings : MonoBehaviour
{

    public GameObject model;
    public Dropdown ModelsChoiceDropdown;

    private GameObject Dog;
    private GameObject Cow;
    private GameObject Horse;
    public GameObject modelDialog;

    public DownloadAsset dlAsset;

    void Start()
    {
        //Dog = (GameObject)Resources.Load("Dog");
        //Cow = (GameObject)Resources.Load("Cow");
        //Horse = (GameObject)Resources.Load("Horse");
        
        //model = Dog;
        dlAsset = GetComponent<DownloadAsset>();

    }

    public void Update()
    {
        
    }

    public void setModel()
    {

 
        dlAsset.Download(ModelsChoiceDropdown.options[ModelsChoiceDropdown.value].text);
     
        //if (GetComponent<Manager>().eventHandler.PrevGameObject != null)
        //{
        //    //Destroy(GetComponent<Manager>().eventHandler.PrevGameObject);
        //}
        //if (ModelsChoiceDropdown.value == 0)
        //{
        //    model = Dog;
        //}
        //else if (ModelsChoiceDropdown.value == 1)
        //{
        //    model = Cow;
        //}
        //else if(ModelsChoiceDropdown.value == 2)
        //{
        //    model = Horse;
        //}

    }






}
