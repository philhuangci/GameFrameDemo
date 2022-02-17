using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using GameFramework.Entity;
using GameFramework.Fsm;

public class Demo10_HeroLogic : EntityLogic
{
    private GameFramework.Fsm.IFsm<Demo10_HeroLogic> m_HeroFsm;
    private FsmComponent Fsm = null;

    protected override void OnHide(bool isShutdown, object userData)
    {
        base.OnHide(isShutdown, userData);
    }

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        Fsm = UnityGameFramework.Runtime.GameEntry.GetComponent<FsmComponent>();

        // get all the hero states
        FsmState<Demo10_HeroLogic>[] heroStates = new FsmState<Demo10_HeroLogic>[]
            {
                new Demo10_HeroIdleState(),
                new Demo10_HeroWalkState(),
            };

        // create state mechine
        m_HeroFsm = Fsm.CreateFsm<Demo10_HeroLogic>(this, heroStates);
        m_HeroFsm.Start<Demo10_HeroIdleState>();


    }

    protected override void OnShow(object userData)
    {
        base.OnShow(userData);
    }

    protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);

        float inputHoricental = Input.GetAxis("Horizontal");
        if (inputHoricental != 0)
        {
            transform.Rotate(new Vector3(0, inputHoricental * 3, 0));
        }
    }

    public void ForWard(float distance)
    {
        transform.position += transform.forward * distance * 5;
    }

}
