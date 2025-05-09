namespace WebApi.Application.Abstractions.Messaging;

/// <summary>
/// Defines a handler for processing queries of a specific type and returning a response.
/// </summary>
/// <typeparam name="TQuery">The type of the query being handled. Must implement <see cref="IQuery{TResponse}"/>.</typeparam>
/// <typeparam name="TResponse">The type of the response returned by the query handler.</typeparam>
public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    /// <summary>
    /// Handles the specified query and returns a response asynchronously.
    /// </summary>
    /// <param name="query">The query to handle.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response.</returns>
    Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}