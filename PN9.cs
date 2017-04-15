namespace PN9
{
    class PN9
    {
        public PN9() { State = 511; }
        public int State { get; private set; }

        private void NextBit()
        {
            var bit = Get6() ^ Get1();
            State /= 2;
            State |= 256 * bit;
        }
        public byte GetNext()
        {
            var b = (byte)State;
            for (int i = 0; i < 8; i++)
                NextBit();

            return b;
        }

        private byte Get1() { return (byte)(State & 1); }
        private byte Get6() { return (byte)((State & 32) / 32); }
    }
}