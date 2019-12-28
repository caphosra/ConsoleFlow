namespace TerminalFlow
{
    public struct ConsoleSize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public ConsoleSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}