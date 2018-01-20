using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLogic : MonoBehaviour
{
    public Dropdown dropdown;

    public void Start()
    {
        dropdown = GetComponentInChildren<Dropdown>();
        Language.SetLanguage(Language.Lang.enUS);
    }

    void Awake ()
    {      
        Language.Initialize();        
	}

    private void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Language.SetLanguage(Language.Lang.esES);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Language.SetLanguage(Language.Lang.enUS);
        }*/
    }
    
    public void SetLanguage()
    {
        if(dropdown.value == 0)
        {
            Language.SetLanguage(Language.Lang.enUS);
        }
        else if(dropdown.value == 1)
        {
            Language.SetLanguage(Language.Lang.esES);
        }
    }
}
