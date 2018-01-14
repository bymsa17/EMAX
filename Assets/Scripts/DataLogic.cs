using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLogic : MonoBehaviour
{
    public Dropdown dropdown;
    /*public string languageSelect;
    public Text text;
    public int dropdownValue;*/

    public void Start()
    {
        dropdown = GetComponent<Dropdown>();
        //Debug.Log("Starting Dropdown Value : " + dropdown.value);
    }

    void Awake ()
    {      
        Language.Initialize();        
	}

    private void Update()
    {
        /*dropdownValue = dropdown.value;
        languageSelect = dropdown.options[dropdownValue].text;
        text.text = languageSelect;*/

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
