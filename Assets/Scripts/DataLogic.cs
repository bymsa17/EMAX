using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLogic : MonoBehaviour
{
	// Use this for initialization
	void Awake ()
    {      
        Language.Initialize();        
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Language.SetLanguage(Language.Lang.esES);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Language.SetLanguage(Language.Lang.enUS);
        }
    }
}
