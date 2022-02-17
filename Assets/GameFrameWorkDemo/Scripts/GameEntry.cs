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
            // ��ʼ���������
            InitBuiltinComponents();

            // ��ʼ���Զ������
            InitCustomCopmponent();

            // ��ʼ���Զ��������
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



