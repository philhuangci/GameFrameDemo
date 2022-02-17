using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Event;
using GameFramework;
using UnityGameFramework.Runtime;


namespace Laputa
{
    public class BoxDestroyEventArgs : GameEventArgs
    {
        public static int EventId = typeof(BoxDestroyEventArgs).GetHashCode();

        public GameObject BoxObject;

        public override int Id
        { 
            get
            {
                return EventId;
            }
        }
        
        public BoxDestroyEventArgs()
        {
            BoxObject = null;
        }

        public static BoxDestroyEventArgs Create(GameObject obj)
        {
            BoxDestroyEventArgs e = ReferencePool.Acquire<BoxDestroyEventArgs>();
            e.BoxObject = obj;
            return e;
        }


        public override void Clear()
        {
            BoxObject = null;
            //throw new System.NotImplementedException();
        }
    }


}


