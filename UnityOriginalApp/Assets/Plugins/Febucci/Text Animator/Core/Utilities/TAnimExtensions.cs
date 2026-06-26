using System.Collections.Generic;

namespace Febucci.UI.Core
{

    internal static class TAnimExtensions
    {

        internal static int GetIndexOfEffect<T>(this List<T> effects, string tag) where T : EffectsBase
        {
            for (int a = 0; a < effects.Count; a++)
            {
                if (!effects[a].regionManager.IsLastRegionClosed())
                {
                    if (effects[a].effectTag.Equals(tag))
                        return a;
                }
            }

            return -1;
        }


        internal static bool CloseElement<T>(this List<T> effects, int listIndex, int realTextIndex) where T : EffectsBase
        {
            if (listIndex < 0 || listIndex >= effects.Count || effects[listIndex].regionManager.IsLastRegionClosed())
                return false;

            effects[listIndex].regionManager.CloseEffect(realTextIndex);

            return true;
        }


        internal static bool CloseRegionNamed<T>(this List<T> effects, string endTag, int realTextIndex) where T : EffectsBase
        {
            return effects.CloseElement(effects.GetIndexOfEffect(endTag), realTextIndex);
        }


        internal static bool TryAddingNewRegion<T>(this List<T> effects, T region) where T : EffectsBase
        {
            for (int a = 0; a < effects.Count; a++)
            {
                //Doesn't do anything if we have a similar tag open
                //Since there's no need to open a new one
                if (!effects[a].regionManager.IsLastRegionClosed()
                    && effects[a].regionManager.entireRichTextTag.Equals(region.regionManager.entireRichTextTag))
                {
                    return false;
                }
            }

            //no tag open with that rich text combination - creates a new one
            effects.Add(region);
            return true;
        }


        internal static bool CloseSingleOrAllEffects<T>(this List<T> effects, string closureTag, int realTextIndex) where T : EffectsBase
        {
            bool atLeastOneClosed = false;
            //Closes all the regions
            if (closureTag.Length <= 1) //tag is <> or </> ({} or {/})
            {
                //Closes ALL the region opened until now
                for (int k = 0; k < effects.Count; k++)
                {
                    if (effects.CloseElement(k, realTextIndex))
                    {
                        atLeastOneClosed = true;
                    }
                }
            }
            //Closes the current region
            else
            {
                atLeastOneClosed = effects.CloseRegionNamed(closureTag, realTextIndex);
            }

            return atLeastOneClosed;
        }

    }
}