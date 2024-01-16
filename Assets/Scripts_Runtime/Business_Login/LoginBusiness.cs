namespace TDHeart {

    public static class LoginBusiness {

        public static void Enter(LoginContext ctx) {
            UIApp.P_Login_Open(ctx.uiContext);
        }

        public static void Exit(LoginContext ctx) {
            UIApp.P_Login_Close(ctx.uiContext);
        }

    }

}