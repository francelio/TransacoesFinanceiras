﻿
namespace MAGVA.Back.TransacoesFinanceiras.Domain.SendWork
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
