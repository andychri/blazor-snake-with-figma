namespace BlazorSnake.Components;
using System;
using System.Collections.Generic;

/// <summary>Snake entity: ordered body of cell indices (head→tail) and current direction.</summary>
/// <remarks>Constructed already spawned (length = 1). Indices are flattened grid coordinates.</remarks>
public class Snake
{
    private readonly LinkedList<int> _snakeBody = [];
    public Direction Direction {get; private set;}
    
    // _snakeBody is never null after construction
    public int SnakeHead => _snakeBody.First!.Value;
    public int SnakeTail => _snakeBody.Last!.Value;
    public int SnakeLength => _snakeBody.Count;

    /// <summary>Create a length-1 snake at <paramref name="headIndex"/> facing <paramref name="initialDirection"/>.</summary>
    public Snake(int headIndex, Direction initialDirection)
    {
        _snakeBody.AddFirst(headIndex);
        Direction = initialDirection;
    }

    /// <summary>
    /// Gets the opposite of the given direction
    /// </summary>
    /// <param name="direction">The current direction</param>
    /// <returns>The opposite direction</returns>
    private static Direction Opposite(Direction direction)
        => direction switch
        {
            Direction.Up    => Direction.Down,
            Direction.Down  => Direction.Up,
            Direction.Left  => Direction.Right,
            Direction.Right => Direction.Left,
            _               => direction

        };

    /// <summary>
    /// Returns <see langword="true"/> if the new direction isn't a 180° reversal
    /// of the current direction (unless the snake length is 1).
    /// </summary>
    /// <param name="newDirection">Requested next direction</param>
    /// <returns><see langword="true"/> if the turn is allowed; otherwise <see langword="false"/>.</returns>
    private bool CanTurn(Direction newDirection)
    {
        return SnakeLength == 1 || newDirection == Direction || newDirection != Opposite(Direction);
    }
    
    /// <summary>
    /// Changes direction if the turn is legal; Otherwise does nothing.
    /// </summary>
    /// <param name="newDirection">Requested next direction</param>
    public void Turn(Direction newDirection)
    {
        if (CanTurn(newDirection))
            Direction = newDirection;
    }

    /// <summary>
    /// Adds the next head at <paramref name="nextIndex"/> and removes the tail.
    /// </summary>
    /// <param name="nextIndex"></param>
    /// <param name="grow">If <see langword="true"/>, keep the tail this tick (snake grows).</param>
    /// <returns>Returns the removed tail index, representing its position on the board,
    /// or <see langword="null"/> when growing.
    /// </returns>
    public int? Advance(int nextIndex, bool grow)
    {
        _snakeBody.AddFirst(nextIndex);
        if (grow) return null;
        var tail = _snakeBody.Last!.Value;
        _snakeBody.RemoveLast();
        return tail;
    }
}