using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;


public class Demo6_HeroLogic : EntityLogic
{
    protected Demo6_HeroLogic()
    {

    }

    protected override void OnShow(object userData)
    {
        base.OnShow(userData);
        Log.Debug("show hero entity");

    }
}

