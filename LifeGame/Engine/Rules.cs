using System.Collections.Generic;

namespace LifeGame.Engine
{
    class Rules
    {
        private HashSet<int> _aliveToALive;
        private HashSet<int> _deadToALive;

        public Rules(int[] aliveToALive, int[] deadToALive)
        {
            _aliveToALive = new HashSet<int>(aliveToALive);
            _deadToALive = new HashSet<int>(deadToALive);
        }


        public bool GetNewCellState(bool isAlive, int numberOfAliveNeighbours)
        {
            if (isAlive)
            {
                return _aliveToALive.Contains(numberOfAliveNeighbours);
            }
            return _deadToALive.Contains(numberOfAliveNeighbours);
        }
    }
}
