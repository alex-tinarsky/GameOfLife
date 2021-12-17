using LifeGame.Config;
using LifeGame.Engine;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class ProgramWindow : Form
    {
        private Graphics _graphics;
        private Game _game;
        private bool[,] _customMap;
        private int _resolution;
        private Brush _cellsBrush;
        private Brush _backgroundBrush;


        public ProgramWindow(int resolution = DefaultMapSettings.Resolution)
        {
            InitializeComponent();

            _cellsBrush = DefaultMapSettings.СellsBrush;
            _backgroundBrush = DefaultMapSettings.BackgrondBrush;
            _resolution = resolution;
            _timer.Interval = DefaultMapSettings.TimerInterval;
        }



        private void StartButtonClick(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            StopGame();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (_graphics == null)
            {
                _playingField.Image = new Bitmap(_playingField.Width, _playingField.Height);
                _graphics = Graphics.FromImage(_playingField.Image);
                _customMap = new bool[_playingField.Size.Height / _resolution + 1,
                    _playingField.Size.Width / _resolution + 1];
                DisplayTheGrid();
                _timer.Stop();
                return;
            }

            if (_game.GameState == GameStates.Stopped)
            {
                StopGame();
                return;
            }

            _game.NextGeneration();

            PrintMap();
        }

        private void DefaultRulesButtonClick(object sender, EventArgs e)
        {
            SetRulesToCheckedListBox(_aliveToAliveCheckedListBox, DefaultRules.AliveToALive);
            SetRulesToCheckedListBox(_deadToAliveCheckedListBox, DefaultRules.DeadToALive);
        }

        private void PauseButtonClick(object sender, EventArgs e)
        {
            if (_timer.Enabled == true)
            {
                _pauseButton.BackColor = Color.GreenYellow;
                _pauseButton.Text = "Continue";
                _timer.Stop();
                return;
            }
            _pauseButton.BackColor = Color.Yellow;
            _pauseButton.Text = "Pause";
            _timer.Start();
        }

        private void PlayingFieldMouseClick(object sender, MouseEventArgs e)
        {
            ProcessPlayingFieldMouseEvent(e);
        }

        private void PlayingFieldMouseMove(object sender, MouseEventArgs e)
        {
            ProcessPlayingFieldMouseEvent(e);
        }

        private void RandomMapButtonClick(object sender, EventArgs e)
        {
            var randomMap = GetRandomMap(_playingField.Size.Height / _resolution + 1,
                _playingField.Size.Width / _resolution + 1, (int)_densityNumericUpDown.Value);
            for (int y = 0; y < _customMap.GetLength(0); y++)
            {
                for (int x = 0; x < _customMap.GetLength(1); x++)
                {
                    _customMap[y, x] = randomMap[y, x];
                }
            }
            PrintMap();
        }

        private void ClearMapButtonClick(object sender, EventArgs e)
        {
            ClearCustomMap();
            DisplayTheGrid();
        }
    }
}
