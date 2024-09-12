using InputSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    public Player Player { get; private set; }
    public InputListener Listener { get; private set; }
    public HUDChanger Changer { get; private set; }
    void Awake()
    {
        Player = Object.FindObjectOfType<Player>().GetComponent<Player>();
        Listener = Player.GetComponentInChildren<InputListener>();
        Changer = Player.GetComponentInChildren<HUDChanger>();
        Listener.SetInvoker(new(Player));
        Listener.SetHUDChanger(Changer);
        
    }
}
