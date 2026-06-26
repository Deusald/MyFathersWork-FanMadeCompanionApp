using System.Collections.Generic;

namespace Febucci.UI.Core
{
    /// <summary>
    /// Helper class. Contains methods to parse attributes/values from strings.
    /// </summary>
    public static class FormatUtils
    {
        /// <summary>
        /// Tries to parse a rich text tag parameter.
        /// </summary>
        /// <remarks>
        /// Mostly used in combination with custom typewriter actions. (Manual: <see href="https://www.textanimator.febucci.com/docs/writing-custom-actions-c-sharp/">Writing Custom actions C#</see>)
        /// </remarks>
        /// <param name="attributes">list of all the attributesi in the rich text tag</param>
        /// <param name="index">the parameter's index in the list</param>
        /// <param name="defValue">default value, assigned if the parsing is not successful</param>
        /// <param name="result">result from the parsing</param>
        /// <returns><c>true</c> if successful</returns>
        public static bool TryGetFloat(List<string> attributes, int index, float defValue, out float result)
        {
            if (index >= attributes.Count || index < 0)
            {
                result = defValue;
                return false;
            }

            return TryGetFloat(attributes[index], defValue, out result);
        }

        //TODO Docs
        public static bool TryGetFloat(string attribute, float defValue, out float result)
        {
            if (ParseFloat(attribute, out result))
                return true;

            result = defValue;
            return false;
        }

        /// <summary>
        /// Tries parsing a float given a string, independently of the system's culture
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool ParseFloat(string value, out float result)
        {
            return float.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out result);
        }
    }

}