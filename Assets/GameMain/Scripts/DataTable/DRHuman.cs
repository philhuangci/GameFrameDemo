
using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Laputa
{
    /// <summary>
    /// ʵ���
    /// </summary>
    public class DRHuman : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// ��ȡʵ���š�
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// ��ȡ�������ֵ
        /// </summary>
        public int MaxHP
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        public int Defence
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ������ЧID
        /// </summary>
        public int DeathSoundID
        {
            get;
            private set;
        }

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnStrings.Length; i++)
            {
                columnStrings[i] = columnStrings[i].Trim(DataTableExtension.DataTrimSeparators);
            }

            int index = 0;
            index++;
            m_Id = int.Parse(columnStrings[index++]);
            index++;
            MaxHP = int.Parse(columnStrings[index++]);
            Defence = int.Parse(columnStrings[index++]);
            DeathSoundID = int.Parse(columnStrings[index++]);
            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            using (MemoryStream memoryStream = new MemoryStream(dataRowBytes, startIndex, length, false))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                {
                    m_Id = binaryReader.Read7BitEncodedInt32();
                    MaxHP = binaryReader.Read7BitEncodedInt32();
                    Defence = binaryReader.Read7BitEncodedInt32();
                    DeathSoundID = binaryReader.Read7BitEncodedInt32();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        private void GeneratePropertyArray()
        {

        }
    }
}
