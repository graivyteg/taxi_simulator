using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Upgrade<T> : ScriptableObject
    {
        public int Price;

        public abstract void Apply(T element);
    }
}