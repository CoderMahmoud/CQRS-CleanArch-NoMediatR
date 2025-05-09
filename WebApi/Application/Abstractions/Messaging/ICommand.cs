namespace WebApi.Application.Abstractions.Messaging;

/// <summary>
/// Represents a command that does not return a response.
/// Commands are used to encapsulate a request to perform an action.
/// </summary>
public interface ICommand : IBaseCommand;

/// <summary>
/// Represents a command that returns a response of type <typeparamref name="TResponse"/>.
/// Commands are used to encapsulate a request to perform an action and return a result.
/// </summary>
/// <typeparam name="TResponse">The type of the response returned by the command.</typeparam>
public interface ICommand<TResponse> : IBaseCommand;

/// <summary>
/// Marker interface for all command types.
/// This interface is used as a base for defining commands in the application.
/// </summary>
public interface IBaseCommand;