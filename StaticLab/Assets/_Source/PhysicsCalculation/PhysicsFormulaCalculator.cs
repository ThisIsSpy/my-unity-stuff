using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsFormulaCalculator
{
    private static PhysicsConstantsSO constants;

    public static float CalculateFormulaLawOfUniversalGravitation(float bodyMass1, float bodyMass2, float distBetweenBodies)
    {
        return constants.GravitationalConstant * bodyMass1 * bodyMass2 / Mathf.Pow(distBetweenBodies, 2);
    }
    public static float CalculateFormulaOfAccelerationOfGravity(float planetMass, float planetRadius, float heightAbovePlanet)
    {
        return constants.GravitationalConstant * planetMass / Mathf.Pow(planetRadius+heightAbovePlanet,2);
    }
    public static float CaluclateFormulaOfForceOfFriction(float coefficientOfFriction, float bodyMass)
    {
        return coefficientOfFriction * bodyMass * constants.AccelerationOfGravity;
    }
    public static float CalculateFormulaOfArchimedesLaw(float density, float bodyVolume)
    {
        return density * constants.AccelerationOfGravity * bodyVolume;
    }
    public static float CaluclateFormulaOfSpeed(float distance, float time)
    {
        return distance / time;
    }
    public static void Construct()
    {
        constants = Resources.Load<PhysicsConstantsSO>("SO/PhysicsConstantSO");
    }
}
