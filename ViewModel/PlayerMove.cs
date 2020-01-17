using SpaceInvaders.View;
using System.Windows;
using System.Windows.Controls;

namespace SpaceInvaders
{
    internal class PlayerMove
    {
        private Point CurrentPlayerPosition;
        private readonly FirstLevel gameWindow;
        public PlayerMove(FirstLevel _gameWindow)
        {
            gameWindow = _gameWindow;
            CurrentPlayerPosition = gameWindow.PlayerObject.TranslatePoint(new Point(0, 0), gameWindow.Field);
        }

        internal void MoveRight()
        {
            if (CurrentPlayerPosition.X < gameWindow.ActualWidth- gameWindow.PlayerObject.ActualWidth)
            {
                Canvas.SetLeft(gameWindow.PlayerObject, CurrentPlayerPosition.X + 10);
            }
        }

        internal void MoveLeft()
        {
            if (CurrentPlayerPosition.X > 0)
            {
                Canvas.SetLeft(gameWindow.PlayerObject, CurrentPlayerPosition.X - 10);
            }
        }

    }
}