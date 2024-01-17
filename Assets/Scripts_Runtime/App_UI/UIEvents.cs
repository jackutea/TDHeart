using System;

namespace TDHeart {

    public class UIEvents {

        // P Login
        public event Action P_Login_OnClickStartHandle;
        public void P_Login_OnClickStart() => P_Login_OnClickStartHandle?.Invoke();

        // P Failed
        public event Action P_Failed_OnRestartHandle;
        public void P_Failed_OnRestart() => P_Failed_OnRestartHandle?.Invoke();

        public event Action P_Failed_OnExitHandle;
        public void P_Failed_OnExit() => P_Failed_OnExitHandle?.Invoke();

        // P Win
        public event Action P_Win_OnReturnHandle;
        public void P_Win_OnReturn() => P_Win_OnReturnHandle?.Invoke();

    }

}