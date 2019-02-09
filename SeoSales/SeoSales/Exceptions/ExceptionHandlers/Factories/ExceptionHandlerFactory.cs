using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchResultsAnalysis.Exceptions.ExceptionHandlers.Factories
{
    public interface IExceptionHandlerFactory
    {
        IExceptionHandler Create(Exception exception);
    }

    public class ExceptionHandlerFactory : IExceptionHandlerFactory
    {
        private readonly IEnumerable<IExceptionHandler> _exceptionHandlers;

        public ExceptionHandlerFactory(IEnumerable<IExceptionHandler> exceptionHandlers)
        {
            _exceptionHandlers = exceptionHandlers;
        }

        public IExceptionHandler Create(Exception exception)
        {
            var handler = _exceptionHandlers.SingleOrDefault(p => p.HandledType == exception?.GetType());

            if(handler == null)
            {
                return new DefaultExceptionHandler();
            }

            return handler;
        }
    }
}
