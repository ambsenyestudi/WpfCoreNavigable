using System;

namespace TicTacToe.Application.DTO
{
    public class GameSnapshotDTO
    {
        public Guid Id { get; set; }
        public string BoardSnapshot { get; set; }
    }
}
