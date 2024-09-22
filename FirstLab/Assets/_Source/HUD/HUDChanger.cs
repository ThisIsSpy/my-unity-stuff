using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDChanger : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI MovementHUD;

    public void ChangeText(bool check)
    {
        if (check)
        {
            MovementHUD.text = ".";
        }
        else
        {
            MovementHUD.text = "Disabled";
        }
    }
}
