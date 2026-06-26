namespace Febucci.UI.Core
{
    interface EffectEvaluator
    {
        void Initialize(int type);

        bool isEnabled { get; }
        float Evaluate(float time, int characterIndex);
        float GetDuration();
    }

}