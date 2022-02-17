
using GameFramework;

namespace Laputa
{
    /// <summary>
    /// �Ի�����ʾ���ݡ�
    /// </summary>
    public class DialogParams
    {
        /// <summary>
        /// ģʽ������ť������ȡֵ 1��2��3��
        /// </summary>
        public int Mode
        {
            get;
            set;
        }

        /// <summary>
        /// ���⡣
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// ��Ϣ���ݡ�
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// ��������ʱ�Ƿ���ͣ��Ϸ��
        /// </summary>
        public bool PauseGame
        {
            get;
            set;
        }

        /// <summary>
        /// ȷ�ϰ�ť�ı���
        /// </summary>
        public string ConfirmText
        {
            get;
            set;
        }

        /// <summary>
        /// ȷ����ť�ص���
        /// </summary>
        public GameFrameworkAction<object> OnClickConfirm
        {
            get;
            set;
        }

        /// <summary>
        /// ȡ����ť�ı���
        /// </summary>
        public string CancelText
        {
            get;
            set;
        }

        /// <summary>
        /// ȡ����ť�ص���
        /// </summary>
        public GameFrameworkAction<object> OnClickCancel
        {
            get;
            set;
        }

        /// <summary>
        /// ������ť�ı���
        /// </summary>
        public string OtherText
        {
            get;
            set;
        }

        /// <summary>
        /// ������ť�ص���
        /// </summary>
        public GameFrameworkAction<object> OnClickOther
        {
            get;
            set;
        }

        /// <summary>
        /// �û��Զ������ݡ�
        /// </summary>
        public string UserData
        {
            get;
            set;
        }
    }
}
