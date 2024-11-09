using BitCraft.Classes;
using NBitcoin;
using System;
using System.Collections;
using System.Windows.Forms;

namespace BitCraft.UserControls
{
    public partial class BitcoinItem : UserControl
    {
        //SEGWIT BECH32 должны создаваться из СЖАТОГО ключа иначе монеты станут недоступны!
        public string LastError { get; private set; }

        Network CurrentNetwork = Network.Main;

        public string PrivateKeyCompressedWif { get; private set; }
        public string PrivateKeyUnCompressedWif { get; private set; }

        public string PrivateKeyCompressedHex { get; private set; }
        public string PrivateKeyUnCompressedHex { get; private set; }

        public string AddressLegacyCompressed { get; private set; }
        public string AddressLegacyUnCompressed { get; private set; }

        public string AddressSegwitCompressed { get; private set; }
        public string AddressSegwitP2SHCompressed { get; private set; }

        public BitcoinItem()
        {
            InitializeComponent();
        }

        public void SetCurrentNetwork(Network network)
        {
            CurrentNetwork= network;
        }

        private void CheckBalance(string address)
        {
            try
            {
                string url = "https://www.blockchain.com/ru/explorer/addresses/btc/" + address;
                System.Diagnostics.Process.Start(url);

            }
            catch(Exception ex)
            {
                ;
            }
        }
        private void buttonLegacyBalanceCompressed_Click(object sender, EventArgs e)
        {
            CheckBalance(textBoxLegacyCompressed.Text.Trim());
        }

        private void buttonSegwitBalanceCompressed_Click(object sender, EventArgs e)
        {
            CheckBalance(textBoxSegwitCompressed.Text.Trim());
        }

        private void buttonLegacyBalanceUnCompressed_Click(object sender, EventArgs e)
        {
            CheckBalance(textBoxLegacyUnCompressed.Text.Trim());
        }

        private void buttonSegwitBalanceUnCompressed_Click(object sender, EventArgs e)
        {
            CheckBalance(textBoxSegwitP2SHCompressed.Text.Trim());
        }

        internal void GenerateKey(string hexString)
        {
            try
            {
                LastError = String.Empty;

                var byteArray = Converter.HexToByte(hexString); //нужно 32 разряда для Key 
                if (byteArray == null || byteArray.Length != 32)
                {
                    LastError = "Получена некорректная шестнадцатеричная строка";
                    return;
                }

                #region Compressed
                var privateKeyCompressed = new Key(byteArray, -1, true);
             
                PrivateKeyCompressedHex = privateKeyCompressed.ToHex();
                PrivateKeyCompressedWif = privateKeyCompressed.ToString(CurrentNetwork);

                textBoxPrivateKeyCompressed.Text = PrivateKeyCompressedWif;

                var bitcoinPrivateKeyCompressed = privateKeyCompressed.GetWif(CurrentNetwork);
                AddressLegacyCompressed = bitcoinPrivateKeyCompressed.GetAddress(ScriptPubKeyType.Legacy).ToString();
                textBoxLegacyCompressed.Text = AddressLegacyCompressed;

                AddressSegwitCompressed = bitcoinPrivateKeyCompressed.GetAddress(ScriptPubKeyType.Segwit).ToString();
                textBoxSegwitCompressed.Text = AddressSegwitCompressed;

                AddressSegwitP2SHCompressed = bitcoinPrivateKeyCompressed.GetAddress(ScriptPubKeyType.SegwitP2SH).ToString();
                textBoxSegwitP2SHCompressed.Text = AddressSegwitP2SHCompressed;


                #endregion Compressed

                #region UnCompressed
                var privateKeyUnCompressed = new Key(byteArray, -1, false);
                PrivateKeyUnCompressedHex = privateKeyUnCompressed.ToHex();
                PrivateKeyUnCompressedWif = privateKeyUnCompressed.ToString(CurrentNetwork);

                textBoxPrivateKeyUnCompressed.Text = PrivateKeyUnCompressedWif;

                var bitcoinPrivateKeyUnCompressed = privateKeyUnCompressed.GetWif(CurrentNetwork);
                AddressLegacyUnCompressed = bitcoinPrivateKeyUnCompressed.GetAddress(ScriptPubKeyType.Legacy).ToString();
                textBoxLegacyUnCompressed.Text = AddressLegacyUnCompressed;

                #endregion UnCompressed
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
            }
        }

        internal void Clear()
        {

            textBoxPrivateKeyCompressed.Clear();
            textBoxLegacyCompressed.Clear();
            textBoxSegwitCompressed.Clear();
            textBoxSegwitP2SHCompressed.Clear();

            textBoxPrivateKeyUnCompressed.Clear();
            textBoxLegacyUnCompressed.Clear();
          
            PrivateKeyCompressedWif = String.Empty;
            PrivateKeyUnCompressedWif = String.Empty;

            PrivateKeyCompressedHex = String.Empty;
            PrivateKeyUnCompressedHex = String.Empty;

            AddressLegacyCompressed = String.Empty;
            AddressLegacyUnCompressed = String.Empty;

            AddressSegwitCompressed = String.Empty;
     
            AddressSegwitP2SHCompressed = String.Empty;
        
        }
  
        internal string RandomHexFromNbitcoin()
        {
            var privateKey = new Key();
            return privateKey.ToHex();
        }
    }
}
