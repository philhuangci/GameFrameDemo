using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Laputa
{
    public class HumanData : TargetableObjectData
    {
        //[SerializeField]
        //private ThrusterData m_ThrusterData = null;

        //[SerializeField]
        //private List<WeaponData> m_WeaponDatas = new List<WeaponData>();

        //[SerializeField]
        //private List<ArmorData> m_ArmorDatas = new List<ArmorData>();

        /// <summary>
        /// 最大生命。
        /// </summary>
        public override int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }

        /// <summary>
        /// 防御。
        /// </summary>
        public int Defense
        {
            get
            {
                return m_Defense;
            }
        }

        public int DeadSoundId
        {
            get
            {
                return m_DeadSoundId;
            }
        }


        [SerializeField]
        private int m_MaxHP = 0;

        [SerializeField]
        private int m_Defense = 0;

        [SerializeField]
        private int m_DeadSoundId = 0;

        public HumanData(int entityId, int typeId, CampType camp)
            : base(entityId, typeId, camp)
        {
            // 新建角色是从数据表中进行读入数据
            IDataTable<DRHuman> dtHuman = GameEntry.DataTable.GetDataTable<DRHuman>();
            DRHuman drHuman = dtHuman.GetDataRow(TypeId);
            if (drHuman == null)
            {
                return;
            }

            m_MaxHP = drHuman.MaxHP;
            m_Defense = drHuman.Defence;
            m_DeadSoundId = drHuman.DeathSoundID;
        }

    }
}
