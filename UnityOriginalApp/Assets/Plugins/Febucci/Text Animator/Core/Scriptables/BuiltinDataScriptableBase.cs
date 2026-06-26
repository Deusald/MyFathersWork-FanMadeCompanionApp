using UnityEngine;

namespace Febucci.UI.Core
{
    public class BuiltinDataScriptableBase<T> : ScriptableObject where T : new()
    {
        [SerializeField] internal T effectValues = new T();
    }
}