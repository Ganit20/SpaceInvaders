using SpaceInvaders.View;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SpaceInvaders
{
    internal class PlayerMove
    {
        Point CurrentPlayerPosition;
        FirstLevel gameWindow;
        public PlayerMove(FirstLevel _gameWindow)
        {
            gameWindow = _gameWindow;
            CurrentPlayerPosition = gameWindow.PlayerObject.TranslatePoint(new Point(0, 0), gameWindow.Field);
        }

        internal void MoveRight()
        {
            if (CurrentPlayerPosition.Y > 0)
                    Canvas.SetLeft(gameWindow.PlayerObject, CurrentPlayerPosition.X + 10);
                
        }

        internal void MoveLeft()
        {
            if (CurrentPlayerPosition.Y > 0)    
                Canvas.SetLeft(gameWindow.PlayerObject, CurrentPlayerPosition.X - 10);
        }
        
    }
}