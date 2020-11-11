using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSetUp : MonoBehaviour
{
    public Data[] datas;
    public ResourceProducer prefab;
    void Start()
    {
        foreach (var productioUnit in datas)
        {
            var instance = Instantiate(prefab, transform);
            instance.Setup(productioUnit);
        }
    }
  
}
