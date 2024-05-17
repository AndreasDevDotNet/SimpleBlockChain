using SimpleBlockChain.Model;
using System.Text.Json;

var transactions = new List<Transaction>
{
    new Transaction
    {
        AccountId = Guid.NewGuid(),
        Id = Guid.NewGuid(),
        TransactionDate = DateTime.Now,
        TransactionAmount = 8967234M,
        TransactionMemo = "Deposit from Coinbase"
    },
    new Transaction
    {
        AccountId = Guid.NewGuid(),
        Id = Guid.NewGuid(),
        TransactionDate = DateTime.Now,
        TransactionAmount = 8934M,
        TransactionMemo = "Deposit from Coinbase"
    },
    new Transaction
    {
        AccountId = Guid.NewGuid(),
        Id = Guid.NewGuid(),
        TransactionDate = DateTime.Now,
        TransactionAmount = 28967234M,
        TransactionMemo = "Deposit from Coinbase"
    },
    new Transaction
    {
        AccountId = Guid.NewGuid(),
        Id = Guid.NewGuid(),
        TransactionDate = DateTime.Now,
        TransactionAmount = 38967234M,
        TransactionMemo = "Deposit from Coinbase"
    },
};

var blockChain = new BlockChain(2);

foreach (var transaction in transactions)
{
    var data = JsonSerializer.Serialize(transaction);

    Console.WriteLine($"Adding block: {data}");

    var newBlock = new Block(blockChain.GetLatestBlock().Index + 1, DateTime.Now, data, blockChain.GetLatestBlock().Hash);
    blockChain.AddBlock(newBlock);
}

Console.WriteLine($"Checking blockchain validity : {blockChain.IsBlockChainValid()}");
var options = new JsonSerializerOptions { WriteIndented = true };
Console.WriteLine($"BlockChain: {JsonSerializer.Serialize(blockChain, options)}");
