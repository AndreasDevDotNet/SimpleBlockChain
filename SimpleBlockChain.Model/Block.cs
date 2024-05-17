using System.Security.Cryptography;
using System.Text;

namespace SimpleBlockChain.Model
{
    public class Block 
    {
        public int Index { get; private set; }
        public string Data {  get; private set; }

        public string Hash { get; private set; }
        public string PreviousHash { get; private set; }
        public int Nonce { get; private set; }
        public DateTime TimeStamp  { get; private set; }

        public Block(int index, DateTime timeStamp, string data, string previousHash )
        {
            Index = index;
            TimeStamp = timeStamp;
            Data = data;
            PreviousHash = previousHash;
            Hash = CalculateHash(); 
        }

        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();
            var input = Encoding.ASCII.GetBytes($"{Index}-{TimeStamp}-{Data}-{PreviousHash}-{Nonce}");
            var output =  sha256.ComputeHash(input);

            return Convert.ToBase64String(output);
        }

        public void MineBlock(int difficulty)
        {
            string leadingZeroes = new string('0', difficulty);

            while(Hash.Substring(0,difficulty) != leadingZeroes) 
            {
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }
}
