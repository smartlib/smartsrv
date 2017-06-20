using System;

namespace StockContract
{
    public enum Interval : long
    {
        TICK = 1,
        S1 = 10000000L * TICK,
        S2 = 2L * S1,
        S3 = 3L * S1,
        S4 = 4L * S1,
        S5 = 5L * S1,
        S6 = 6L * S1,
        S10 = 10L * S1,
        S12 = 12L * S1,
        S15 = 15L * S1,
        S20 = 20L * S1,
        S30 = 30L * S1,
        M1 = 60L * S1,
        M2 = 2L * M1,
        M3 = 3L * M1,
        M4 = 4L * M1,
        M5 = 5L * M1,
        M6 = 6L * M1,
        M10 = 10L * M1,
        M12 = 12L * M1,
        M15 = 15L * M1,
        M20 = 20L * M1,
        M30 = 30L * M1,
        H1 = 60L * M1,
        H2 = 2L * H1,
        H3 = 3L * H1,
        H4 = 4L * H1,
        H6 = 6L * H1,
        H8 = 8L * H1,
        H12 = 12L * H1,
        D = 24L * H1,
        W = 7L * D,
        MN = 30L * D,
        Y = 365L * D,
    }
}
