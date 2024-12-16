//  PlayerPrefsUtility.cs
//  http://kan-kikuchi.hatenablog.com/entry/PlayerPrefsUtility
//
//  Created by kan kikuchi on 2015.10.22.

using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

/// <summary>
/// PlayerPrefs�Ɋւ���֗��N���X
/// </summary>
public static class PlayerPrefsUtility
{

    //=================================================================================
    //�ۑ�
    //=================================================================================

    /// <summary>
    /// ���X�g��ۑ�
    /// </summary>
    public static void SaveList<T>(string key, List<T> value)
    {
        string serizlizedList = Serialize<List<T>>(value);
        PlayerPrefs.SetString(key, serizlizedList);
    }

    /// <summary>
    /// �f�B�N�V���i���[��ۑ�
    /// </summary>
    public static void SaveDict<Key, Value>(string key, Dictionary<Key, Value> value)
    {
        string serizlizedDict = Serialize<Dictionary<Key, Value>>(value);
        PlayerPrefs.SetString(key, serizlizedDict);
    }

    //=================================================================================
    //�ǂݍ���
    //=================================================================================

    /// <summary>
    /// ���X�g��ǂݍ���
    /// </summary>
    public static List<T> LoadList<T>(string key)
    {
        //key�����鎞�����ǂݍ���
        if (PlayerPrefs.HasKey(key))
        {
            string serizlizedList = PlayerPrefs.GetString(key);
            return Deserialize<List<T>>(serizlizedList);
        }

        return new List<T>();
    }

    /// <summary>
    /// �f�B�N�V���i���[��ǂݍ���
    /// </summary>
    public static Dictionary<Key, Value> LoadDict<Key, Value>(string key)
    {
        //key�����鎞�����ǂݍ���
        if (PlayerPrefs.HasKey(key))
        {
            string serizlizedDict = PlayerPrefs.GetString(key);
            return Deserialize<Dictionary<Key, Value>>(serizlizedDict);
        }

        return new Dictionary<Key, Value>();
    }

    //=================================================================================
    //�V���A���C�Y�A�f�V���A���C�Y
    //=================================================================================

    private static string Serialize<T>(T obj)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, obj);
        return Convert.ToBase64String(memoryStream.GetBuffer());
    }

    private static T Deserialize<T>(string str)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(str));
        return (T)binaryFormatter.Deserialize(memoryStream);
    }
}