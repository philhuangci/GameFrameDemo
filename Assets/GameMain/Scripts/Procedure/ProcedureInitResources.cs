
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Laputa
{
    public class ProcedureInitResources : ProcedureBase
    {
        private bool m_InitResourcesComplete = false;

        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_InitResourcesComplete = false;

            // ע�⣺ʹ�õ���ģʽ����ʼ����Դǰ����Ҫ�ȹ��� AssetBundle �����Ƶ� StreamingAssets �У��������� HTTP 404 ����
            GameEntry.Resource.InitResources(OnInitResourcesComplete);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_InitResourcesComplete)
            {
                // ��ʼ����Դδ���������ȴ�
                return;
            }

            ChangeState<ProcedurePreload>(procedureOwner);
        }

        private void OnInitResourcesComplete()
        {
            m_InitResourcesComplete = true;
            Log.Info("Init resources complete.");
        }
    }
}
