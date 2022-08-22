using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public static void run()
    {
        foreach (var item in Data.Statements)
        {
            item.Run();
        }

        Debug.Log(Data.Channels);
    }
}
