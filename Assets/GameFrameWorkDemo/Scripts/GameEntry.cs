using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;


namespace Tutorial
{
    public partial class GameEntry : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // 初始化内置组件
            InitBuiltinComponents();

            // 初始化自定义组件
            InitCustomCopmponent();

            // 初始化自定义调试器
            InitCustomDebuggers();

            string firstTestMessage = Utility.Text.Format("This is the first test {0}", Version.GameFrameworkVersion);

            Log.Debug(firstTestMessage);



        }

        // Update is called once per frame
        void Update()
        {

        }
    }



}



