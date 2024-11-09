using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BitCraft.UserControls
{
    public partial class CraftGrid : UserControl
    {
        public event EventHandler NumbersChanged;

        bool _Error = false;
        string _ErrorMessage = "";

        bool _AgainSelect = false;// если выбираем числа из числа ранее отмеченных, то _AgainSelect=true
        int _StartOfBalls = 1; //Или с 0 начинается лотерея
        int _EndOfBalls = 256;// 256 - последняя 1 отмечена
        int _From = 256; //из скольки? (5 из 36)
        int _HowMin = 0; //ни одной - все  0000....0000
        int _HowMax = 256;//выбраны все - 111.....111
        int _Row = 1;
        int _Col = 1;
        float Percent;
  
        int _Selected = 0;//выбранный в данный момент
        int _AgainSelected = 0;
        List<int> selectedNumber = null;//Отбираемые номера (в первый раз)
        List<int> againSelectedNumber = null; //выбираемые номера из ранее отобранных

        Color selectedColor = Color.Yellow; //выбранный номер
        Color unselectedColor = SystemColors.Control;
        Color againSelectedColor = Color.Blue;//отмеченый номер среди ранее выбранных

        TableLayoutPanel tableLayoutPanel = null;
        List<int> CoinColumns; //для подсветки столбцов
        List<int> CoinRows;//для подсветки строк

        float _FontSize = 5.5F;
        public bool Error
        {
            get
            {
                return _Error;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
        }
        /// <summary>
        /// устанавливаем первый это отбор номеров, или выбор новых (Again) из ранее отобранных
        /// </summary>
        public bool AgainSelect
        {
            get
            {
                return _AgainSelect;
            }
            set
            {
                _AgainSelect = value;

            }
        }
        /// <summary>
        /// возвращает число отмеченных номеров
        /// </summary>
        public int Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                _Selected = value;

            }
        }
        /// <summary>
        /// возвращает число отмеченных номеров среди ранее выбранных
        /// </summary>
        public int AgainSelected
        {
            get
            {
                return _AgainSelected;
            }
            set
            {
                _AgainSelected = value;

            }
        }
        public int HowMin
        {
            get
            {
                return _HowMin;
            }
            set
            {
                _HowMin = value;

            }
        }

        public int HowMax
        {
            get
            {
                return _HowMax;
            }
            set
            {
                _HowMax = value;

            }
        }
        public int[] Numbers
        {
            get
            {
                int[] result = null;
                if ((selectedNumber != null) && (selectedNumber.Count > 0))
                {
                    result = new int[selectedNumber.Count];
                    selectedNumber.CopyTo(result, 0);
                }

                return result;
            }

        }

        public int[] AgainNumbers
        {
            get
            {
                int[] result = null;
                if ((againSelectedNumber != null) && (againSelectedNumber.Count > 0))
                {
                    result = new int[againSelectedNumber.Count];
                    againSelectedNumber.CopyTo(result, 0);
                }

                return result;
            }

        }

        public CraftGrid()
        {
            InitializeComponent();
            InitLottoTable(_HowMin, _HowMax, _From);
        }

        public void ResetSelected()
        {
            _Error = false;
            _ErrorMessage = "";

            CoinColumns.Clear();
            CoinRows.Clear();

            int count = tableLayoutPanel.Controls.Count;
            selectedNumber.Clear();
            _Selected = 0;
            for (int i = 0; i < count; i++)
            {
                if (tableLayoutPanel.Controls[i] is Button)
                {
                    (tableLayoutPanel.Controls[i] as Button).BackColor = unselectedColor;
                }

            }

        }

        public void ResetAgainSelected()
        {
            _Error = false;
            _ErrorMessage = "";
            CoinColumns.Clear();
            CoinRows.Clear();

            int count = tableLayoutPanel.Controls.Count;
            againSelectedNumber.Clear();
            _AgainSelected = 0;
            for (int i = 0; i < count; i++)
            {
                if (((tableLayoutPanel.Controls[i]) is Button) && ((tableLayoutPanel.Controls[i] as Button).BackColor == againSelectedColor))
                {
                    (tableLayoutPanel.Controls[i] as Button).BackColor = selectedColor; //так как можем выбирать только из ранее отобранных,
                    
                }

            }

        }

        private void DeinitLottoTable()
        {
            this.Controls.Clear();

        }

        public void InitLottoTable(int HowMin, int HowMax, int From)
        {
            InitLottoTable(HowMin, HowMax, From, 1, From);
        }

        public void InitLottoTable(int HowMin, int HowMax, int From, int StartOfBalls, int EndOfBalls)
        {
            _Error = false;
            _ErrorMessage = "";

            CoinColumns = new List<int>();
            CoinRows = new List<int>();

            _StartOfBalls = StartOfBalls; // с какого числа начинается лотерея
            _EndOfBalls = EndOfBalls;//

            if (HowMax < HowMin) HowMin = HowMax;
            if (HowMin > From) HowMin = From;
            if (HowMax > From) HowMax = From;
            _HowMin = HowMin;
            _HowMax = HowMax;
            _From = From;

            _AgainSelect = false;// Первый отбор номеров
            _Selected = 0;
            selectedNumber = new List<int>();
            _AgainSelected = 0;
            againSelectedNumber = new List<int>();

            DeinitLottoTable();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Parent = this;

            _Row = (int)Math.Ceiling(Math.Sqrt(From));
            _Col = (int)Math.Ceiling((double)((double)From / (double)_Row));
            Percent = 100 / _Row;

            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.ColumnCount = _Col;
            tableLayoutPanel.RowCount = _Row;
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;

            for (int i = 0; i < _Row; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Percent));

                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Percent));

            }

            int count = _StartOfBalls;
            for (int j = 0; j < _Row; j++)
            {

                for (int i = 0; i < _Col; i++)
                {

                    // button
                    // 
                    Button button = new Button();
                    button.FlatStyle = FlatStyle.Flat;
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0);
          
                    button.Name = "button" + (count).ToString();
           
                    button.TabIndex = count;
                    button.Tag = count;//храню номер в TAG
                    button.UseVisualStyleBackColor = true;
                    button.BackColor = unselectedColor;

                    button.Font = new Font(button.Font.Name, _FontSize, button.Font.Style);
                  
                    button.Text = (count).ToString();
                    button.Click += new EventHandler(button_Click);
                    tableLayoutPanel.Controls.Add(button, i, j);

                    count++;

                    if (count > _EndOfBalls) break;
                }

            }

        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {

                int number = (int)(sender as Button).Tag;

                if (_AgainSelect != true)
                {
                    #region First Select Отмечаем числа на пустом поле

                    if (selectedNumber.Contains(number))
                    {
                        _Selected--;
                        selectedNumber.Remove(number);
                        (sender as Button).BackColor = unselectedColor;
                        return;
                    }


                    if (_Selected >= _HowMax) return;

                    _Selected++;
                    selectedNumber.Add(number);
                    (sender as Button).BackColor = selectedColor;

                    #endregion First Select
                }
                else
                {
                    #region Again Select выбираем числа из ранее отобранных!

                    if (!selectedNumber.Contains(number)) return; //если номер не принадлежит ранее отобранным номерам - пропускаем

                    if (againSelectedNumber.Contains(number))
                    {
                        _AgainSelected--;
                        againSelectedNumber.Remove(number);
                        (sender as Button).BackColor = selectedColor;
                        return;
                    }

                    _AgainSelected++;
                    againSelectedNumber.Add(number);
                    (sender as Button).BackColor = againSelectedColor;

                    #endregion Again Select
                }
            }
            finally
            {
                if (NumbersChanged != null) NumbersChanged.Invoke(sender, e); 
            }
        }

        public void SetSelectedNumbers(int[] array)
        {
            if ((array == null) || (array.Length == 0)) return;
            try
            {
                int count = tableLayoutPanel.Controls.Count;
                for (int i = 0; i < array.Length; i++)
                {
                    if (_Selected >= _HowMax) return;
                    if (array[i] > _From) return;

                    _Selected++;
                    selectedNumber.Add(array[i]);

                    for (int j = 0; j < count; j++)
                    {
                        if ((tableLayoutPanel.Controls[j] is Button) && ((int)(tableLayoutPanel.Controls[j] as Button).Tag == array[i]))
                        {
                            (tableLayoutPanel.Controls[j] as Button).BackColor = selectedColor;
                        }

                    }

                }


            }
            finally
            {
                if (NumbersChanged != null) NumbersChanged.Invoke(this, null); 
            }
        }
        public void SetAgainSelectedNumbers(int[] array)
        {
            if ((array == null) || (array.Length == 0)) return;
            try
            {
                int count = tableLayoutPanel.Controls.Count;
                for (int i = 0; i < array.Length; i++)
                {
                    if (_AgainSelected >= _Selected) return;
                    if (array[i] > _From) return;

                    _AgainSelected++;
                    againSelectedNumber.Add(array[i]);

                    for (int j = 0; j < count; j++)
                    {
                        if ((tableLayoutPanel.Controls[j] is Button) && ((int)(tableLayoutPanel.Controls[j] as Button).Tag == array[i]))
                        {
                            (tableLayoutPanel.Controls[j] as Button).BackColor = againSelectedColor;
                        }

                    }

                }


            }
            finally
            {
                if (NumbersChanged != null) NumbersChanged.Invoke(this, null); 
            }
        }

        /// <summary>
        /// Проинвертируем выбранные номера
        /// </summary>
        public void InvertSelected()
        {
            try
            {

                List<int> newSelected = new List<int>();
                for (int i = 0; i < _From; i++)
                {
                    if (!selectedNumber.Contains(i + 1))
                    {
                        newSelected.Add(i + 1);
                    }
                }
                ResetSelected();
                SetSelectedNumbers(newSelected.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в InverseSelected: " + ex.Message);
            }
        }
        /// <summary>
        /// Отметить все
        /// </summary>
        public void SelectAll()
        {
            try
            {
                int count = tableLayoutPanel.Controls.Count;

                selectedNumber.Clear();
                _Selected = 0;
                for (int i = 0; i < count; i++)
                {
                    if (_Selected >= _HowMax) return;

                    if ((tableLayoutPanel.Controls[i] is Button))
                    {
                        (tableLayoutPanel.Controls[i] as Button).BackColor = selectedColor;
                        selectedNumber.Add((int)(tableLayoutPanel.Controls[i] as Button).Tag);
                        _Selected += 1;
                    }

                }


            }
            finally
            {
                if (NumbersChanged != null) NumbersChanged.Invoke(this, null); 
            }

        }
    }


}
