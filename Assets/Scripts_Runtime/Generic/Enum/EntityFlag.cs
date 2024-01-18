namespace TDHeart {

    [System.Flags]
    public enum EntityFlag {
        None,
        Role = 1 << 0,
        Cell = 1 << 1,
        Tower = 1 << 2,
        Bullet = 1 << 3,
        Prop = 1 << 4,
    }
}