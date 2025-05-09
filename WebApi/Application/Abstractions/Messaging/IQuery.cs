namespace WebApi.Application.Abstractions.Messaging;

/// <summary>
/// Represents a query that returns a response of type <typeparamref name="TResponse"/>.
/// Queries are used to retrieve data or perform read-only operations without modifying the state of the system.
/// </summary>
/// <typeparam name="TResponse">The type of the response returned by the query.</typeparam>
public interface IQuery<TResponse>;
