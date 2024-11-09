using BitCraft.Classes;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BitCraft
{
    public partial class FormMain : Form
    {
        const int MAX_COUNT = 256; 
        string EmptyBinString = String.Join("", Enumerable.Repeat("0", MAX_COUNT));
        string EmptyHexString = String.Join("", Enumerable.Repeat("0", 64));
        string EmptyDecString = "0";

        Network CurrentNetwork = Network.Main;
        ProgramSettingsClass ProgramSettings = null;
        AddressDataBaseClass AddressDataBase = null;

        Dictionary<string, string> FoundedAdresses = new Dictionary<string, string>(); 

        private static string _ProgramDataPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        string FoundedFilePath
        {
            get
            {
                return Path.Combine(_ProgramDataPath, Constants.FoundedAddressesFileName);
            }
        }

        private void ErrorMessage(string message)
        {
            statusMessagePanel.ErrorMessage(message);
            statusMessagePanel.IsCollapsed = false;
        }
        private void StatusMessage(string message)
        {
            statusMessagePanel.StatusMessage(message);
            statusMessagePanel.IsCollapsed = false;
        }

        #region Settings
        private void LoadSettings()
        {
            try
            {
                string configFile = Path.Combine(Application.StartupPath, Constants.SettingsName);

                if (File.Exists(configFile))
                {
                    ProgramSettings = ProgramSettingsClass.Load(configFile);
                }
                else
                {
                    ProgramSettings = new ProgramSettingsClass(configFile);
                }


                textBoxAddressesDataBase.Text = ProgramSettings.AddressDataBaseFile;

            }
            catch (Exception ex)
            {
                ErrorMessage("LoadSettings: " + ex.Message);
            }
        }

        private void SaveSettings()
        {
            try
            {

                ProgramSettings.AddressDataBaseFile = textBoxAddressesDataBase.Text;


                ProgramSettings.Save();

            }
            catch (Exception ex)
            {
                ErrorMessage("SaveSettings: " + ex.Message);
            }
        }
        #endregion Settings

        internal void ShowBalloonTip(string title, string text, ToolTipIcon icon = ToolTipIcon.Info, int timeout = 100)
        {
            try
            {

                notifyIconMain.ShowBalloonTip(timeout, title, text, icon);

            }
            catch (Exception ex)
            {
                ErrorMessage($"ShowBalloonTip :" + ex.Message);

            }
        }
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadSettings();

            LoadFoundedAddresses(); //загружаем ранее найденные адреса
   
            this.Text = Constants.AppName + ' ' + Helper.GetVersion();
            notifyIconMain.Text = Constants.AppName;

            ClearTextNumbersBoxes();

            TryOpenAddressesDataBase();

        }
        /// <summary>
        /// Попытка открыть базу данных с адресами биткоина
        /// </summary>
        private void TryOpenAddressesDataBase()
        {
            try
            {

                if (File.Exists(ProgramSettings.AddressDataBaseFile))
                {
                    AddressDataBase = new AddressDataBaseClass(ProgramSettings.AddressDataBaseFile);

                    toolStripStatusLabelAddressesCount.Text = AddressDataBase.GetAddressesCount().ToString();
                }

            }
            catch (Exception ex)
            {
                ErrorMessage("TryOpenAddressesDataBase: " + ex.Message);
            }
        }

        private void LoadFoundedAddresses()
        {
            try
            {

                if (!File.Exists(FoundedFilePath))
                {
                    return;
                }

                string[] lines = File.ReadAllLines(FoundedFilePath);

                textBoxFoundedAddresses.Lines = lines;

                foreach (string line in lines)
                {
                    string[] values = line.Trim().Split(new string[] { ProgramSettings.Delimiter }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length == 2)
                    {
                        FoundedAdresses.Add(values[0], values[1]);
                    }
                    else
                    {
                        ErrorMessage($"Строка {line} не может быть преобразована в ключ-адрес");
                    }

                }

                toolStripStatusLabelFoundedAddressesCount.Text = FoundedAdresses.Count.ToString();

            }
            catch (Exception ex)
            {
                ErrorMessage("LoadFoundedAddresses: " + ex.Message);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();

            if (AddressDataBase != null)
            {
                AddressDataBase.Dispose();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void craftControl1_NumbersChanged(object sender, EventArgs e)
        {
            try
            {

                if (craftControl1.SelectedNumbers.Count == 0)
                {
                    ClearTextNumbersBoxes();
                    bitcoinItem1.Clear();
                }
                else
                {

                    char[] binCharArray = EmptyBinString.ToArray();

                    for (int i = 1; i <= MAX_COUNT; i++) //1-255
                    {
                        if (craftControl1.SelectedNumbers.Contains(i))
                        {
                            binCharArray[MAX_COUNT - i] = '1'; //строка в обратном направлении
                        }
                    }


                    var binString = String.Join("", binCharArray);
                    textBoxBitString.Text = binString;

                    string hex = Converter.BinStringToHexString(binString);
                    textBoxHexString.Text = hex;

                    BigInteger b1 = BigInteger.Parse("0"+hex, NumberStyles.HexNumber); //без "0" будет отрицательным если начинается с 8-F
                    string dec = b1.ToString();
                    textBoxDecString.Text = dec;

                    GenerateAddressesFromHex(hex);

                }

            }
            catch (Exception ex)
            {

                ErrorMessage("craftControl1_NumbersChanged: " + ex.Message);
            }
        }

        private void CheckAddressesExists()
        {

            //Compressed
            if (AddressDataBase.AddressExists(bitcoinItem1.AddressLegacyCompressed))
            {
                FoundMessage(privateKeyHex: bitcoinItem1.PrivateKeyCompressedHex, privateKeyWif: bitcoinItem1.PrivateKeyCompressedWif, address: bitcoinItem1.AddressLegacyCompressed);
            }

            if (AddressDataBase.AddressExists(bitcoinItem1.AddressSegwitCompressed))
            {
                FoundMessage(privateKeyHex: bitcoinItem1.PrivateKeyCompressedHex, privateKeyWif: bitcoinItem1.PrivateKeyCompressedWif, address: bitcoinItem1.AddressSegwitCompressed);
            }

            if (AddressDataBase.AddressExists(bitcoinItem1.AddressSegwitP2SHCompressed)) //эти адреса навероное бесмысленно проверять?
            {
                    FoundMessage(privateKeyHex: bitcoinItem1.PrivateKeyCompressedHex, privateKeyWif: bitcoinItem1.PrivateKeyCompressedWif, address: bitcoinItem1.AddressSegwitP2SHCompressed);
            }
        
            //Uncompressed
            if (AddressDataBase.AddressExists(bitcoinItem1.AddressLegacyUnCompressed))
            {
                FoundMessage(privateKeyHex: bitcoinItem1.PrivateKeyUnCompressedHex, privateKeyWif: bitcoinItem1.PrivateKeyUnCompressedWif, address: bitcoinItem1.AddressLegacyUnCompressed);
            }

        }


        private void FoundMessage(string privateKeyHex, string privateKeyWif, string address)
        {
            string msg = $"Найден адрес: {address}, ключ Hex:  {privateKeyHex}, ключ Wif: {privateKeyWif}";


            if (FoundedAdresses.ContainsKey(privateKeyHex))
            {
                msg += " - он уже найден ранее";
            }
            else
            {
                ShowBalloonTip("Найдено", msg, ToolTipIcon.Info);
                FoundedAdresses.Add(privateKeyHex, address); //достаточно KeyHex и address
                string founded = $"{privateKeyHex}{ProgramSettings.Delimiter}{address}";
                textBoxFoundedAddresses.AppendText($"{Environment.NewLine}{founded}");
                //запишем сразу в файл
                using (StreamWriter outputFile = new StreamWriter(FoundedFilePath, true))
                {
                    outputFile.WriteLine(founded);
                }
            }

            StatusMessage(msg);
            toolStripStatusLabelFoundedAddressesCount.Text = FoundedAdresses.Count.ToString();
        }

        private void buttonClearCraft_Click(object sender, EventArgs e)
        {
            craftControl1.ResetSelected();
            textBoxBitString.Text = EmptyBinString;
            textBoxHexString.Text = EmptyHexString;
            bitcoinItem1.Clear();
        }

        private void buttonSelectAddressesDataBase_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Укажите файл ...";
            dlg.Filter = Constants.DbFilter;
            dlg.ValidateNames = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ProgramSettings.AddressDataBaseFile = dlg.FileName;
                textBoxAddressesDataBase.Text = ProgramSettings.AddressDataBaseFile;
                TryOpenAddressesDataBase();
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            craftControl1.SelectAll();
        }

        private void buttonSelectRandom_Click(object sender, EventArgs e)
        {
            craftControl1.SelectRandom();
        }

        private void craftControl1_NewError(object sender, EventArgs e)
        {
            ErrorMessage("Error in CraftControl: " + ((UserControls.NewErrorEventArgs)e).Error);

        }

        /// <summary>
        /// Сгенерировать один пакет в котором сжатый и несжатый ключ и соответствующие адреса
        /// </summary>
        internal void GenerateOnePacket()
        {
            #region Compressed
            var privateKeyCompressed = new Key(true);

            var bitcoinPrivateKeyCompressed = privateKeyCompressed.GetWif(CurrentNetwork);
            string AddressLegacyCompressed = bitcoinPrivateKeyCompressed.GetAddress(ScriptPubKeyType.Legacy).ToString();
            string AddressSegwitCompressed = bitcoinPrivateKeyCompressed.GetAddress(ScriptPubKeyType.Segwit).ToString();

            #endregion Compressed

            #region UnCompressed
            var privateKeyUnCompressed = new Key(false);

            var bitcoinPrivateKeyUnCompressed = privateKeyUnCompressed.GetWif(CurrentNetwork);
            string AddressLegacyUnCompressed = bitcoinPrivateKeyUnCompressed.GetAddress(ScriptPubKeyType.Legacy).ToString();
            string AddressSegwitUnCompressed = bitcoinPrivateKeyUnCompressed.GetAddress(ScriptPubKeyType.Segwit).ToString();

            #endregion UnCompressed
        }
   

        private void GenerateAddressesFromHex(string hex)
        {
            bitcoinItem1.GenerateKey(hex);

            if (!string.IsNullOrEmpty(bitcoinItem1.LastError)) //некоторые комбинации вызывают ошибку
            {
                ErrorMessage("BitcoinItem error: " + bitcoinItem1.LastError);
            }
            else //Можно пытаться искать адреса в базе
            {
                if (AddressDataBase != null)
                {
                    CheckAddressesExists();
                }

            }
        }

        /// <summary>
        /// Очистить поля вывода числовых представлений
        /// </summary>
        private void ClearTextNumbersBoxes()
        {
            textBoxBitString.Text = EmptyBinString;
            textBoxHexString.Text = EmptyHexString;
            textBoxDecString.Text = EmptyDecString;
        }

        private void buttonbuttonSelectRandom2_Click(object sender, EventArgs e)
        {
            
            try
            {
                string hex = bitcoinItem1.RandomHexFromNbitcoin();
                SetChoiceFromHex(hex);
            }
            catch (Exception ex)
            {
                ErrorMessage("buttonbuttonSelectRandom2_Click: " + ex.Message);
            }
        }
        /// <summary>
        /// Установить все значения из hex строки и сгенерировать ключи
        /// </summary>
        /// <param name="hex"></param>
        private void SetChoiceFromHex(string hex)
        {
            try
            {
                //нужно уравнивать до 64
                if (hex.Length >= 64) //для больших чисел ведущий 0 добавляется превышая 256
                {
                    hex = hex.TrimStart(new char[] { '0' });
                }

                hex = hex.PadLeft(64, '0');

                BigInteger b = BigInteger.Parse("0" + hex, NumberStyles.HexNumber); //без "0" будет отрицательным если начинается с 8-F
                var binary = b.ToBinaryString();

                textBoxBitString.Text = binary;
                textBoxHexString.Text = hex;
                textBoxDecString.Text = b.ToString();

                craftControl1.SetFromBinary(binary);
                GenerateAddressesFromHex(hex);
            }
            catch (Exception ex)
            {
                ErrorMessage("SetChoiceFromHex: " + ex.Message);
            }
        }

        private void buttonDecConvert_Click(object sender, EventArgs e)
        {
            try
            {

                var decString = textBoxDecString.Text.Trim();
                var b = BigInteger.Parse(decString, NumberStyles.Integer);
                var binary = b.ToBinaryString();

                string hex = b.ToHexadecimalString();
                textBoxBitString.Text = binary;
                textBoxHexString.Text = hex;

                craftControl1.SetFromBinary(binary);
                GenerateAddressesFromHex(hex);
            }
            catch (Exception ex)
            {
                ErrorMessage("buttonDecConvert_Click: " + ex.Message);
            }

        }
        private void buttonHexConvert_Click(object sender, EventArgs e)
        {
            try
            {
                var hex = textBoxHexString.Text.Trim();
                SetChoiceFromHex(hex);
  
            }
            catch (Exception ex)
            {
                ErrorMessage("buttonHexConvert_Click: " + ex.Message);
            }
        }

        private void buttonBinConvert_Click(object sender, EventArgs e)
        {
            try
            {
                var bitString = textBoxBitString.Text.Trim();
                //нужно уравнивать до 256
                if (bitString.Length >= 256) //для больших чисел ведущий 0 добавляется превышая 256
                {
                    bitString = bitString.TrimStart(new char[] { '0' });
                }

                bitString = bitString.PadLeft(256, '0');

                string hex = Converter.BinStringToHexString(bitString);

                BigInteger b = BigInteger.Parse("0" + hex, NumberStyles.HexNumber); //без "0" будет отрицательным если начинается с 8-F

                textBoxDecString.Text = b.ToString();
                textBoxHexString.Text = hex;

                craftControl1.SetFromBinary(bitString);
                GenerateAddressesFromHex(hex);
            }
            catch (Exception ex)
            {
                ErrorMessage("buttonBinConvert_Click: " + ex.Message);
            }

        }


        private void textBoxDecString_KeyUp(object sender, KeyEventArgs e)
        {
            string pattern = @"^[0-9]+$";

            if (!Regex.IsMatch(textBoxDecString.Text, pattern))
            {
                string value = ((char)e.KeyValue).ToString();
   
                textBoxDecString.Text = textBoxDecString.Text.Replace(value, "");
  
                textBoxDecString.Select(textBoxDecString.Text.Length, 0);
                e.Handled = true;
            }
        }


        private void textBoxHexString_KeyUp(object sender, KeyEventArgs e)
        {
            string pattern = @"^[0-9a-fA-F]+$";
 
            if (!Regex.IsMatch(textBoxHexString.Text, pattern))
            {
                string value = ((char)e.KeyValue).ToString();

                textBoxHexString.Text = textBoxHexString.Text.Replace(value, "");
  
                textBoxHexString.Select(textBoxHexString.Text.Length, 0);
                e.Handled = true;
            }
        }

        private void textBoxBitString_KeyUp(object sender, KeyEventArgs e)
        {
            string pattern = @"^[0-1]+$";

            if (!Regex.IsMatch(textBoxBitString.Text, pattern))
            {
                string value = ((char)e.KeyValue).ToString();
     
                textBoxBitString.Text = textBoxBitString.Text.Replace(value, "");
        
                textBoxBitString.Select(textBoxBitString.Text.Length, 0);
                e.Handled = true;
            }
        }


    }
}
