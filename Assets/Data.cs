using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static string Program = "";
    public static List<Token> Tokens = new List<Token>();
    public static List<IStatement> Statements = new List<IStatement>();
    public static Channels Channels = new Channels();
    public static int CurrentChannelPos = 1;
    public static int CurrentMemoryPos;
    public static int CurrentProgramPos;
    public static Action Reload;

    public static void MemoryReset()
    {
        Channels = new Channels();
        CurrentChannelPos = 1;
        CurrentMemoryPos = 0;
        CurrentProgramPos = 0;
    }
}
