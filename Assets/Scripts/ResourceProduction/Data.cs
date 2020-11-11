using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data", fileName ="ResourceProductionData")]
public class Data : ScriptableObject
{
    [SerializeField] ResourceAmount costs;
    [SerializeField] float costMultiplier = 1.1f;
    public float productionTime = 1f;

    [SerializeField] ResourceAmount production;
    [SerializeField] float productionMultiplier = 1.05f;

    public ResourceAmount getActualCosts (int amount)
    {
        var result = costs;
        result.amount = Mathf.RoundToInt(amount * Mathf.Pow(costMultiplier, amount));
        return result;
    }

    public ResourceAmount getProductionAmount(int upgradeAmount, int unitCount)
    {
        var result = production;
        result.amount = Mathf.RoundToInt(upgradeAmount * Mathf.Pow(productionMultiplier, upgradeAmount) * unitCount);
        return result;
    }
}
