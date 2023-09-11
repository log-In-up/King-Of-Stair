using UnityEngine;

namespace UserInterface
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public class Main : ScreenObserver
    {
        #region Fields

        #endregion

        #region Properties
        public override UIScreen Screen => UIScreen.Main;
        #endregion

        #region Overridden Methods
        public override void Activate()
        {
            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }
        #endregion

        #region Public methods

        #endregion

    }
}