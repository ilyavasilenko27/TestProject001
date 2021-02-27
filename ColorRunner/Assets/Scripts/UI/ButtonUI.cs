using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonUI : MonoBehaviour
{
    public ButtonType button;
    [SerializeField]
    private TextMeshProUGUI label;

    void Start()
    {
        label.text = Global.buttonManager.GetName(button);
    }

    public void Click()
    {
        Global.buttonManager.Click(button);
    }
}
