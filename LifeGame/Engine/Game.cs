using LifeGame.Config;
using System.Collections.Generic;

namespace LifeGame.Engine
{
    class Game
    {
        private Cell[,] _map;
        private HashSet<Cell> _cellsToCheck;
        private HashSet<Cell> _cellsToCheckInNextGeneration;
        private Stack<Cell> _cellsToChange;
        private Rules _rules;

        public GameStates GameState { get; private set; }
        public int MapHeight { get; private set; }
        public int MapWidth { get; private set; }

        public Game(bool[,] mapInBoolArray, int[] aliveToAliveRules, int[] deadToAliveRules)
        {
            InitializeMap(mapInBoolArray);

            _cellsToCheckInNextGeneration = new();
            _cellsToChange = new();

            _rules = new Rules(aliveToAliveRules, deadToAliveRules);

            GameState = GameStates.InProcess;
        }

        public Game(bool[,] map) : this(map, DefaultRules.AliveToALive, DefaultRules.DeadToALive)
        {
        }

        public void NextGeneration()
        {
            if (_cellsToCheck.Count == 0)
            {
                GameState = GameStates.Stopped;
                return;
            }

            CheckCells();
            ChangeCells();
            UpdateCellsToCheck();
            _cellsToCheckInNextGeneration.Clear();
        }

        public bool[,] GetMapAsBoolArray()
        {
            var mapToPrint = new bool[MapHeight, MapWidth];
            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    mapToPrint[y, x] = _map[y, x].IsAlive;
                }
            }
            return mapToPrint;
        }

        public void ChangeStateOfCellOnMap(int x, int y, bool state)
        {
            var cell = _map[y, x];
            cell.IsAlive = state;
            AddCellWithNeighborsToCheck(cell);
        }

        public bool GetCellState(int x, int y)
        {
            var cell = _map[y, x];
            return cell.IsAlive;
        }

        

        private void InitializeMap(bool[,] mapInBoolArray)
        {
            MapHeight = mapInBoolArray.GetLength(0);
            MapWidth = mapInBoolArray.GetLength(1);
            _map = new Cell[MapHeight, MapWidth];
            _cellsToCheck = new();

            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    var cell = new Cell(x, y, mapInBoolArray[y, x]);
                    _map[y, x] = cell;
                    _cellsToCheck.Add(cell);
                }
            }
        }

        private void AddCellWithNeighborsToCheck(Cell cell)
        {
            for (int y = cell.Y - 1; y <= cell.Y + 1; y++)
            {
                for (int x = cell.X - 1; x <= cell.X + 1; x++)
                {
                    if ((x < 0 || x >= MapWidth) || (y < 0 || y >= MapHeight))
                    {
                        continue;
                    }

                    _cellsToCheckInNextGeneration.Add(
                        _map[(y + MapHeight) % MapHeight, (x + MapWidth) % MapWidth]);
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
                for (int x = cell.X - 1; x <= cell.X + 1; x++)
                {
                    if (x == cell.X && y == cell.Y)
                    {
                        continue;
                    }

                    if ((x < 0 || x >= MapWidth) || (y < 0 || y >= MapHeight))
                    {
                        continue;
                    }

                    if (_map[(y + MapHeight) % MapHeight, (x + MapWidth) % MapWidth].IsAlive)
                    {
                        numOfAliveNeighbours++;
                    }
                }
            }

            return numOfAliveNeighbours;
        }

        private void UpdateCellsToCheck()
        {
            _cellsToCheck.Clear();
            foreach (Cell cell in _cellsToCheckInNextGeneration)
            {
                _cellsToCheck.Add(cell);
            }
        }

        private void CheckCells()
        {
            foreach (Cell cell in _cellsToCheck)
            {
                if (cell.IsAlive != GetNewStateOfCell(cell))
                {
                    AddCellWithNeighborsToCheck(cell);
                    _cellsToChange.Push(cell);
                }
            }
        }

        private void ChangeCells()
        {
            while (_cellsToChange.Count != 0)
            {
                var cell = _cellsToChange.Pop();
                cell.IsAlive = !cell.IsAlive;
            }
        }
    }
}
