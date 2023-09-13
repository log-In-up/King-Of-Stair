using UnityEngine;

namespace Movement
{
    public abstract class AbstractMovement : MonoBehaviour
    {
        public abstract bool CanMove { get; protected set; }

        public abstract void MoveForward();
        public abstract void MoveLeft();
        public abstract void MoveRight();
    }
}