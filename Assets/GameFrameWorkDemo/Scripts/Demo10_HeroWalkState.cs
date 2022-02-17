using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameFramework.Fsm;

public class Demo10_HeroWalkState : FsmState<Demo10_HeroLogic>
{
    protected override void OnDestroy(IFsm<Demo10_HeroLogic> fsm)
    {
        base.OnDestroy(fsm);
    }

    protected override void OnEnter(IFsm<Demo10_HeroLogic> fsm)
    {
        base.OnEnter(fsm);
        Log.Debug("Enter walk state");

    }

    protected override void OnInit(IFsm<Demo10_HeroLogic> fsm)
    {
        base.OnInit(fsm);
    }

    protected override void OnLeave(IFsm<Demo10_HeroLogic> fsm, bool isShutdown)
    {
        base.OnLeave(fsm, isShutdown);
    }

    protected override void OnUpdate(IFsm<Demo10_HeroLogic> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        float inputVertical = Input.GetAxis("Vertical");
        if (inputVertical != 0)
        {
            fsm.Owner.ForWard(elapseSeconds * inputVertical);
        }
        else
        {
            ChangeState<Demo10_HeroIdleState>(fsm);
        }

    }
}
