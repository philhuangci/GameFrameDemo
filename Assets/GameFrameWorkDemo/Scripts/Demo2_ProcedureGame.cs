using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo2_ProcedureGame : ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Debug("start game procedure, process game logic here");

        Tutorial.GameEntry.Entity.ShowEntity<Demo6_HeroLogic>(1, "Assets/Demo6/CubeEntity.prefab", "EntityGroup");


    }
}
