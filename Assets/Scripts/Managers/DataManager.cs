using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Data
{
    public static string LoadTextFromResources(string pathfile)
    {
        TextAsset textAsset = Resources.Load(pathfile) as TextAsset;
        return textAsset.text;
    }

    public static List<string> ReadAllLinesFromString(string text)
    {
        StringReader strReader = new StringReader(text);
        List<string> lineList = new List<string>();

        while(true)
        {
            string line = strReader.ReadLine();
            if(line != null) lineList.Add(line);
            else break;
        }
        return lineList;
    }
}

public static class GameData
{

}

public static class TextData
{
    public static Dictionary<string, string> textData;
    /* Dictionary<TKey, TValue>
     * TValue: es el tipo de variable que almacena.
     * TKey: es el identificador con el que guardo el value.
     */

    public static void Initialize()
    {
        textData = new Dictionary<string, string>();
        //Leyendo el texto entero
        string textFromFile = Data.LoadTextFromResources("Data/TextFile");
        //Separando el texto en lineas
        List<string> allLines = Data.ReadAllLinesFromString(textFromFile);
        //Separando las columnas de cada linea
        for(int line = 1; line < allLines.Count; line++)
        {
            string[] colText = allLines[line].Split('\t');

            if(Language.language == Language.Lang.esES) textData.Add(colText[0], colText[1]);
            else textData.Add(colText[0], colText[2]);
            //Si hay mas idiomas, añadir aquí un if por cada uno de ellos.
        }

        UpdateUIText();
        UpdateDialogText();
    }

    public static string GetText(string key)
    {
        string value = "";
        textData.TryGetValue(key, out value);
        return value;
    }

    //UI TEXT
    public static List<LoadUIText> uiText;
    public static void AddUIText(LoadUIText ui)
    {
        if(uiText == null) uiText = new List<LoadUIText>();
        uiText.Add(ui);
        ui.LoadText();
    }
    public static void UpdateUIText()
    {
        if(uiText == null) return;
        /*foreach(LoadUIText ui in uiText)
        {
            ui.LoadText();
        }*/
        for(int i = 0; i < uiText.Count; i++)
        {
            uiText[i].LoadText();
        }
    }
    //DIALOG TEXT
    public static List<DialogText> dialogText;
    public static void AddDialogText(DialogText dialog)
    {
        if(dialogText == null) dialogText = new List<DialogText>();
        dialogText.Add(dialog);
    }
    static void UpdateDialogText()
    {
        if(dialogText == null) return;
        foreach(DialogText dialog in dialogText)
        {
            dialog.UpdateDialogLine();
        }
    }
}

public static class Language
{
    public enum Lang { none, esES, enUS };
    public static Lang language;

    public static void Initialize()
    {
        if(language == Lang.none)
        {
            if(Application.systemLanguage == SystemLanguage.English)
            {
                language = Lang.enUS;
            }
            else if(Application.systemLanguage == SystemLanguage.Spanish)
            {
                language = Lang.esES;
            }
            else language = Lang.enUS;
        }
        UpdateTextLagunage();
    }

    public static void SetLanguage(Lang newLanguage)
    {
        language = newLanguage;
        UpdateTextLagunage();
    }

    public static void UpdateTextLagunage()
    {
        TextData.Initialize();
    }
}
