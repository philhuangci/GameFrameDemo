
using UnityEngine;

namespace Laputa
{
    /// <summary>
    /// ÓÎÏ·Èë¿Ú¡£
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        public static BuiltinDataComponent BuiltinData
        {
            get;
            private set;
        }

        //public static HPBarComponent HPBar
        //{
        //    get;
        //    private set;
        //}

        private static void InitCustomComponents()
        {
            BuiltinData = UnityGameFramework.Runtime.GameEntry.GetComponent<BuiltinDataComponent>();
            //HPBar = UnityGameFramework.Runtime.GameEntry.GetComponent<HPBarComponent>();
        }
    }
}
