using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ResourceAmount
  {
    public int amount;
    public Resources resource;

  

public override string ToString()
{
    return amount.ToString() + " " + resource.name;
}

public bool isAffordable => resource.Owned >= amount;

    public void Create()
    {
        resource.Owned += amount;
    }
    public void Consume()
    {
        resource.Owned -= amount;
    }

    public ResourceAmount(int a, Resources re)
    {
        amount = a;
        resource = re;
    }

}


