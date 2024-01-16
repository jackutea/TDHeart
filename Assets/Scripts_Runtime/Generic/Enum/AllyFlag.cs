using System;

namespace TDHeart {

    [Flags]
    public enum AllyFlag {
        None,
        Player,
        Monster,
        Neutral,
    }

    public static class AllyFlagExtension {

        public static AllyFlag Opposite(this AllyFlag flag) {
            switch (flag) {
                case AllyFlag.Player:
                    return AllyFlag.Monster;
                case AllyFlag.Monster:
                    return AllyFlag.Player;
                default:
                    return AllyFlag.None;
            }
        }
    }

}