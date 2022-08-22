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
        Data.MemoryReset();
        Lexesing();
        Parsing();
    }

    public void Lexesing()
    {
        string[] a = Data.Program.Split();

        Data.Tokens.Clear();

        foreach (var item in a)
        {
            if (item != string.Empty)
            {
                Token token;

                token = new Token();

                switch (item)
                {
                    case "move":
                        token.literal = item;
                        token.type = TokenType.MOVE;
                        break;
                    case "movechannel":
                        token.literal = item;
                        token.type = TokenType.MOVECHANNEL;
                        break;
                    case "set":
                        token.literal = item;
                        token.type = TokenType.SET;
                        break;
                    case "label":
                        token.literal = item;
                        token.type = TokenType.LABEL;
                        break;
                    case "jump":
                        token.literal = item;
                        token.type = TokenType.JUMP;
                        break;
                    case "if":
                        token.literal = item;
                        token.type = TokenType.IF;
                        break;
                    case "add":
                        token.literal = item;
                        token.type = TokenType.ADD;
                        break;
                    case "sub":
                        token.literal = item;
                        token.type = TokenType.SUB;
                        break;
                    case "mul":
                        token.literal = item;
                        token.type = TokenType.MUL;
                        break;
                    case "gt":
                        token.literal = item;
                        token.type = TokenType.GT;
                        break;
                    case "lt":
                        token.literal = item;
                        token.type = TokenType.LT;
                        break;
                    default:
                        if (int.TryParse(item, out int result))
                        {
                            token.literal = item;
                            token.type = TokenType.INT;
                            break;
                        }

                        token.literal = item;
                        token.type = TokenType.ILLEGAL;
                        break;
                }

                Data.Tokens.Add(token);
            }
        }

        Data.Tokens.Add(new Token()
        {
            literal = "",
            type = TokenType.EOF
        });
    }

    public void Parsing()
    {
        int pos = 0;
        Data.Statements = new List<IStatement>();

        while (true)
        {
            switch (Read().type)
            {
                case TokenType.MOVE:
                    if (int.TryParse(Read().literal, out int moveresult))
                    {
                        Data.Statements.Add(new MoveStatement(moveresult));
                    }
                    break;
                case TokenType.MOVECHANNEL:
                    if (int.TryParse(Read().literal, out int movechannelresult))
                    {
                        Data.Statements.Add(new MoveChannelStatement(movechannelresult));
                    }
                    break;
                case TokenType.SET:
                    if (int.TryParse(Read().literal, out int setresult))
                    {
                        Data.Statements.Add(new SetStatement(setresult));
                    }
                    break;
                case TokenType.LABEL:
                    if (int.TryParse(Read().literal, out int labelresult))
                    {
                        Data.Statements.Add(new LabelStatement(labelresult));
                    }
                    break;
                case TokenType.JUMP:
                    if (int.TryParse(Read().literal, out int jumpresult))
                    {
                        Data.Statements.Add(new JumpStatement(jumpresult));
                    }
                    break;
                case TokenType.IF:
                    if (int.TryParse(Read().literal, out int ifresult))
                    {
                        Data.Statements.Add(new IfStatement(ifresult));
                    }
                    break;
                case TokenType.ADD:
                    if (int.TryParse(Read().literal, out int addresult))
                    {
                        Data.Statements.Add(new AddStatement(addresult));
                    }
                    break;
                case TokenType.SUB:
                    if (int.TryParse(Read().literal, out int subresult))
                    {
                        Data.Statements.Add(new SubStatement(subresult));
                    }
                    break;
                case TokenType.MUL:
                    if (int.TryParse(Read().literal, out int mulresult))
                    {
                        Data.Statements.Add(new MulStatement(mulresult));
                    }
                    break;
                case TokenType.GT:
                    if (int.TryParse(Read().literal, out int gtresult))
                    {
                        Data.Statements.Add(new GtStatement(gtresult));
                    }
                    break;
                case TokenType.LT:
                    if (int.TryParse(Read().literal, out int ltresult))
                    {
                        Data.Statements.Add(new LtStatement(ltresult));
                    }
                    break;
                case TokenType.INT:
                    Read();
                    break;
                case TokenType.ILLEGAL:
                    Read();
                    break;
                case TokenType.EOF:
                    return;
                default:
                    break;
            }
        }

        Token Peek()
        {
            Token token = Data.Tokens[pos];
            return token;
        }

        Token Read()
        {
            if (Data.Tokens.Count > pos)
            {
                Token token = Data.Tokens[pos];
                pos++;
                return token;
            }

            return new Token()
            {
                type = TokenType.EOF
            };
        }
    }
}
