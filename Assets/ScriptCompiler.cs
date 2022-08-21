using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScriptCompiler : MonoBehaviour
{
    void Start()
    {
        Data.Reload += Compile;
    }

    public void Compile()
    {
        string[] a = Data.Program.Split();

        Data.Tokens.Clear();

        foreach (var item in a)
        {
            if (item != string.Empty)
            {
                Data.Tokens.Add(item);
            }
        }

        Debug.Log(string.Join(',', Data.Tokens));
        Debug.Log(Data.Tokens.Count);
    }
}
