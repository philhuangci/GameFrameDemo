using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameFramework;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using GameFramework.DataTable;
using UnityGameFramework.Editor;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo2_ProcedureMenu : ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Debug("enter menu");
        Tutorial.GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSucess);
        Tutorial.GameEntry.UI.OpenUIForm("Assets/Demo3/UI_Menu.prefab", "DefaultGroup", this);


        Tutorial.GameEntry.Event.Subscribe(UnityGameFramework.Runtime.LoadDataTableSuccessEventArgs.EventId, OnLoadSucess);
        Tutorial.GameEntry.Event.Subscribe(UnityGameFramework.Runtime.LoadDataTableFailureEventArgs.EventId, OnLoadFail);

        DataTableBase dataTableBase = Tutorial.GameEntry.DataTable.CreateDataTable(Type.GetType("DRHero"));
        dataTableBase.ReadData("Assets/Demo5/Hero.txt");
        Tutorial.GameEntry.Entity.ShowEntity<Demo10_HeroLogic>(1, "Assets/Demo6/CubeEntity.prefab", "EntityGroup");


    }

    private void OnLoadFail(object sender, GameEventArgs e)
    {
        Log.Error("Load data Fail!");
    }

    private void OnLoadSucess(object sender, GameEventArgs e)
    {
        IDataTable<DRHero> dtScene = Tutorial.GameEntry.DataTable.GetDataTable<DRHero>();
        DRHero[] drHeros = dtScene.GetAllDataRows();
        Log.Debug("drHeros: " + drHeros.Length);
        if (drHeros[1] != null)
        {
            // get content
            //string name = dtScene[1].Name;
            //string atk = dtScene[1].Atk;
            int id = drHeros[1].Id;
            string name = drHeros[1].AssetName;
            Log.Debug("ID: " + id + ", name: " + name);
        }
        else
        {
            Log.Debug("did not load data");
        }

        // get all row which satisfies the condition
        DRHero[] drSceneWithCondition = dtScene.GetDataRows( x => x.Id > 0);
        
    }


    private void OnOpenUIFormSucess(object sender , GameEventArgs e)
    {
        OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
        if (ne.UserData != this)
        {
            return;

        }

        Log.Debug("sumit UI_Mene");
    }


}
