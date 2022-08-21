using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class ScriptLoader : MonoBehaviour
{
    public string folderPath;
    public string fileName;
    public string path;
    [Multiline]
    public string script;
    public bool reloaded;

    public string emessage;

    void Start()
    {
        folderPath = Application.persistentDataPath;
        path = Path.Combine(folderPath, fileName);
        reloaded = true;
    }

    void Update()
    {
        if (reloaded)
        {
            reloaded = false;

            ReloadScript();
        }
    }

    void ReloadScript()
    {
        try
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var sr = new StreamReader(fs, System.Text.Encoding.UTF8);

            string s = sr.ReadToEnd();

            sr.Close();

            if (!Data.Program.Equals(s))
            {
                script = s;
                Data.Program = s;
                Data.Reload();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        reloaded = true;
    }
}
