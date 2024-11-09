using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BitCraft.UserControls
{
    public partial class CraftControl : UserControl
    {
        internal string LastError { get; private set; } = String.Empty;

        bool IsRelease = true;

        public event EventHandler NumbersChanged;
        public event EventHandler NewError;

        Color gridColor = Color.PaleGoldenrod;
        Color cellColor = Color.Blue;

        Font NumberFont = new Font(DefaultFont.Name, 8, DefaultFont.Style);
        Brush NumberBrush = new SolidBrush(Color.White);

        bool universeFinite = true;
        Cells[,] universe;

        int xSize = 16;
        int ySize = 16;

        bool HUDVisible = false;
        bool GridVisible = true;

        StringFormat CenterStringFormat = new StringFormat();

        public List<int> SelectedNumbers = new List<int>();

        bool GlobalChange = true; //флаг изменения активности только в одном направлении. 

        int CellCount = 0; //общее число ячеек
        public CraftControl()
        {

            InitializeComponent();
#if DEBUG
            IsRelease = false;
            HUDVisible = true;
#else
            statusStrip1.Visible =false; //add code here
#endif

            CenterStringFormat.Alignment = StringAlignment.Center;
            CenterStringFormat.LineAlignment = StringAlignment.Center;

            CreateUniverse();

            CellCount = xSize * ySize; //общее число ячеек
        }

        private void SetLastError(string msg)
        {
            LastError = msg;
            if (NewError != null) NewError.Invoke(this, new NewErrorEventArgs(msg));
        }

        //Creating a new univers and making the cells not equal to null
        public void CreateUniverse()
        {
            universe = new Cells[xSize, ySize];

            //Only paint in wm.paint
            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    universe[x, y] = new Cells(x, y, GetCurrentNumber(x, y));
                }
            }
        }
        /// <summary>
        /// x, y starts 0
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int GetCurrentNumber(int x, int y)
        {
            return (y * xSize + x + 1);
        }

        /// <summary>
        /// Изменение списка выбранных номеров
        /// </summary>
        /// <param name="number">Номер который обрабатывается</param>
        /// <param name="isAlive">действущий (подсвечен) или нет</param>
        private void TouchNumber(int number, bool isAlive)
        {
            try
            {
         
                if (SelectedNumbers.Contains(number) && !isAlive) //удаляем если есть в списке и не живой
                {
                    SelectedNumbers.Remove(number);
                }
                else if (isAlive && !SelectedNumbers.Contains(number)) //если живой и отсутствует в списке
                {
                    SelectedNumbers.Add(number);
                }

                if (NumbersChanged != null) NumbersChanged.Invoke(this, new NumbersChangedEventArgs(number));
            }
            catch (Exception ex)
            {
                SetLastError($"TouchNumber:{ex.Message}({ex.InnerException?.Message})");
            }

        }

        private void gridPanel_MouseUp(object sender, MouseEventArgs e)
        {

            if (IsRelease)
            {
                return;
            }

            //for debug test
            SelectedNumbers.Sort();
            List<int> al = GetAliveCells();
            al.Sort();
            string selected = string.Join(",", SelectedNumbers);
            string alives = string.Join(",", al);

            if (selected != alives)
            {
                SetLastError("Список живых ячеек и отмеченных номеров не совпадает!");
            }
        }


        //Helping with the mouse dragging section
        private void gridPanel_MouseDown(object sender, MouseEventArgs e)
        {

            try
            {
                float width = (float)gridPanel.ClientSize.Width / universe.GetLength(0);
                float height = (float)gridPanel.ClientSize.Height / universe.GetLength(1);

                if (e.Button == MouseButtons.Left)
                {
                    int x = (int)(e.X / width);
                    int y = (int)(e.Y / height);


                    if (x >= 0 && x < universe.GetLength(0) && y >= 0 && y < universe.GetLength(1))
                    {

                        GlobalChange = !universe[x, y].getAlive(); 
                        universe[x, y].toggleAlive();

                        tssCurrentNumber.Text = universe[x, y].Number.ToString();

                        TouchNumber(universe[x, y].Number, universe[x, y].getAlive());

                    }


                    gridPanel.Invalidate();
                }
            }
            catch (Exception ex)
            {
                SetLastError($"gridPanel_MouseDown:{ex.Message}({ex.InnerException?.Message})");

            }

        }

        private void gridPanel_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                float width = (float)gridPanel.ClientSize.Width / universe.GetLength(0);
                float height = (float)gridPanel.ClientSize.Height / universe.GetLength(1);

                if (e.Button == MouseButtons.Left)
                {
                    int x = (int)(e.X / width);
                    int y = (int)(e.Y / height);

                    if (x >= 0 && x < universe.GetLength(0) && y >= 0 && y < universe.GetLength(1))
                    {
                        if (GlobalChange)
                        {
                            universe[x, y].setAliveTrue();
                    
                        }
                        else
                        {
                            universe[x, y].setAliveFalse();
                      
                        }

                        TouchNumber(universe[x, y].Number, universe[x, y].getAlive());

                    }
                    gridPanel.Invalidate();
                }
            }
            catch (Exception ex)
            {
                SetLastError($"gridPanel_MouseMove:{ex.Message}({ex.InnerException?.Message})");

            }
        }


        /*
         * Paint Section
         */
        //Render the grid to the window
        private void gridPanel_Paint(object sender, PaintEventArgs e)
        {
            //return; //!!!
            try
            {
                Brush hudBrush = new SolidBrush(Color.Black);
                Brush gridBrush = new SolidBrush(cellColor);

                Point hudPoint = new Point(5, gridPanel.ClientSize.Height / 20 * 16);

                float width = (float)gridPanel.ClientSize.Width / universe.GetLength(0);
                float height = (float)gridPanel.ClientSize.Height / universe.GetLength(1);


                //Creating a new pen and setting the color to the variable gridColor
                Pen gridPen = new Pen(gridColor, 1);

                //resetNeighbors();
                if (GridVisible)
                {
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        Point p1 = new Point((int)(x * width), 0);
                        Point p2 = new Point((int)(x * width), gridPanel.ClientSize.Height);
                        e.Graphics.DrawLine(gridPen, p1, p2);
                    }
                    for (int y = 0; y < universe.GetLength(1); y++)
                    {
                        Point p1 = new Point(0, (int)(y * height));
                        Point p2 = new Point(gridPanel.ClientSize.Width, (int)(y * height));
                        e.Graphics.DrawLine(gridPen, p1, p2);
                    }
                }

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    for (int y = 0; y < universe.GetLength(1); y++)
                    {
                        Rectangle rect = Rectangle.Empty;
                        rect.X = (int)(x * width);
                        rect.Y = (int)(y * height);
                        rect.Width = (int)width;
                        rect.Height = (int)height;

                        //living cells
                        if (universe[x, y].getAlive() == true)
                        {
                            e.Graphics.FillRectangle(gridBrush, rect.X, rect.Y, rect.Width, rect.Height);
                        }

                        // Draw the text and the surrounding rectangle.
                        e.Graphics.DrawString(GetCurrentNumber(x, y).ToString(), NumberFont, NumberBrush, rect, CenterStringFormat);

                    }
                }
          
                if (HUDVisible)
                {

                    hudPoint.Y = gridPanel.Height / 20 * 18;
                    if (universeFinite)
                        e.Graphics.DrawString("Universe Type: Finite", DefaultFont, hudBrush, hudPoint);
                    else
                        e.Graphics.DrawString("Universe Type: Toroidal", DefaultFont, hudBrush, hudPoint);
                    hudPoint.Y = gridPanel.Height / 20 * 19;
                    e.Graphics.DrawString("UniverseSize: ( " + xSize + ", " + ySize + " )", DefaultFont, hudBrush, hudPoint);

                }

                tssCellCount.Text = "Cells: " + CellCount;

                gridPen.Dispose();
            }
            catch (Exception ex)
            {
                SetLastError($"gridPanel_Paint:{ex.Message}({ex.InnerException?.Message})");

            }
        }

        internal void ResetSelected()
        {
            try
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    for (int y = 0; y < universe.GetLength(1); y++)
                    {
                        universe[x, y].setAliveFalse();
                    }
                }

                SelectedNumbers.Clear();

            }
            catch (Exception ex)
            {
                SetLastError($"ResetSelected:{ex.Message}({ex.InnerException?.Message})");
            }
            finally
            {
                if (NumbersChanged != null) NumbersChanged.Invoke(this, new NumbersChangedEventArgs(-1));
                gridPanel.Invalidate();
            }

        }

        internal void SelectAll()
        {
            try
            {
                SelectedNumbers.Clear();

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    for (int y = 0; y < universe.GetLength(1); y++)
                    {
                        universe[x, y].setAliveTrue();

                        SelectedNumbers.Add(universe[x, y].Number);
                    }
                }

            }
            catch (Exception ex)
            {
                SetLastError($"SelectAll:{ex.Message}({ex.InnerException?.Message})");
            }
            finally
            {
                if (NumbersChanged != null) NumbersChanged.Invoke(this, new NumbersChangedEventArgs(-1));
                gridPanel.Invalidate();
            }
        }

        internal void SelectFromList(List<int> numbers)
        {
            try
            {
                SelectedNumbers.Clear();

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    for (int y = 0; y < universe.GetLength(1); y++)
                    {
                        if (numbers.Contains(universe[x, y].Number))
                        {
                            universe[x, y].setAliveTrue();
                            SelectedNumbers.Add(universe[x, y].Number);
                        }
                        else
                        {
                            universe[x, y].setAliveFalse();
                        }
                        
                    }
                }

            }
            catch (Exception ex)
            {
                SetLastError($"SelectFromList:{ex.Message}({ex.InnerException?.Message})");
            }
            finally
            {
                if (NumbersChanged != null) NumbersChanged.Invoke(this, new NumbersChangedEventArgs(-1));
                gridPanel.Invalidate();
            }
        }

        internal List<int> GetAliveCells()
        {
            try
            {
                List<int> alives = new List<int>();

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    for (int y = 0; y < universe.GetLength(1); y++)
                    {
                        if (universe[x, y].getAlive())
                        {
                            alives.Add(universe[x, y].Number);
                        }

                    }
                }

                return alives;

            }
            catch (Exception ex)
            {
                SetLastError($"GetAlive:{ex.Message}({ex.InnerException?.Message})");
                return new List<int>();
            }
            finally
            {

            }
        }
        /// <summary>
        /// Случайно генерируемая комбинация
        /// </summary>
        internal void SelectRandom()
        {
            Random rand = new Random();
            int count = rand.Next(1, CellCount + 1); //сколько выбираем от 1 до CellCount

            var numbers = Enumerable.Range(1, CellCount)
                                         .Select(i => new Tuple<int, int>(rand.Next(CellCount), i))
                                         .OrderBy(i => i.Item1)
                                         .Select(i => i.Item2).Take(count).ToList();
            SelectFromList(numbers);

        }
        /// <summary>
        /// Установить ячейки из бинарной строки
        /// </summary>
        /// <param name="binary"></param>
        /// <exception cref="NotImplementedException"></exception>
        internal void SetFromBinary(string binary)
        {
            try
            {
                SelectedNumbers.Clear();

                //0000100001001 Нужно идти справа и отмечать 1
                int min = Math.Min(binary.Length, CellCount);
                List<int> numbers = new List<int>();

                for (int i = 0; i < min; i++)
                {
                    if (binary[i] == '1')
                    {
                        numbers.Add(min - i);
                    }
                }

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    for (int y = 0; y < universe.GetLength(1); y++)
                    {
                        if (numbers.Contains(universe[x, y].Number)) 
                        {
                            universe[x, y].setAliveTrue();
                            SelectedNumbers.Add(universe[x, y].Number);
                        }
                        else
                        {
                            universe[x, y].setAliveFalse();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                SetLastError($"SetFromBinary:{ex.Message}({ex.InnerException?.Message})");
            }
            finally
            {
                gridPanel.Invalidate();
            }
        }

    }

    public class NumbersChangedEventArgs : EventArgs
    {
        public int Number { get; set; }

        public NumbersChangedEventArgs(int number)
        {
            Number = number;
        }
    }
    public class NewErrorEventArgs : EventArgs
    {
        public string Error { get; set; }

        public NewErrorEventArgs(string error)
        {
            Error = error;
        }
    }
}
