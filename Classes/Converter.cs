using System;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using NBitcoin.DataEncoders;
using NBitcoin;
using System.Globalization;
using System.Numerics;

namespace BitCraft.Classes
{
    class Converter
    {
        static char[] HexChars = new char[] {  '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                         'A', 'B', 'C', 'D', 'E', 'F' };
        static char[] BinChars = new char[] { '0', '1' };

        public static string BinStringToHexString(string binString)
        {
            if (binString.Length % 2 != 0)
            {
                throw new Exception("Invalid BINARY");
            }

            return string.Join("",
                        Enumerable.Range(0, binString.Length / 8)
                        .Select(i => Convert.ToByte(binString.Substring(i * 8, 8), 2).ToString("X2")));
     
        }
        public static string BigIntToString(BigInteger value, char[] baseChars)
        {
            string result = string.Empty;
            BigInteger targetBase = (BigInteger)baseChars.Length;

            do
            {

                BigInteger remainder1 = BigInteger.Remainder(value, targetBase);

                result = baseChars[(int)remainder1] + result;
                value = BigInteger.Divide(value, targetBase);
            }
            while (value > 0);

            return result;
        }

        // <summary>
        /// Turns a byte array into a Hex encoded string
        /// </summary>
        /// <param name="bytes">The bytes to encode to hex</param>
        /// <returns>The hex encoded representation of the bytes</returns>
        public static string BytesToHexString(byte[] bytes, bool upperCase = false)
        {
            if (upperCase)
            {
                return string.Concat(bytes.Select(byteb => byteb.ToString("X2")).ToArray());
            }
            else
            {
                return string.Concat(bytes.Select(byteb => byteb.ToString("x2")).ToArray());
            }
        }

        public static string ByteToHex(byte[] pubKeySha)
        {
            byte[] data = pubKeySha;
            string hex = BitConverter.ToString(data);
            return hex;
        }
        public static byte[] HexToByte(string HexString)
        {
            if (HexString.Length % 2 != 0)
            {
                throw new Exception("Invalid HEX");
            }

            byte[] retArray = new byte[HexString.Length / 2];

            for (int i = 0; i < retArray.Length; ++i)
            {
                retArray[i] = byte.Parse(HexString.Substring(i * 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return retArray;
        }

        public static string SHA256HexHashString(string StringIn)
        {
            string hashString;
            using (var sha256 = SHA256Managed.Create())
            {
                var hash = sha256.ComputeHash(Encoding.Default.GetBytes(StringIn));
                hashString = BytesToHexString(hash, false);
            }

            return hashString;
        }

        public static byte[] Sha256(byte[] array)
        {
            SHA256Managed hashstring = new SHA256Managed();
            return hashstring.ComputeHash(array);
        }

        public static byte[] RipeMD160(byte[] array)
        {
            RIPEMD160Managed hashstring = new RIPEMD160Managed();
            return hashstring.ComputeHash(array);
        }

        public static byte[] AppendBitcoinNetwork(byte[] RipeHash, byte Network)
        {
            byte[] extended = new byte[RipeHash.Length + 1];
            extended[0] = (byte)Network;
            Array.Copy(RipeHash, 0, extended, 1, RipeHash.Length);
            return extended;
        }

        public static byte[] ConcatAddress(byte[] RipeHash, byte[] Checksum)
        {
            byte[] ret = new byte[RipeHash.Length + 4];
            Array.Copy(RipeHash, ret, RipeHash.Length);
            Array.Copy(Checksum, 0, ret, RipeHash.Length, 4);
            return ret;
        }

        public static string Base58Encode(byte[] array)
        {
            const string ALPHABET = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
            string retString = string.Empty;
            BigInteger encodeSize = ALPHABET.Length;
            BigInteger arrayToInt = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                arrayToInt = arrayToInt * 256 + array[i];
            }
            while (arrayToInt > 0)
            {
                int rem = (int)(arrayToInt % encodeSize);
                arrayToInt /= encodeSize;
                retString = ALPHABET[rem] + retString;
            }
            for (int i = 0; i < array.Length && array[i] == 0; ++i)
                retString = ALPHABET[0] + retString;

            return retString;
        }
    }
    public static class BitcoinAddressConverter
    {
        public static Bech32Encoder encoder = Network.Main.GetBech32Encoder(Bech32Type.WITNESS_PUBKEY_ADDRESS, true);
        public static byte[] ToCondensed(string addOrPk)
        {
            var decoded = Encoders.Base58.DecodeData(addOrPk);
            return decoded.Skip(1).Take(20).ToArray();
        }
        /// <summary>
        /// публичный адрес в его Ripemd160
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string ToRipemd160(string address)
        {

            if (address.StartsWith("bc1", StringComparison.OrdinalIgnoreCase))
            {
               // var encoder = Network.Main.GetBech32Encoder(Bech32Type.WITNESS_PUBKEY_ADDRESS, true);
                var bech32 = encoder.Decode(address.ToLower(), out var witVer);
                
                return Converter.BytesToHexString(bech32);

            }
            else
            {
                var condensed = ToCondensed(address);
                return Converter.BytesToHexString(condensed);
            
            }
        }

        public static void TestAddressFromPublicKey()
        {
            string HexHash = "0450863AD64A87AE8A2FE83C1AF1A8403CB53F53E486D8511DAD8A04887E5B23522CD470243453A299FA9E77237716103ABC11A1DF38855ED6F2EE187E9C582BA6";
            byte[] PubKey = Converter.HexToByte(HexHash);
            Console.WriteLine("Public Key:" + Converter.ByteToHex(PubKey));

            byte[] PubKeySha = Converter.Sha256(PubKey);
            Console.WriteLine("Sha Public Key:" + Converter.ByteToHex(PubKeySha));

            byte[] PubKeyShaRIPE = Converter.RipeMD160(PubKeySha);
            Console.WriteLine("Ripe Sha Public Key:" + Converter.ByteToHex(PubKeyShaRIPE));

            byte[] PreHashWNetwork = Converter.AppendBitcoinNetwork(PubKeyShaRIPE, 0);
            byte[] PublicHash = Converter.Sha256(PreHashWNetwork);
            Console.WriteLine("Public Hash:" + Converter.ByteToHex(PublicHash));

            byte[] PublicHashHash = Converter.Sha256(PublicHash);
            Console.WriteLine("Public HashHash:" + Converter.ByteToHex(PublicHashHash));

            Console.WriteLine("Checksum:" + Converter.ByteToHex(PublicHashHash).Substring(0, 4));

            byte[] Address = Converter.ConcatAddress(PreHashWNetwork, PublicHashHash);
            Console.WriteLine("Address:" + Converter.ByteToHex(Address));
            
            Console.WriteLine("Human Address:" + Converter.Base58Encode(Address));


        }
        /// <summary>
        /// пока с сегвит BC1 Bech32 не работает 
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string FromRipemd160(string hash)
        {

            byte[] PubKeyShaRIPE = Converter.HexToByte(hash);

            byte[] PreHashWNetwork = Converter.AppendBitcoinNetwork(PubKeyShaRIPE, 0);
            byte[] PublicHash = Converter.Sha256(PreHashWNetwork);
            Console.WriteLine("Public Hash:" + Converter.ByteToHex(PublicHash));

            byte[] PublicHashHash = Converter.Sha256(PublicHash);
            Console.WriteLine("Public HashHash:" + Converter.ByteToHex(PublicHashHash));

            byte[] Address = Converter.ConcatAddress(PreHashWNetwork, PublicHashHash);
            Console.WriteLine("Address:" + Converter.ByteToHex(Address));

            Console.WriteLine("Human Address:" + Converter.Base58Encode(Address));
            return Converter.Base58Encode(Address);

        }
    }

}

