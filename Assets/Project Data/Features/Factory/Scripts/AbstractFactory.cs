using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public abstract class AbstractFactory : MonoBehaviour
    {
        public abstract Queue<GameObject> Queue { get; }

        public abstract GameObject CreateEntity();
    }
}