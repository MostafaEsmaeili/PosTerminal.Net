namespace PosTerminal.Net.Domain.Enums;
public enum PosTransactionStatus
{
    SentToClient = 1,
    ClientReceived = 2,
    ClientShowsToCustomer = 3,
    TransactionDone = 4,
    TransactionFailed = 5,
    TransactionTimeout = 6,
    ManualTransaction = 7
}