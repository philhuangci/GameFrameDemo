using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Laputa
{
    [Serializable]
    public class BoxData : TargetableObjectData
    {
        [SerializeField]
        private string m_Name = null;
        private float m_Speed = 5.0f;

        private int m_MaxHP = 100;

        public float Speed
        {
            get
            {
                return m_Speed;
            }
        }
        
        public BoxData(int entityId, int typeId)
            : base(entityId, typeId, CampType.Unknown)
        {

        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }

        }

        public override int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }
    }





}

