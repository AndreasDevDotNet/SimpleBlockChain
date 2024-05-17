namespace SimpleBlockChain.Model
{
    public class BlockChain
    {
        public List<Block> Chain { get; private set; }
        public int Difficulty { get; set; }

        public BlockChain(int difficulty) 
        {
            Difficulty = difficulty;
            Chain = new List<Block>();
            AddGenisisBlock();
        }

        private void AddGenisisBlock()
        {
            Chain.Add(new Block(0, DateTime.Now, "GENESIS_BLOCK", ""));
        }

        public void AddBlock(Block block)
        {
            block.MineBlock(Difficulty);
            Chain.Add(block);
        }

        public Block GetLatestBlock()
        {
            return Chain.Last();
        }

        public bool IsBlockChainValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                var currBlock = Chain[i];
                var prevBlock = Chain[i - 1];

                if(currBlock.Hash != currBlock.CalculateHash())
                    return false;

                if(currBlock.PreviousHash != prevBlock.Hash)
                    return false;
                
            }

            return true;
        }
    }
}
