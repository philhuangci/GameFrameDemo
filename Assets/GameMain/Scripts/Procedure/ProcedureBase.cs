
namespace Laputa
{
    public abstract class ProcedureBase : GameFramework.Procedure.ProcedureBase
    {
        // ��ȡ�����Ƿ�ʹ��ԭ���Ի���
        // ��һЩ��������̣�����Ϸ�߼��Ի�����Դ�������ǰ�����̣��У����Կ��ǵ���ԭ���Ի��������Ϣ��ʾ��Ϊ
        public abstract bool UseNativeDialog
        {
            get;
        }
    }
}
