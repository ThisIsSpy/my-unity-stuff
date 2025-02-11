using HotdogSystem.Decorator.DecoratorTypes;
using HotdogSystem.HotdogTypes;
using HotdogSystem;
using UnityEngine;
using HotdogSystem.Decorator;

namespace Core
{

    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private HotdogSO selectedHotdogSO;
        [SerializeField] private HotdogDecoratorSO selectedDecoratorSO;
        [SerializeField] private bool isDecoratorNeeded;
        private Hotdog selectedHotdog;
        private HotdogDecorator selectedDecorator;

        private void Start()
        {
            switch(selectedHotdogSO.Type)
            {
                case HotdogType.ClassicHotdog:
                    ClassicHotdog classicHotdog = new(selectedHotdogSO.Name, selectedHotdogSO.Cost, selectedHotdogSO.Mass);
                    selectedHotdog = classicHotdog;
                    break;
                case HotdogType.CesarHotdog:
                    CesarHotdog cesarHotdog = new(selectedHotdogSO.Name, selectedHotdogSO.Cost, selectedHotdogSO.Mass);
                    selectedHotdog = cesarHotdog;
                    break;
                case HotdogType.MeatHotdog:
                    MeatHotdog meatHotdog = new(selectedHotdogSO.Name, selectedHotdogSO.Cost, selectedHotdogSO.Mass);
                    selectedHotdog = meatHotdog;
                    break;
                default:
                    selectedHotdog = null;
                    break;
            }

            if(isDecoratorNeeded)
            {
                switch (selectedDecoratorSO.Type)
                {
                    case DecoratorType.PicklesDecorator:
                        PicklesDecorator picklesDecorator = new(selectedHotdog, selectedDecoratorSO.Name, selectedDecoratorSO.Cost, selectedDecoratorSO.Mass);
                        selectedDecorator = picklesDecorator;
                        break;
                    case DecoratorType.SweetOnionDecorator:
                        SweetOnionDecorator sweetOnionDecorator = new(selectedHotdog, selectedDecoratorSO.Name, selectedDecoratorSO.Cost, selectedDecoratorSO.Mass);
                        selectedDecorator = sweetOnionDecorator;
                        break;
                }
            }
            else
            {
                selectedDecorator = new(selectedHotdog);
            }
            Debug.Log($"You have recieved a {selectedDecorator.GetMass()}g {selectedDecorator.GetName()} for a low price of {selectedDecorator.GetCost()} zimbabwean dollars");
        }
    }    
}
