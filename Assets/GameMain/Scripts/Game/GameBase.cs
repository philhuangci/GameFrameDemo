
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Laputa
{
    public abstract class GameBase
    {
        public abstract GameMode GameMode
        {
            get;
        }

        public static GameBase Instance;

        public System.Action onResizeBox;


        private int m_CurrentBoxCount = 0;
        private int m_MaxBoxCount = 10;

        private float m_NextCloneTime = 0.0f;



        public bool GameOver
        {
            get;
            protected set;
        }

        public virtual void Initialize()
        {
            // 订阅实体的消息
            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);
            GameEntry.Event.Subscribe(BoxDestroyEventArgs.EventId, OnDestroyBox);
            
            Instance = this;

            GameEntry.Entity.ShowPlayer(new PlayerData(GameEntry.Entity.GenerateSerialId(), 10000)
            {
                Name = "Player",
                Position = Vector3.zero
            }) ;

            GameOver = false;
        }

        private void OnDestroyBox(object sender, GameEventArgs e)
        {
            Log.Debug("destory the box");
            BoxDestroyEventArgs ne = (BoxDestroyEventArgs)e;
            GameObject boxObj = ne.BoxObject;
            GameObject.Destroy(boxObj);
            m_CurrentBoxCount--;
        }

        public virtual void Shutdown()
        {
            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Unsubscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);
            GameEntry.Event.Unsubscribe(BoxDestroyEventArgs.EventId, OnDestroyBox);
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
            CreateBox();
            ChangeBoxSize();

        }


        private void ChangeBoxSize()
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                if (onResizeBox != null)
                {
                    onResizeBox();
                }
            }
        }


        private void CreateBox()
        {
            if (m_CurrentBoxCount < m_MaxBoxCount)
            {
                if (Time.time > m_NextCloneTime)
                {
                    m_NextCloneTime = Time.time + 3f;
                    // clone
                    GameEntry.Entity.ShowBox(new BoxData(GameEntry.Entity.GenerateSerialId(), 80001)
                    {
                        Name = "Box",
                        Position = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10))
                    });
                    m_CurrentBoxCount++;
                }
            }
        }


        protected virtual void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs ne = (ShowEntitySuccessEventArgs)e;
            Log.Debug("Show Entity success '{0}.", ne.Id);
        }

        protected virtual void OnShowEntityFailure(object sender, GameEventArgs e)
        {
            ShowEntityFailureEventArgs ne = (ShowEntityFailureEventArgs)e;
            Log.Warning("Show entity failure with error message '{0}'.", ne.ErrorMessage);
        }
    }
}
