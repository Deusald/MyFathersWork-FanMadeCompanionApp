using UnityEngine;

namespace Febucci.UI.Core
{
    /// <summary>
    /// Helper class. Contains methods (including extensions) that modify your letters positions and colors.
    /// </summary>
    public static class TextUtilities
    {
        #region Consts

        /// <summary>
        /// Represents the number of vertices per character/letter.
        /// </summary>
        /// <remarks>
        /// P.S. bars/underlines have a different vertices number, but are not animated by TextAnimator.
        /// </remarks>
        public const int verticesPerChar = 4;

        #endregion

        #region Vector Utilities

        internal const int fakeRandomsCount = 25; //18° angle difference
        internal static Vector3[] fakeRandoms;

        static bool initialized = false;
        internal static void Initialize()
        {
            if (initialized)
                return;

            initialized = true;

            //Creates fake randoms from a list of directions (with an incremental angle of 360/fakeRandomsCount between each)
            //and then sorts them randomly, avoiding repetitions (which could have occurred using Random.insideUnitCircle)
            System.Collections.Generic.List<Vector3> randomDirections = new System.Collections.Generic.List<Vector3>();

            float angle;
            for (float i = 0; i < 360; i += 360 / fakeRandomsCount)
            {
                angle = i * Mathf.Deg2Rad;
                randomDirections.Add(new Vector3(Mathf.Sin(angle), Mathf.Cos(angle)).normalized);
            }

            fakeRandoms = new Vector3[fakeRandomsCount];
            int randomIndex;
            for (int i = 0; i < fakeRandoms.Length; i++)
            {
                randomIndex = Random.Range(0, randomDirections.Count);
                fakeRandoms[i] = randomDirections[randomIndex];
                randomDirections.RemoveAt(randomIndex);
            }
        }

        /// <summary>
        /// Rotates a point around a 2D center by X degrees
        /// </summary>
        /// <param name="vec">point to rotate</param>
        /// <param name="center">rotation's center</param>
        /// <param name="rotDegrees">rotation degrees</param>
        /// <returns></returns>
        /// <example>
        /// letterVertex.RotateAround(letterMiddlePoint, angle);
        /// </example>
        public static Vector3 RotateAround(this Vector3 vec, Vector2 center, float rotDegrees)
        {
            rotDegrees *= Mathf.Deg2Rad;

            float tempX = vec.x - center.x;
            float tempY = vec.y - center.y;

            float rotatedX = tempX * Mathf.Cos(rotDegrees) - tempY * Mathf.Sin(rotDegrees);
            float rotatedY = tempX * Mathf.Sin(rotDegrees) + tempY * Mathf.Cos(rotDegrees);

            vec.x = rotatedX + center.x;
            vec.y = rotatedY + center.y;

            return vec;
        }

        #endregion

        /// <summary>
        /// Moves a char towards a direction. Equivalent to adding a vector to all the vertices.
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static void MoveChar(this Vector3[] vec, Vector3 dir)
        {
            for (byte j = 0; j < vec.Length; j++)
            {
                vec[j] += dir;
            }
        }

        /// <summary>
        /// Sets all the vertices of character to the given position.
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static void SetChar(this Vector3[] vec, Vector3 pos)
        {
            for (byte j = 0; j < vec.Length; j++)
            {
                vec[j] = pos;
            }
        }

        /// <summary>
        /// Lerps all the character's vertices (without checking if pct is between 0 and 1)
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="target"></param>
        /// <param name="pct"></param>
        /// <returns></returns>
        public static void LerpUnclamped(this Vector3[] vec, Vector3 target, float pct)
        {
            for (byte j = 0; j < vec.Length; j++)
            {
                vec[j] = Vector3.LerpUnclamped(vec[j], target, pct);
            }
        }

        /// <summary>
        /// Returns the middle position of the given array
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static Vector3 GetMiddlePos(this Vector3[] vec)
        {
            return (vec[0] + vec[2]) / 2f; //bot left and top right

            //'Normal way', for arrays with any size (not happening, since Bars aren't animated)
            /*
            Vector3 middlePos = Vector3.zero;
            for (byte j = 0; j < vec.Length; j++)
            {
                middlePos += vec[j];
            }

            return (middlePos / vec.Length);
            */
        }


        /// <summary>
        /// Rotates all the vertices towards an angle, with their center as the rotation pivot
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static void RotateChar(this Vector3[] vec, float angle)
        {
            Vector3 middlePos = vec.GetMiddlePos();
            for (byte j = 0; j < vec.Length; j++)
            {
                vec[j] = vec[j].RotateAround(middlePos, angle);
            }
        }

        public static void RotateChar(this Vector3[] vec, float angle, Vector3 pivot)
        {
            for (byte j = 0; j < vec.Length; j++)
            {
                vec[j] = vec[j].RotateAround(pivot, angle);
            }
        }

        /// <summary>
        /// Sets the color of all the vertices of the character.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static void SetColor(this Color32[] col, Color32 target)
        {
            for (byte j = 0; j < col.Length; j++)
            {
                col[j] = target;
            }
        }

        /// <summary>
        /// Lerps all the colors of the characters towards a given target
        /// </summary>
        /// <param name="col"></param>
        /// <param name="target"></param>
        /// <param name="pct"></param>
        /// <returns></returns>
        public static void LerpUnclamped(this Color32[] col, Color32 target, float pct)
        {
            for (byte j = 0; j < col.Length; j++)
            {
                col[j] = Color32.LerpUnclamped(col[j], target, pct);
            }
        }


        /// <summary>
        /// Calculates the animation curve duration
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        public static float CalculateCurveDuration(this AnimationCurve curve)
        {
            if (curve.keys.Length > 0)
                return curve.keys[curve.length - 1].time;

            return 0;
        }


        public static bool IsTagLongEnough(string tag)
        {
            return tag.Length >= 3;
        }

    }
}