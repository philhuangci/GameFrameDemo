
using GameFramework.Resource;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Laputa
{
    public class ProcedureSplash : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            // TODO: ������Բ���һ�� Splash ����
            // ...

            if (GameEntry.Base.EditorResourceMode)
            {
                // �༭��ģʽ
                Log.Info("Editor resource mode detected.");
                ChangeState<ProcedurePreload>(procedureOwner);
            }
            else if (GameEntry.Resource.ResourceMode == ResourceMode.Package)
            {
                // ����ģʽ
                Log.Info("Package resource mode detected.");
                ChangeState<ProcedureInitResources>(procedureOwner);
            }
            else
            {
                // �ɸ���ģʽ
                Log.Info("Updatable resource mode detected.");
                ChangeState<ProcedureCheckVersion>(procedureOwner);
            }
        }
    }
}
