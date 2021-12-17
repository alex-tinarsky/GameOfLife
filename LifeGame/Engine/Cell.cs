namespace LifeGame.Engine
{
    class Cell
    {
        public Cell(int x, int y, bool isAlive)
        {
            X = x;
            Y = y;
            IsAlive = isAlive;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; }

    }
}
