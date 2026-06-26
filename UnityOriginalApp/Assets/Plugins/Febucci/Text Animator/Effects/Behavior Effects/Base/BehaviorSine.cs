using UnityEngine;

namespace Febucci.UI.Core
{
    /// <summary>
    /// Behavior helper class that automatically manages the following modifiers: (a = <see cref="amplitude"/>), (f = <see cref="frequency"/>) and (w = <see cref="waveSize"/>).<br/><br/>
    /// You can inerith from this class and use the modifiers as you prefer in your effects, without having to set up them inside the <see cref="SetModifier(string, string)"/> method.
    /// </summary>
    /// <example>
    /// All the TextAnimator effects that have 3 modifiers inerith from this class. You can check their source code to see how they are set up, example: <see cref="WiggleBehavior"/> or <see cref="WaveBehavior"/>
    /// </example>
    public abstract class BehaviorSine : BehaviorBase
    {
        protected float amplitude = 1;
        protected float frequency = 1;
        protected float waveSize = .08f;

        public override void SetModifier(string modifierName, string modifierValue)
        {
            switch (modifierName)
            {
                //amplitude
                case "a": ApplyModifierTo(ref amplitude, modifierValue); break;
                //frequency
                case "f": ApplyModifierTo(ref frequency, modifierValue); break;
                //wave size
                case "w": ApplyModifierTo(ref waveSize, modifierValue); break;
            }
        }

        public override string ToString()
        {
            return $"freq: {frequency}\n" +
                $"ampl: {amplitude}\n" +
                $"waveSize: {waveSize}" +
                $"\n{base.ToString()}";
        }
    }
}