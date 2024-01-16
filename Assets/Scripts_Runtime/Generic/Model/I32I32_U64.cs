using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
public struct I32I32_U64 {

    [FieldOffset(0)]
    public int i0;
    [FieldOffset(4)]
    public int i1;
    [FieldOffset(0)]
    public ulong u64;

    public I32I32_U64(int i0, int i1) {
        this.u64 = 0;
        this.i0 = i0;
        this.i1 = i1;
    }

    public static implicit operator I32I32_U64(ulong u64) {
        return new I32I32_U64(0, 0) { u64 = u64 };
    }

    public static implicit operator ulong(I32I32_U64 i32i32) {
        return i32i32.u64;
    }

    public static bool operator ==(I32I32_U64 a, I32I32_U64 b) {
        return a.u64 == b.u64;
    }

    public static bool operator !=(I32I32_U64 a, I32I32_U64 b) {
        return a.u64 != b.u64;
    }

    public override bool Equals(object obj) {
        return obj is I32I32_U64 && this == (I32I32_U64)obj;
    }

    public override int GetHashCode() {
        return u64.GetHashCode();
    }
    
}