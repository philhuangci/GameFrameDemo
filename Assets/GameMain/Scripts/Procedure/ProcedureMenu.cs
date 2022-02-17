
using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Laputa
{
    public class ProcedureMenu : ProcedureBase
    {
        private bool m_StartGame = false;
        private MenuForm m_MenuForm = null;
        private int m_SceneId = 0;
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        public void StartGame(int sceneId)
        {
            m_StartGame = true;
            m_SceneId = sceneId;
        }

        



        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            m_StartGame = false;
            GameEntry.UI.OpenUIForm(UIFormId.MenuForm, this);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            if (m_MenuForm != null)
            {
                m_MenuForm.Close(isShutdown);
                m_MenuForm = null;
            }
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (m_StartGame)
            {
                if (m_SceneId == GameEntry.Config.GetInt("Scene.Main"))
                {
                    procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Main"));
                    procedureOwner.SetData<VarByte>("GameMode", (byte)GameMode.Survival);
                    ChangeState<ProcedureChangeScene>(procedureOwner);
                }
                else if (m_SceneId == GameEntry.Config.GetInt("Scene.Town"))
                {
                    procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Town"));
                    procedureOwner.SetData<VarByte>("GameMode", (byte)GameMode.Survival);
                    ChangeState<ProcedureChangeScene>(procedureOwner);
                }
                else
                {
                    Log.Error("Invalid SceneId in ProcedureMain!");
                }
            }
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_MenuForm = (MenuForm)ne.UIForm.Logic;
        }
    }
}
