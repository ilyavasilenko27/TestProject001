using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buttons")]
public class ButtonManager : ScriptableObject
{
    public List<ButtonItem> buttonItems;

    public delegate void SceneName(Scenes scenes);
    public static event SceneName SceneLoad;

    public string GetName(ButtonType button)
    {
        string name = "Button";
        foreach (ButtonItem buttonItem in buttonItems)
        {
            if (button == buttonItem.button)
            {
                name = buttonItem.name;
            }
        }
        return name;
    }

    public void Click(ButtonType button)
    {
        switch (button)
        {
            case ButtonType.StartNew:
                Global.dataSave.CreateSaveCrystal();
                Global.dataSave.Save();
                SceneLoad?.Invoke(Scenes.Game);
                break;

            case ButtonType.Load:
                Global.dataSave.Load();
                SceneLoad?.Invoke(Scenes.Game);
                break;

            case ButtonType.Menu:
                Global.dataSave.Save();
                SceneLoad?.Invoke(Scenes.Menu);
                break;
            case ButtonType.Death:
                Global.dataSave.CreateSaveCrystal();
                Global.dataSave.Save();
                SceneLoad?.Invoke(Scenes.Death);
                break;
        }
    }
}

[System.Serializable]
public class ButtonItem
{
    public ButtonType button;
    public string name;
}

public enum ButtonType
{
    StartNew, Load, Menu, Death
}

public enum Scenes
{
    Menu, Game, Death
}
