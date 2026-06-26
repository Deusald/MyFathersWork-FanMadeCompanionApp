using UnityEngine;
using System.Collections.Generic;

namespace Febucci.UI.Core
{
    /// <summary>
    /// Represents visible characters in the text (including sprites and excluding bars)
    /// </summary>
    struct Character
    {
#pragma warning disable 0649
        internal bool initialized;
#pragma warning restore 0649

        public int[] indexBehaviorEffects;
        public int[] indexAppearanceEffects;

        public CharacterSourceData sources;
        public CharacterData data;

        public void ResetVertices()
        {
            for (byte i = 0; i < sources.vertices.Length; i++)
            {
                data.vertices[i] = sources.vertices[i];
            }
        }

        public void ResetColors()
        {
            for (byte i = 0; i < sources.colors.Length; i++)
            {
                data.colors[i] = sources.colors[i];
            }
        }

        public void Hide()
        {
            for (byte i = 0; i < sources.vertices.Length; i++)
            {
                data.vertices[i] = Vector3.zero;
            }
        }
    }

    //Original character data
    struct CharacterSourceData
    {
        public Color32[] colors;
        public Vector3[] vertices;
    }

    /// <summary>
    /// Contains characters data that can be modified during TextAnimator effects.
    /// </summary>
    public struct CharacterData
    {
        /// <summary>
        /// Time passed since the character is visible (or just started the appearance effect).
        /// </summary>
        public float passedTime;

        /// <summary>
        /// A character's vertices colors.
        /// </summary>
        /// <remarks>
        /// The array size is usually <see cref="TextUtilities.verticesPerChar"/>
        /// </remarks>
        public Color32[] colors;
        /// <summary>
        /// A character's vertices positions.
        /// </summary>
        /// <remarks>
        /// The array size is usually <see cref="TextUtilities.verticesPerChar"/>
        /// </remarks>
        public Vector3[] vertices;

        /// <summary>
        /// Related character information from TextMeshPro.<br/>
        /// P.S. If you want to modify vertices/colors, please use the <see cref="vertices"/> and <see cref="colors"/> arrays variables instead.
        /// </summary>
        public TMPro.TMP_CharacterInfo tmp_CharInfo;
    }

}