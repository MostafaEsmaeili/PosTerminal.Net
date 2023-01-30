namespace PosTerminal.Net.Application.Contracts.Persistence;

public interface IUnitOfWork
{
    //public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
    public IPosRepository OrderRepository { get; }
    Task CommitAsync();
    ValueTask RollBackAsync();
}