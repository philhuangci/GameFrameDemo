
using GameFramework;
using LitJson;
using System;

namespace Laputa
{
    /// <summary>
    /// LitJSON ��������������
    /// </summary>
    internal class LitJsonHelper : Utility.Json.IJsonHelper
    {
        /// <summary>
        /// ���������л�Ϊ JSON �ַ�����
        /// </summary>
        /// <param name="obj">Ҫ���л��Ķ���</param>
        /// <returns>���л���� JSON �ַ�����</returns>
        public string ToJson(object obj)
        {
            return JsonMapper.ToJson(obj);
        }

        /// <summary>
        /// �� JSON �ַ��������л�Ϊ����
        /// </summary>
        /// <typeparam name="T">�������͡�</typeparam>
        /// <param name="json">Ҫ�����л��� JSON �ַ�����</param>
        /// <returns>�����л���Ķ���</returns>
        public T ToObject<T>(string json)
        {
            return JsonMapper.ToObject<T>(json);
        }

        /// <summary>
        /// �� JSON �ַ��������л�Ϊ����
        /// </summary>
        /// <param name="objectType">�������͡�</param>
        /// <param name="json">Ҫ�����л��� JSON �ַ�����</param>
        /// <returns>�����л���Ķ���</returns>
        public object ToObject(Type objectType, string json)
        {
            // TODO: �ɷ���Ϊ ToObject<T>(string json)
            throw new NotSupportedException("ToObject(Type objectType, string json)");
        }
    }
}
