using System;
using System.Drawing;
using System.Windows.Forms;
using BitCraft.Properties;
using System.Threading;

namespace TotoFBitCrafton.UserControls
{
    /// <summary>
    /// Тип информационного сообщения.
    /// </summary>
    public enum MessagesTypes
    {
        Info, //Просто информация, подключились, на сервере столько-то ордеров, новых ордеров нет. Может не отображаться, если задано
        Attention, //Важная информация, например, новый ордер
        Warning, //Внимание!
        Error, //Ошибка
        Success, //Порядок
        Normal,//Обычный текст без выделения
    }

    public partial class StatusMessagePanel : UserControl
    {
        private int _PanelBottomHeight;
        private bool _StopProcess;
        private bool _ProcessRunning = false;

       CancellationTokenSource cancellationToken;

        public delegate void EventHandler(Object sender, EventArgs e);
        public event EventHandler StopButtonClick;

        bool _IsCollapsed ;
        /// <summary>
        /// Свернуть или развернуть окно сообщений
        /// </summary>
        public bool IsCollapsed
        {
            get
            {
                return _IsCollapsed;
            }
            set
            {
                if (value != _IsCollapsed)
                    SetCollapsed(value);
            }
        }

        /// <summary>
        /// Процесс запущен StartProcess(true) и не остановлен StartProcess(false)
        /// </summary>
        public bool ProcessRunning
        {
            get
            {
                return _ProcessRunning;
            }
        }
        //дает знать что процесс следует остановить так как нажали Стоп, но это не говорит о том что он запущен, для этого ProcessRunning
        public bool StopProcess
        {
            get
            {
                return _StopProcess;
            }
        }

        public StatusMessagePanel()
        {
            InitializeComponent();

            _PanelBottomHeight = this.Height;
            buttonCollapseStatusBar.Tag = 1;
        }

        /// <summary>
        /// просто цикл показывающий что идет процесс
        /// </summary>
        /// <param name="start">старт-стоп</param>
        /// <param name="speed"></param>
        ///  <param name="tooltip"></param>
        public void StartLoopProcess(bool start, int speed = 50, string tooltip = "Background process in progress", CancellationTokenSource cts = null)
        {
            _StopProcess = false;
            if (start)
            {
                cancellationToken = cts;
                stopProcessButton.Enabled = true;
                stopProcessButton.Focus();
                ProgressBar.Style = ProgressBarStyle.Marquee;
                ProgressBar.MarqueeAnimationSpeed = speed;
                toolTip1.SetToolTip(this.ProgressBar, tooltip);
            }
            else
            {
                stopProcessButton.Enabled = false;
                ProgressBar.Value = 0;
                toolTip1.SetToolTip(this.ProgressBar, "");
                ProgressBar.Style = ProgressBarStyle.Blocks;
                ProgressBar.MarqueeAnimationSpeed = 0;
            }
        }


        /// <summary>
        ///  true - запустить прогресс бар, false - остановить его
        /// </summary>
        /// <param name="value"></param>
        /// <param name="Maximum"></param>
        public void StartProcess(bool value, int Maximum, int step=1, string tooltip = "Background process in progress",  CancellationTokenSource cts=null)
        {
           
            _ProcessRunning = value;
            _StopProcess = false;
            if (value)
            {
                cancellationToken = cts;

                stopProcessButton.Enabled = true;
                stopProcessButton.Focus();
                ProgressBar.Value = 0;
                ProgressBar.Step = step;
                //ProgressBar.Step = Maximum / 100;
                ProgressBar.Maximum = Maximum;
               
            }
            else
            {
                stopProcessButton.Enabled = false;
                ProgressBar.Value = 0;

            }

        }


        /// <summary>
        /// Очистка окна сообщения
        /// </summary>
        public void StatusClear()
        {
            textBoxMessages.Clear();
        }

        /// <summary>
        /// Вывод сообщения в окно
        /// </summary>
        /// <param name="text">текст сообщения</param>
        public void StatusMessage(string text)
        {
            StatusMessage(text, MessagesTypes.Normal, true);
        }


        /// <summary>
        /// Выводим сообщение в окно лога
        /// </summary>
        /// <param name="text">сообщение</param>
        /// <param name="inStart">true- сообщение в начало лога,false -в конец</param>

        public void StatusMessage(string text, bool inStart)
        {
            StatusMessage(text, MessagesTypes.Normal, inStart);
        }

        /// <summary>
        /// Выводим сообщение в окно лога. Последнее в начало
        /// </summary>
        /// <param name="msg">сообщение</param>
        /// <param name="type">Тип сообщения: Важно,Ошибка,Предупреждение</param>
        public void StatusMessage(string msg, MessagesTypes type)
        {
            StatusMessage(msg, type, true);
        }

        /// <summary>
        /// Выводим сообщение в окно лога. Последнее в начало
        /// </summary>
        /// <param name="msg">сообщение</param>
        /// <param name="type">Тип сообщения: Важно,Ошибка,Предупреждение</param>
        public void ErrorMessage(string msg)
        {
            StatusMessage(msg, MessagesTypes.Error, true);
        }
        public void SuccessMessage(string msg)
        {
            StatusMessage(msg, MessagesTypes.Success, true);
        }
        public void InfoMessage(string msg)
        {
            StatusMessage(msg, MessagesTypes.Info, true);
        }
        public void WarningMessage(string msg)
        {
            StatusMessage(msg, MessagesTypes.Warning, true);
        }
        /// <summary>
        /// Исправить выделение цветом при записи в начало файла!
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        /// <param name="inStart"></param>
        public void StatusMessage(string msg, MessagesTypes type, bool inStart)
        {
            try
            {
                if (textBoxMessages == null || textBoxMessages.IsDisposed) return; 
                if (inStart) textBoxMessages.Select(0, 0);
                
                System.Drawing.FontStyle newFontStyle;
                string symbol = "";
                switch (type)
                {
                    case MessagesTypes.Info:
                        
                        symbol = "";
                   
                        break;
                    case MessagesTypes.Attention: symbol = "! "; //Важная инфа к вниманию
                        newFontStyle = FontStyle.Bold;
                        textBoxMessages.SelectionFont = new Font(
                                textBoxMessages.Font.FontFamily,
                                textBoxMessages.Font.Size,
                                newFontStyle
                             );
                        textBoxMessages.SelectionColor = Color.Green;
                        textBoxMessages.SelectedText = symbol;
                    
                        break;

                    case MessagesTypes.Warning: symbol = "!! "; //Предупреждение
                        newFontStyle = FontStyle.Bold;
                        textBoxMessages.SelectionFont = new Font(
                                textBoxMessages.Font.FontFamily,
                                textBoxMessages.Font.Size,
                                newFontStyle
                             );

                        textBoxMessages.SelectionColor = Color.LightPink;
                        textBoxMessages.SelectedText = symbol;
                 
                        break;
                    case MessagesTypes.Error: symbol = "!!! "; //Ошибка
                        newFontStyle = FontStyle.Bold;
                        textBoxMessages.SelectionFont = new Font(
                               textBoxMessages.Font.FontFamily,
                               textBoxMessages.Font.Size,
                               newFontStyle
                            );
                        textBoxMessages.SelectionColor = Color.Red;
                        textBoxMessages.SelectedText = symbol;
                  
                        break;
                }

                newFontStyle = FontStyle.Regular;
                textBoxMessages.SelectionFont = new Font(
                        textBoxMessages.Font.FontFamily,
                        textBoxMessages.Font.Size,
                        newFontStyle
                     );

                if (type != MessagesTypes.Normal) //Для нормального не отображаем время и не выделяем
                {
                    string time = DateTime.Now.ToString();
                    textBoxMessages.SelectionColor = Color.Blue; //выбираем цвет отображения
                    textBoxMessages.SelectedText = time + ": "; //задаем выделения текста и выводим его
                }

                textBoxMessages.SelectionColor = Color.Black;

                textBoxMessages.SelectedText = (msg + Environment.NewLine);
            }
            catch (Exception)
            {

            }
        }

        private void logClearButton_Click(object sender, EventArgs e)
        {
            textBoxMessages.Clear();

        }
        /// <summary>
        /// Из основной программы программно заставим остановиться процессу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetStopProcess(object sender, EventArgs e)
        {
            _StopProcess = true;
            stopProcessButton.Enabled = false;
            if (StopButtonClick != null)
                StopButtonClick.Invoke(sender, e);

            if (cancellationToken != null && cancellationToken.Token.CanBeCanceled)
            {
                cancellationToken.Cancel();
            }
        }

        private void stopProcessButton_Click(object sender, EventArgs e)
        {
            _StopProcess = true;
            stopProcessButton.Enabled = false;
            if (StopButtonClick != null)
                StopButtonClick.Invoke(sender, e);

            if (cancellationToken!=null && cancellationToken.Token.CanBeCanceled)
            {
                cancellationToken.Cancel();
            }
            
        }

        private void buttonCollapseStatusBar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(buttonCollapseStatusBar.Tag) == 1) //Развернут, надо свернуть
            {

                this.Height = panelProgressBar.Height;
                buttonCollapseStatusBar.Image = Resources.ExpandIcon;
                buttonCollapseStatusBar.Tag = 0;
                toolTip1.SetToolTip(this.buttonCollapseStatusBar, "Развернуть окно сообщений");

                this._IsCollapsed = true;

            }
            else //надо развернуть
            {
                this.Height = _PanelBottomHeight;
                buttonCollapseStatusBar.Image = Resources.CollapseIcon;
                toolTip1.SetToolTip(this.buttonCollapseStatusBar, "Свернуть окно сообщений");
                buttonCollapseStatusBar.Tag = 1;
                this._IsCollapsed = false;
            }

            panelProgressBar.Focus(); 
            this.Parent.Refresh(); 
        }


        /// <summary>
        /// Свернуть или развернуть окно
        /// </summary>
        /// <param name="collapse"></param>
        private void SetCollapsed(bool collapse)
        {
            if (collapse) //Свернуть
            {
                if (Convert.ToInt16(buttonCollapseStatusBar.Tag) != 1) return; //уже свернут
                this.Height = panelProgressBar.Height;
                buttonCollapseStatusBar.Image = Resources.ExpandIcon;
                buttonCollapseStatusBar.Tag = 0;
                toolTip1.SetToolTip(this.buttonCollapseStatusBar, "Развернуть окно сообщений");

                this._IsCollapsed = true;
            }
            else
            {
                if (Convert.ToInt16(buttonCollapseStatusBar.Tag) == 1) return; //Развернут
                this.Height = _PanelBottomHeight;
                buttonCollapseStatusBar.Image = Resources.CollapseIcon;
                toolTip1.SetToolTip(this.buttonCollapseStatusBar, "Свернуть окно сообщений");
                buttonCollapseStatusBar.Tag = 1;
                this._IsCollapsed = false;
            }

            if (this.Parent != null){ 
                this.Parent.Refresh(); 
            }
        }
    }
}
