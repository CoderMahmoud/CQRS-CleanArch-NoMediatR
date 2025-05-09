namespace WebApi.Application.Abstractions.Messaging;

/// <summary>
/// Defines a handler for processing commands that do not return a response.
/// </summary>
/// <typeparam name="TCommand">The type of the command to handle. Must implement <see cref="ICommand"/>.</typeparam>
public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    /// <summary>
    /// Handles the given command asynchronously.
    /// </summary>
    /// <param name="command">The command to handle.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Handle(TCommand command, CancellationToken cancellationToken);
}

/// <summary>
/// Defines a handler for processing commands that return a response.
/// </summary>
/// <typeparam name="TCommand">The type of the command to handle. Must implement <see cref="ICommand{TResponse}"/>.</typeparam>
/// <typeparam name="TResponse">The type of the response returned by the command.</typeparam>
public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    /// <summary>
    /// Handles the given command asynchronously and returns a response.
    /// </summary>
    /// <param name="command">The command to handle.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the response.</returns>
    Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
}