using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStatement : IStatement
{
    public int MovePos;

    public MoveStatement(int movePos)
    {
        MovePos = movePos;
    }

    public void Run()
    {
        Data.CurrentMemoryPos = MovePos;
    }
}

public class MoveChannelStatement : IStatement
{
    public int MoveChannelPos;

    public MoveChannelStatement(int moveChannelPos)
    {
        MoveChannelPos = moveChannelPos;
    }

    public void Run()
    {
        Data.CurrentChannelPos = MoveChannelPos;
    }
}

public class SetStatement : IStatement
{
    public int SetNumber;

    public SetStatement(int setNumber)
    {
        SetNumber = setNumber;
    }

    public void Run()
    {
        Data.Channels.GetChannel(Data.CurrentChannelPos).SetMemory(Data.CurrentMemoryPos, SetNumber);
    }
}

public class LabelStatement : IStatement
{
    public int LabelNumber;
    public LabelStatement(int labelNumber)
    {
        LabelNumber = labelNumber;
    }

    public void Run()
    {

    }
}

public class JumpStatement : IStatement
{
    public int LabelNumber;
    public JumpStatement(int labelNumber)
    {
        LabelNumber = labelNumber;
    }

    public void Run()
    {
        Data.CurrentProgramPos = LabelNumber;
    }
}

public class IfStatement : IStatement
{
    public int LabelNumber;
    public IfStatement(int labelNumber)
    {
        LabelNumber = labelNumber;
    }
    public void Run()
    {

    }
}

public class AddStatement : IStatement
{
    public int Number;
    public AddStatement(int number)
    {
        Number = number;
    }
    public void Run()
    {
        int d = Data.Channels.GetChannel(Data.CurrentChannelPos).GetMemory(Data.CurrentMemoryPos);
        Data.Channels.GetChannel(Data.CurrentChannelPos).SetMemory(Data.CurrentMemoryPos, d + Number);
    }
}

public class SubStatement : IStatement
{
    public int Number;
    public SubStatement(int number)
    {
        Number = number;
    }
    public void Run()
    {
        int d = Data.Channels.GetChannel(Data.CurrentChannelPos).GetMemory(Data.CurrentMemoryPos);
        Data.Channels.GetChannel(Data.CurrentChannelPos).SetMemory(Data.CurrentMemoryPos, d - Number);
    }
}

public class MulStatement : IStatement
{
    public int Number;
    public MulStatement(int number)
    {
        Number = number;
    }
    public void Run()
    {
        int d = Data.Channels.GetChannel(Data.CurrentChannelPos).GetMemory(Data.CurrentMemoryPos);
        Data.Channels.GetChannel(Data.CurrentChannelPos).SetMemory(Data.CurrentMemoryPos, d + Number);
    }
}

public class GtStatement : IStatement
{
    public int Number;
    public GtStatement(int number)
    {
        Number = number;
    }
    public void Run()
    {
        Channel c = Data.Channels.GetChannel(Data.CurrentChannelPos);
        if (c.GetMemory(Data.CurrentMemoryPos) > Number)
        {
            c.SetMemory(Data.CurrentMemoryPos, 1);
        }
        else
        {
            c.SetMemory(Data.CurrentMemoryPos, 0);
        }
    }
}

public class LtStatement : IStatement
{
    public int Number;
    public LtStatement(int number)
    {
        Number = number;
    }
    public void Run()
    {
        Channel c = Data.Channels.GetChannel(Data.CurrentChannelPos);
        if (c.GetMemory(Data.CurrentMemoryPos) < Number)
        {
            c.SetMemory(Data.CurrentMemoryPos, 1);
        }
        else
        {
            c.SetMemory(Data.CurrentMemoryPos, 0);
        }
    }
}

public class NativeStatement : IStatement
{
    public int Number;
    public NativeStatement(int number)
    {
        Number = number;
    }
    public void Run()
    {
        switch (Number)
        {
            case 0:
                Debug.Log(Data.Channels);
                break;
            case 1:
                Debug.Log(string.Join(',', Data.Labels));
                break;
            default:
                break;
        }
    }
}
