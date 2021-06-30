using System;
using Microsoft.Extensions.DependencyInjection;
using repository_unitofwork.Abstractions;

namespace CEP.BLL.BaseDbService
{
    public abstract class BaseDbServices : IDisposable
    {
        private IServiceProvider _serviceProvider;

        protected internal BaseDbServices(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        protected virtual TResult InvokeInUnitOfWorkScope<TResult>(Func<IUnitOfWork, TResult> func)
        {
            using (var unitOfWork = this._serviceProvider.GetRequiredService<IUnitOfWork>())
            {
                var result = func.Invoke(unitOfWork);

                return result;
            }
        }

        protected virtual void InvokeInUnitOfWorkScope(Action<IUnitOfWork> action)
        {
            using (var unitOfWork = this._serviceProvider.GetRequiredService<IUnitOfWork>())
            {
                action.Invoke(unitOfWork);
            }
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposedValue)
            {
                return;
            }

            if (disposing)
            {
                this._serviceProvider = null;
                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        #endregion IDisposable Support
    }
}
