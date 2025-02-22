using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBlueCoin : ItemCollectableBase
{
    [SerializeField] private GameObject coinParticle;

    protected override void OnCollect()
    {
        var obj = Instantiate(coinParticle, transform.position, Quaternion.identity);
        obj.transform.SetParent(null);
        Destroy(obj, 3f);
        base.OnCollect();
        ItemManager.Instance.AddBlueCoins();
        InterfaceInformation.Instance.UpdateInterface();
    }
}
