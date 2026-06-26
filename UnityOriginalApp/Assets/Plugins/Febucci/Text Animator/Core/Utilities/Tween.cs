using UnityEngine;

namespace Febucci.UI.Core
{
    //TODO Docs

    /// <summary>
    /// Helper class used to interpolate effects.
    /// </summary>
    public static class Tween
    {
        public static float EaseIn(float t)
        {
            return t * t;
        }

        public static float Flip(float x)
        {
            return 1 - x;
        }

        public static float Square(float t)
        {
            return t * t;
        }

        public static float EaseOut(float t)
        {
            return Flip(Square(Flip(t)));
        }

        public static float EaseInOut(float t)
        {
            return Mathf.Lerp(EaseIn(t), EaseOut(t), t);
        }

        #region BounceOut
        public static float BounceOut(float t)
        {
            /*
            License of the original method/algorithm, modified later for C#.
          
            ------------------------Start------------------------
            The MIT License

            Copyright (c) 2010-2012 Tween.js authors.
            
            Easing equations Copyright (c) 2001 Robert Penner http:/robertpenner.com/ easing/
            
            Permission is hereby granted, free of charge, to any person obtaining a copy
            of this software and associated documentation files (the "Software"), to deal
            in the Software without restriction, including without limitation the rights
            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
            copies of the Software, and to permit persons to whom the Software is
            furnished to do so, subject to the following conditions:
            
            The above copyright notice and this permission notice shall be included in
            all copies or substantial portions of the Software.
            
            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
            THE SOFTWARE.

            ------------------------End------------------------
            */

            if (t < (1f / 2.75f))
            {
                return 7.5625f * t * t;
            }
            else if (t < (2f / 2.75f))
            {
                return 7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f;
            }
            else if (t < (2.5f / 2.75f))
            {
                return 7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f;
            }
            else
            {
                return 7.5625f * (t -= (2.625f / 2.75f)) * t + 0.984375f;
            }
        }
        #endregion
    }
}
