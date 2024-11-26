using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private PhysicsFormulaViewDataSO formulas;
    [SerializeField] private List<TextMeshProUGUI> formulaTextBoxes;
    private void Start()
    {
        PhysicsFormulaCalculator.Construct();
        for (int i = 0; i < formulaTextBoxes.Count; i++)
        {
            formulaTextBoxes[i].text = formulas.Formulas[i];
        }
    }
}
