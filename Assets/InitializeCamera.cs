using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class InitializeCamera : MonoBehaviour
{


    float mTransitionCursor;
    BlackMaskBehaviour mBlackMask;
    MixedRealityController.Mode mCurrentMode = MixedRealityController.Mode.HANDHELD_AR;

    // Use this for initialization

    public void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Init);

    }

    public void Start()
    {
        //Init();
    }

    public void Init()
    {

        mTransitionCursor = 0;

        mBlackMask = FindObjectOfType<BlackMaskBehaviour>();
        SetBlackMaskVisible(false, 0);

        VideoBackgroundManager.Instance.SetVideoBackgroundEnabled(true);
       

        MixedRealityController.Instance.SetMode(mCurrentMode);

    }

    public void OnDisable()
    {
        VideoBackgroundManager.Instance.SetVideoBackgroundEnabled(false);
        
    }


    void SetBlackMaskVisible(bool visible, float fadeFactor)
    {
        if (mBlackMask)
        {
            mBlackMask.GetComponent<Renderer>().enabled = visible;
            mBlackMask.SetFadeFactor(fadeFactor);
        }
    }

}
