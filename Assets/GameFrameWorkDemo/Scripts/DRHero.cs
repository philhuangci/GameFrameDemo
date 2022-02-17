using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.DataTable;
using System.IO;
using System.Text;
using UnityGameFramework.Runtime;


public class DRHero : DataRowBase
{
    private int m_Id = 0;

    /// <summary>
    /// 获取实体编号。
    /// </summary>
    public override int Id
    {
        get
        {
            return m_Id;
        }
    }

    /// <summary>
    /// 获取资源名称。
    /// </summary>
    public string AssetName
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = dataRowString.Split('\t');
        for (int i = 0; i < columnStrings.Length; i++)
        {
            columnStrings[i] = columnStrings[i].Trim('\t');
        }

        int index = 0;
        index++;
        m_Id = int.Parse(columnStrings[index++]);
        index++;
        AssetName = columnStrings[index++];

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
                AssetName = binaryReader.ReadString();
            }
        }

        GeneratePropertyArray();
        return true;
    }

    private void GeneratePropertyArray()
    {

    }
}
