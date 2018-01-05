using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLogic : MonoBehaviour
{
    public Dropdown dropdown;

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

    public void SetLanguage()
    {
        if(dropdown.options.ToString() == "English")
        {
            Language.SetLanguage(Language.Lang.enUS);
        }
        else if(dropdown.options.ToString() == "Castellano")
        {
            Language.SetLanguage(Language.Lang.esES);
        }
    }
}
