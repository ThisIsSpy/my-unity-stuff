using Flippers;
using Pinball;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private Flipper flipperLeft;
        [SerializeField] private Flipper flipperRight;
        [SerializeField] private PinballLauncher launcher;
        private int speed = 0;
        private bool hasBeenLaunched = false;
        private bool chargeBackwards = false;
        private int Speed {  get { return speed; } 
            set
            {
                speed = Mathf.Clamp(value, 0, 2000);
                if(speed == 2000) chargeBackwards = true;
                else if (speed == 0) chargeBackwards = false;
            } 
        }

        void Update()
        {
            ListenForFlipperInput();
            ListenForPinballChargeInput();
            
        }

        private void ListenForFlipperInput()
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                flipperLeft.RotateFlipper();
            }
            if(Input.GetKeyDown(KeyCode.X)) 
            { 
                flipperRight.RotateFlipper();
            }
        }

        private void ListenForPinballChargeInput()
        {
            if (Input.GetKey(KeyCode.Space) && !hasBeenLaunched)
            {
                if (!chargeBackwards) Speed++;
                else Speed--;
                launcher.UpdateSpeedDisplay(Speed);
            }
            else if (!Input.GetKey(KeyCode.Space) && speed > 0f && !hasBeenLaunched)
            {
                Debug.Log("no more speed");
                hasBeenLaunched = true;
                launcher.LaunchPinball(Speed);
            }
        }
    }
}