using PosTerminal.Net.Domain.Entities.Identities;
namespace PosTerminal.Net.Domain.Entities;
public class PosTransaction : BaseEntity<Guid>
{
    private PosTransaction()
    {

    }
    public PosTransaction(string uniqueId, int posId)
    {
        UniqueId = uniqueId;
        PosId = posId;
        TransactionDate = DateTime.Now;
    }

    public void SetTransactionDetail(
        string? trackingNumber,
        string? referenceNumber,
        string? cardNumber,
        string? persianDate,
        string? terminalInfo)
    {
        TrackingNumber = trackingNumber;
        ReferenceNumber = referenceNumber;
        CardNumber = cardNumber;
        PersianDate = persianDate;
        TerminalInfo = terminalInfo;
    }

    public DateTime TransactionDate { get; private set; }
    public required string UniqueId { get; init; }
    public int PosId { get; private set; }
    public void ChangeStatus(PosTransactionStatus status)
    {
        Status = status;
        TransactionDate = DateTime.Now;
    }
    public PosTransactionStatus Status { get; private set; }
    public bool HasError { get; private set; }
    public string? ErrorMessage { get; private set; }
    public void SetErrorMessage(string errorMessage)
    {
        ErrorMessage = errorMessage;
        HasError = true;
    }
    public bool IsPending()
    {
        var completeStatus = new[]
         {
          PosTransactionStatus.TransactionDone,
          PosTransactionStatus.TransactionFailed,
          PosTransactionStatus.TransactionTimeout
       };
        return !completeStatus.Contains(Status);
    }
    public string? TrackingNumber { get; private set; }
    public string? ReferenceNumber { get; private set; }
    public string? CardNumber { get; private set; }
    public string? PersianDate { get; private set; }
    public string? TerminalInfo { get; private set; }
    public Pos Pos { get; set; } = null!;
}