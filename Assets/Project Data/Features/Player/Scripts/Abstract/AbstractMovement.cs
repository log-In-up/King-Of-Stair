using UnityEngine;

namespace Player
{
    public abstract class AbstractMovement : MonoBehaviour
    {
        internal abstract void MoveForward();
        internal abstract void MoveLeft();
        internal abstract void MoveRight();
    }
}