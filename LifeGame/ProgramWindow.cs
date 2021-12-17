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
        private int _resolution;
        private Brush _cellsBrush;
        private Brush _backgroundBrush;


        public ProgramWindow(int resolution = DefaultMapSettings.Resolution)
        {
            InitializeComponent();

            _cellsBrush = DefaultMapSettings.СellsBrush;
            _backgroundBrush = DefaultMapSettings.BackgrondBrush;
            _resolution = resolution;
        }



        private void StartButtonClick(object sender, EventArgs e)
        {
            _startButton.Enabled = false;

            InitializeGame();

            DisplayTheGrid();
            PrintMap();

            _timer.Start();

            EnableOrDisableSettings(false);
            _pauseButton.Visible = true;
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
            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs == null || _game == null)
            {
                return;
            }

            int mouseClickX = mouseEventArgs.X;
            int mouseClickY = mouseEventArgs.Y;
            if (mouseClickX % _resolution == 0 || mouseClickY % _resolution == 0)
            {
                return;
            }

            int cellX = mouseEventArgs.X / _resolution;
            int cellY = mouseEventArgs.Y / _resolution;
            _game.ChangeStateOfCellOnMap(cellX, cellY);
            bool newStateOfCell = _game.GetCellState(cellX, cellY);
            PrintCell(cellX, cellY, newStateOfCell);
        }




        private void InitializeGame()
        {
            _game = new(GetRandomMap(_playingField.Size.Height / _resolution + 1,
                _playingField.Size.Width / _resolution + 1),
                GetAliveToAliveRules(), GetDeadToAliveRules());
        }

        private void PrintMap()
        {
            var map = _game.GetMapAsBoolArray();

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x])
                    {
                        _graphics.FillRectangle(_cellsBrush, x * _resolution + 1,
                            y * _resolution + 1, _resolution - 1, _resolution - 1);
                        continue;
                    }
                    _graphics.FillRectangle(_backgroundBrush, x * _resolution + 1,
                            y * _resolution + 1, _resolution - 1, _resolution - 1);
                }
            }

            _playingField.Refresh();
        }

        private bool[,] GetRandomMap(int height, int width)
        {
            var map = new bool[height, width];
            var random = new Random();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[y, x] = random.Next(DefaultMapSettings.Density) == 0;
                }
            }

            return map;
        }

        private void StopGame()
        {
            _timer.Stop();
            _game = null;

            EnableOrDisableSettings(true);
            _pauseButton.Visible = false;
            _startButton.Enabled = true;
            _pauseButton.BackColor = Color.Yellow;
            _pauseButton.Text = "Pause";

            DisplayTheGrid();
        }

        private int[] GetAliveToAliveRules()
        {
            int numOfAliveToAliveRules = _aliveToAliveCheckedListBox.CheckedItems.Count;
            var aliveToALiveRules = new int[numOfAliveToAliveRules];
            for (int i = 0; i < numOfAliveToAliveRules; i++)
            {
                aliveToALiveRules[i] = (int)_aliveToAliveCheckedListBox.CheckedItems[i];
            }

            return aliveToALiveRules;
        }

        private int[] GetDeadToAliveRules()
        {
            int numOfDeadToAliveRules = _deadToAliveCheckedListBox.CheckedItems.Count;
            var deadToALiveRules = new int[numOfDeadToAliveRules];
            for (int i = 0; i < numOfDeadToAliveRules; i++)
            {
                deadToALiveRules[i] = (int)_deadToAliveCheckedListBox.CheckedItems[i];
            }

            return deadToALiveRules;
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            _aliveToAliveCheckedListBox.ClearSelected();
            _deadToAliveCheckedListBox.ClearSelected();
        }

        private void EnableOrDisableSettings(bool indicator)
        {
            _aliveToAliveCheckedListBox.Enabled = indicator;
            _deadToAliveCheckedListBox.Enabled = indicator;
            _defaultRulesButton.Enabled = indicator;
        }

        private void DisplayTheGrid()
        {
            _graphics.FillRectangle(_backgroundBrush, 0, 0, _playingField.Width, _playingField.Height);

            int height = _playingField.Height;
            int width = _playingField.Width;

            for (int y = 0; y < height; y += DefaultMapSettings.Resolution)
            {
                _graphics.DrawLine(new Pen(Brushes.Gray),
                    new Point(0, y), new Point(width, y));
            }

            for (int x = 0; x < width; x += DefaultMapSettings.Resolution)
            {
                _graphics.DrawLine(new Pen(Brushes.Gray),
                    new Point(x, 0), new Point(x, height));
            }

            _playingField.Refresh();
        }

        private void SetRulesToCheckedListBox(CheckedListBox checkListBoxWithRules, int[] rules)
        {
            for (int index = 0; index < checkListBoxWithRules.Items.Count; index++)
            {
                checkListBoxWithRules.SetItemChecked(index, false);
            }
            foreach (int numberOfNeighbours in rules)
            {
                checkListBoxWithRules.SetItemChecked(numberOfNeighbours - 1, true);
            }
        }

        private void PrintCell(int cellX, int cellY, bool cellState)
        {
            if (cellState)
            {
                _graphics.FillRectangle(_cellsBrush, cellX * _resolution + 1,
                            cellY * _resolution + 1, _resolution - 1, _resolution - 1);
            }
            else
            {
                _graphics.FillRectangle(_backgroundBrush, cellX * _resolution + 1,
                            cellY * _resolution + 1, _resolution - 1, _resolution - 1);
            }
            _playingField.Refresh();
        }
    }
}
