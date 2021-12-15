using LifeGame.Config;
using System.Collections.Generic;

namespace LifeGame.Engine
{
    class Map
    {
        private Cell[,] _map;
        private HashSet<Cell> _cellsToCheck;
        private HashSet<Cell> _cellsToCheckInNextGeneration;
        private Rules _rules;

        public Map(bool[,] map, int[] aliveToAliveRules, int[] deadToAliveRules)
        {
            _map = new Cell[map.GetLongLength(0), map.GetLongLength(1)];

            _cellsToCheck = new();
            InitCellsToCheck();

            _cellsToCheckInNextGeneration = new();

            _rules = new Rules(aliveToAliveRules, deadToAliveRules);
        }

        public Map(bool[,] map) : this(map, DefaultRules.AliveToALive, DefaultRules.DeadToALive)
        {
        }

        public MapStates NextGeneration()
        {
            if (_cellsToCheck.Count == 0)
            {
                return MapStates.NoСhanges;
            }

            foreach(Cell cell in _cellsToCheck)
            {
                if (cell.IsAlive != GetNewStateOfCell(cell))
                {
                    AddCellWithNeighborsToCheck(cell);
                    cell.IsAlive = !cell.IsAlive;
                }
            }

            foreach(Cell cell in _cellsToCheckInNextGeneration)
            {
                _cellsToCheck.Add(cell);
            }
            _cellsToCheckInNextGeneration.Clear();

            return MapStates.ChangesContinue;
        }

        public bool[,] GetMapAsBoolArray()
        {
            var mapToPrint = new bool[_map.GetLongLength(0), _map.GetLongLength(1)];
            for (int y = 0; y < _map.GetLongLength(0); y++)
            {
                for (int x = 0; x < _map.GetLongLength(1); x++)
                {
                    mapToPrint[y, x] = _map[y, x].IsAlive;
                }
            }
            return mapToPrint;
        }



        private void InitCellsToCheck()
        {
            if (_cellsToCheck == null)
            {
                return;
            }
            for (int y = 0; y < _map.GetLongLength(0); y++)
            {
                for (int x = 0; x < _map.GetLongLength(1); x++)
                {
                    var cell = _map[y, x];
                    cell.X = x;
                    cell.Y = y;
                    cell.IsAlive = _map[y, x].IsAlive;
                    if (cell.IsAlive)
                    {
                        _cellsToCheck.Add(cell);
                    }
                }
            }
        }

        private void AddCellWithNeighborsToCheck(Cell cell)
        {
            for (int y = cell.Y - 1; y <= cell.Y + 1; y++)
            {
                for (int x = cell.X - 1; y <= cell.X + 1; x++)
                {
                    _cellsToCheckInNextGeneration.Add(
                        _map[y % _map.GetLongLength(0), x % _map.GetLongLength(1)]);
                }
            }
        }

        private bool GetNewStateOfCell(Cell cell)
        {
            return _rules.GetNewCellState(cell.IsAlive, CountAliveNeighbors(cell));
        }

        private int CountAliveNeighbors(Cell cell)
        {
            int numOfAliveNeighbours = 0;

            for (int y = cell.Y - 1; y <= cell.Y + 1; y++)
            {
                for (int x = cell.X - 1; y <= cell.X + 1; x++)
                {
                    if (x == cell.X && y == cell.Y)
                    {
                        continue;
                    }

                    if (_map[y % _map.GetLongLength(0), x % _map.GetLongLength(1)].IsAlive)
                    {
                        numOfAliveNeighbours++;
                    }
                }
            }

            return numOfAliveNeighbours;
        }


    }
}
