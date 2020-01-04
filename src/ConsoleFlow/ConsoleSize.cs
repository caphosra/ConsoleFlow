namespace ConsoleFlow
{
    /// <summary>
    ///
    /// Represent the size of rectangle on Console.
    ///
    /// </summary>
    public struct ConsoleSize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public ConsoleSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"Width:{Width},Height:{Height}";
        }
    }
}
