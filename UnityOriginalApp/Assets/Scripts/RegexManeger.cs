using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "INPUTVALIDATOR", menuName = "inputvalidators")]
public class RegexManeger : TMP_InputValidator
{
    public override char Validate(ref string text, ref int pos, char ch)
    {
        if (text.Length < 16)
        {
#if UNITY_EDITOR || UNITY_WEBGL
            if (pos == 0)
            {
                if (char.IsLetterOrDigit(ch))
                {
                    text = text.Insert(pos, ch.ToString().ToUpper());
                    pos += 1;
                    return ch;
                }
                else
                {
                    return '\0';
                }
            }
            else
            {
                if (char.IsLetterOrDigit(ch) || ch == '_' || ch == ' ')
                {
                    text = text.Insert(pos, ch.ToString());
                    pos += 1;
                    return ch;
                }
                else
                {
                    return '\0';
                }
            }
#else
            if (pos == 0 && char.IsLetterOrDigit(ch))
            {
                pos += 1;
                ch = ch.ToString().ToUpper().ToCharArray()[0];
                return ch;
            }
            else if (char.IsLetterOrDigit(ch) || ch == '_' || ch == ' ')
            {
                pos += 1;
                return ch;
            }
            else
            {
                return '\0';
            }
#endif
        }
        else
        {
            return '\0';
        }
    }
}
