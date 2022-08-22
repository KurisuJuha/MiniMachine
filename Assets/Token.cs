using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token
{
    public TokenType type;
    public string literal;

    public override string ToString()
    {
        return "[ " + type.ToString() + " , " + literal + " ]";
    }
}

public enum TokenType
{
    MOVE,
    MOVECHANNEL,
    SET,
    LABEL,
    JUMP,
    IF,
    ADD,
    SUB,
    MUL,
    GT,
    LT,
    INT,
    NATIVE,

    ILLEGAL,
    EOF,
}
