using System;

namespace Connectfour
{
    public class Player
    {
        public string _name;
        private char _icon;
        private int _score;

        public Player()
        {
            this._name = string.Empty;
            this._score = 0;
        }

        public void initiasePlayer(char[] expectedIcons)
        {
            this._name = Util.getStringInput("Enter Player name: ", Settings.MIN_NAME_LENGTH, Settings.MAX_NAME_LENGTH);
            this._icon = Util.getCharInput("Enter Choose Icon: ", expectedIcons);
        }

        public void setScore()
        { 
            this._score++; 
        }

        public int getScore()
        {
            return this._score;
        }

        public char getIcon()
        {
            return this._icon;
        }
    }
}