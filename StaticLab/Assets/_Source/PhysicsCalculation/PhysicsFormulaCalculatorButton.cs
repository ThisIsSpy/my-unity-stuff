using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhysicsFormulaCalculatorButton : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] List<TMP_InputField> fields;

    public void Calculate()
    {
        foreach (var field in fields)
        {
            if (field.text == string.Empty)
            {
                field.text = "1";
            }
        }
        switch (id)
        {
            case 0:
                Debug.Log(PhysicsFormulaCalculator.CalculateFormulaLawOfUniversalGravitation(float.Parse(fields[0].text), float.Parse(fields[1].text), float.Parse(fields[2].text)));
                break;
            case 1:
                Debug.Log(PhysicsFormulaCalculator.CalculateFormulaOfAccelerationOfGravity(float.Parse(fields[0].text), float.Parse(fields[1].text), float.Parse(fields[2].text)));
                break;
            case 2:
                Debug.Log(PhysicsFormulaCalculator.CaluclateFormulaOfForceOfFriction(float.Parse(fields[0].text), float.Parse(fields[1].text)));
                break;
            case 3:
                Debug.Log(PhysicsFormulaCalculator.CalculateFormulaOfArchimedesLaw(float.Parse(fields[0].text), float.Parse(fields[1].text)));
                break;
            case 4:
                Debug.Log(PhysicsFormulaCalculator.CaluclateFormulaOfSpeed(float.Parse(fields[0].text), float.Parse(fields[1].text)));
                break;
        }
    }
}
