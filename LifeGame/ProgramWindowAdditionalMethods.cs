using LifeGame.Config;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class ProgramWindow
    {
        private void InitializeGame()
        {
            _game = new(_customMap,
                GetAliveToAliveRules(), GetDeadToAliveRules());
            ClearCustomMap();
        }

        private void StartGame()
        {
            _startButton.Enabled = false;
            _startButton.BackColor = Color.White;

            _stopButton.Enabled = true;
            _stopButton.BackColor = Color.OrangeRed;

            InitializeGame();

            DisplayTheGrid();
            PrintMap();

            _timer.Start();

            EnableOrDisableSettings(false);
            _pauseButton.Visible = true;
        }

        private void StopGame()
        {
            _timer.Stop();
            _game = null;

            _pauseButton.Visible = false;
            _pauseButton.BackColor = Color.Yellow;
            _pauseButton.Text = "Pause";

            _startButton.Enabled = true;
            _startButton.BackColor = Color.YellowGreen;

            _stopButton.Enabled = false;
            _stopButton.BackColor = Color.White;

            EnableOrDisableSettings(true);

            DisplayTheGrid();
        }

        private void PrintMap()
        {
            var map = _game == null ? _customMap : _game.GetMapAsBoolArray();

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

        private bool[,] GetRandomMap(int height, int width, int density)
        {
            var map = new bool[height, width];
            var random = new Random();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[y, x] = random.Next(density) == 0;
                }
            }

            return map;
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
            _randomMapButton.Enabled = indicator;
            _clearMapButton.Enabled = indicator;
            _densityNumericUpDown.Enabled = indicator;
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

        private void ProcessPlayingFieldMouseEvent(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
            {
                return;
            }

            int mousePositionX = e.X;
            int mousePositionY = e.Y;

            var validationPassed = ValidateMousePosition(mousePositionX, mousePositionY);
            if (!validationPassed)
            {
                return;
            }

            int cellX = mousePositionX / _resolution;
            int cellY = mousePositionY / _resolution;
            ChangeStateOfCell(cellX, cellY, e);
        }

        private void ChangeStateOfCell(int cellX, int cellY, MouseEventArgs e)
        {
            bool newCellState;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    newCellState = true;
                    break;
                case MouseButtons.Right:
                    newCellState = false;
                    break;
                default:
                    return;
            }

            if (_game == null)
            {
                _customMap[cellY, cellX] = newCellState;
            }
            else
            {
                _game.ChangeStateOfCellOnMap(cellX, cellY, newCellState);
            }

            if (!_timer.Enabled)
            {
                PrintCell(cellX, cellY, newCellState);
            }
        }

        private bool ValidateMousePosition(int x, int y)
        {
            return (x > 0 && x < _playingField.Width) &&
                (y > 0 && y < _playingField.Height) &&
                (x % _resolution != 0 && y % _resolution != 0);
        }

        private void ClearCustomMap()
        {
            for (int y = 0; y < _customMap.GetLength(0); y++)
            {
                for (int x = 0; x < _customMap.GetLength(1); x++)
                {
                    _customMap[y, x] = false;
                }
            }
        }
    }
}