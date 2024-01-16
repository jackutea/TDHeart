using System;

namespace TDHeart {

    public class UIEvents {

        public event Action P_Login_OnClickStartHandle;
        public void P_Login_OnClickStart() {
            P_Login_OnClickStartHandle?.Invoke();
        }

    }

}