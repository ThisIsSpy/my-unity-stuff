using PlayerMover;
using UnityEngine;

namespace CommandSystem.Commands
{
    public class PlayerMoverCommand : ICommand
    {
        private readonly PlayerMover.PlayerMover playerMover;

        public Vector3 Position { get; private set; }

        public PlayerMoverCommand(PlayerMover.PlayerMover playerMover, Vector3 position)
        {
            this.playerMover = playerMover;
            Position = position;
        }

        public void Invoke(Vector2 position)
        {
            playerMover.MovePlayer(position);
        }

        public void Invoke()
        {
            playerMover.MovePlayer(Position);
        }

        public void Undo()
        {
            playerMover.UnmovePlayer();
        }
    }
    
}
