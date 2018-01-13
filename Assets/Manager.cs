using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Manager : MonoBehaviour
{

    [SerializeField]
    public GameObject[] panels;
    public GameObject parentPanel;

    public UDTEventHandler eventHandler;
    public GameObject model;
    public ModelSettings modelSettings;

    public GameObject modelsParent;
    //private InitializeCamera initCam;
    //GameObject HomePanel;
    //GameObject SettingsPanel;
    //GameObject CameraPanel;
    //GameObject AboutPanel;

    public int currentTab;
    public int prevTab;
    private int keypressed;

    void Start()
    {
        modelSettings = GetComponent<ModelSettings>();

    }

    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (currentTab == 0)
                {
                    keypressed++;

                }
                Back();

                if (keypressed == 2) //double tap to exit
                {
                    keypressed = 0;
                    if (currentTab == 0)
                    {
                        Application.Quit();
                    }
                }
                return;
            }
        }
    }

    public void setCurrentTabToOne()
    {
        currentTab = 0;

        changePanel();
    }

    public void setCurrentTabToTwo()
    {
        currentTab = 1;

        changePanel();
    }
    public void setCurrentTabToThree()
    {
        currentTab = 2;

        changePanel();
    }


    public void setCurrentTabToFour()
    {
        currentTab = 3;
        changePanel();
    }
    public void setCurrentTabToFive()
    {
        prevTab = currentTab;  //save the prev tab b4 assign new tab
        currentTab = 4;
        changePanel();
    }
    public void setCurrentTabToSeven()
    {
        currentTab = 7;

        changePanel();
    }

    public void Back()
    {
        currentTab = prevTab;
        changePanel();
    }

    public void changePanel()
    {

        for (int i = 0; i < panels.Length; i++)
        {
            if (i != currentTab)
            {
                panels[i].SetActive(false);

            }
            else
            {
                panels[i].SetActive(true);
                //   panels[i].GetComponent<Text>().color = Color(1,1,1,1);
                if (currentTab != 2)
                {
                    parentPanel.SetActive(true);
                    panels[5].SetActive(false);
                }
            }

        }

    }

    public void setModel()
    {
        if (eventHandler.PrevGameObject == null)
        {
            if (modelsParent.transform.childCount == 1)
            {
                Destroy(modelsParent.transform.GetChild(0).gameObject);
            }
            Instantiate(modelSettings.model, modelsParent.transform);
        }
        else
        {
            Destroy(eventHandler.PrevGameObject.transform.GetChild(0).gameObject);
            Instantiate(modelSettings.model, eventHandler.PrevGameObject.transform);
        }
        StopAllCoroutines();
        modelSettings.modelDialog.GetComponent<CanvasGroup>().alpha = 1;
        modelSettings.modelDialog.transform.GetChild(0).GetComponent<Text>().text = modelSettings.model.name + " model selected";
        StartCoroutine(FadeOutQualityDialog());


        eventHandler.ImageTargetTemplate = model.GetComponent<ImageTargetBehaviour>();

    }

    public void StartCamera()
    {
        panels[5].SetActive(true);
        parentPanel.SetActive(false);


    }

    IEnumerator FadeOutQualityDialog() //feedback
    {
        yield return new WaitForSeconds(1f);
        CanvasGroup canvasGroup = modelSettings.modelDialog.GetComponent<CanvasGroup>();

        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            f = (float)Math.Round(f, 1);
            Debug.Log("FadeOut: " + f);
            canvasGroup.alpha = (float)Math.Round(f, 1);
            yield return null;
        }
    }


}
