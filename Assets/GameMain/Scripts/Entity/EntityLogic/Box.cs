using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;


namespace Laputa
{
    public class Box : EntityLogic
    {

        
        private void ChangeSize()
        {
            Log.Debug("start to change box size");
            gameObject.transform.localScale = new Vector3(Random.Range(4.5f, 13.5f), Random.Range(4.5f, 13.5f), Random.Range(4.5f, 13.5f));

        }



        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            transform.position = ((BoxData)userData).Position;
            GameBase.Instance.onResizeBox += ChangeSize;
 
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            Log.Debug("box is hiden!");
            GameBase.Instance.onResizeBox -= ChangeSize;
        }




        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

        }

        protected override void OnRecycle()
        {
            base.OnRecycle();
            Log.Debug("box is recycled!");
        }

        protected override void OnDetachFrom(EntityLogic parentEntity, object userData)
        {
            base.OnDetachFrom(parentEntity, userData);
            Log.Debug("box is detached from the entity!");

        }
    }



}