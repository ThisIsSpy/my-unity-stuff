using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "PhysicsFormulaViewDataSO", menuName = "SO/Physics Formula View Data SO", order = 3)]
public class PhysicsFormulaViewDataSO : ScriptableObject
{
    [SerializeField] private List<string> formulas;
    public List<string> Formulas { get { return formulas; } private set { } }
    //[SerializeField] private string _formulaLawOfUniversalGravitation;
    //[SerializeField] private string _formulaOfAccelerationOfGravity;
    //[SerializeField] private string _formulaOfForceOfFriction;
    //[SerializeField] private string _formulaOfArchimedesLaw;
    //[SerializeField] private string _formulaOfSpeed;

    //public string FormulaLawOfUniversalGravitation { get { return _formulaLawOfUniversalGravitation;} private set { } }
    //public string FormulaOfAccelerationOfGravity { get {  return _formulaOfAccelerationOfGravity;} private set { } }
    //public string FormulaOfForceOfFriction { get { return _formulaOfForceOfFriction;} private set { } }
    //public string FormulaOfArchimedesLaw { get { return _formulaOfArchimedesLaw;} private set { } }
    //public string FormulaOfSpeed { get {  return _formulaOfSpeed;} private set { } }
}
