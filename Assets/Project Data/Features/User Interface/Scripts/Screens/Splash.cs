using UnityEngine;

namespace UserInterface
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public class Splash : ScreenObserver
    {
        #region Properties
        public override UIScreen Screen => UIScreen.SplashScreen;
        #endregion
    }
}