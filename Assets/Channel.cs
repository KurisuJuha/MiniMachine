using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Channel
{
    private List<int> memory = new List<int>();

    public void SetMemory(int index, int value)
    {
        while (memory.Count <= index)
        {
            memory.Add(0);
        }

        memory[index] = value;
    }

    public int GetMemory(int index)
    {
        while (memory.Count <= index)
        {
            memory.Add(0);
        }

        return memory[index];
    }

    public override string ToString()
    {
        return "[" + string.Join(',', memory) + "]";
    }
}

public class Channels
{
    private List<Channel> channels = new List<Channel>();

    public Channel GetChannel(int index)
    {
        while (channels.Count <= index)
        {
            channels.Add(new Channel());
        }

        return channels[index];
    }

    public override string ToString()
    {
        return "{" + string.Join(',', channels) + "}";
    }
}
