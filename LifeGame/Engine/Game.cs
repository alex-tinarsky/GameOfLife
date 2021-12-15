using System;

namespace LifeGame.Engine
{
    class Game
    {
        private Map _map;

        public Game(Map map)
        {
            _map = map;
            GameState = GameStates.InProcess;
        }

        public GameStates GameState { get; private set; }

        public GameStates NextGeneration()
        {
            GameState = _map.NextGeneration() == MapStates.ChangesContinue ?
                GameStates.InProcess : GameStates.Stopped;
            return GameState;
        }

        public bool[,] GetMapToPrint()
        {
            return _map.GetMapAsBoolArray();
        }


    }
}
