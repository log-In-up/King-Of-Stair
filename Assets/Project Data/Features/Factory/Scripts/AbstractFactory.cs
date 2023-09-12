using UnityEngine;

namespace Factory
{
    public abstract class AbstractFactory : MonoBehaviour
    {
        public abstract GameObject CreateEntity();
    }
}