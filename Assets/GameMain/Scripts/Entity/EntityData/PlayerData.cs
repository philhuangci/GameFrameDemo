using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Laputa
{
    [Serializable]
    public class PlayerData : HumanData
    {
        [SerializeField]
        private string m_Name = null;

        public PlayerData(int entityId, int typeId)
            : base(entityId, typeId, CampType.Player)
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

    }





}

