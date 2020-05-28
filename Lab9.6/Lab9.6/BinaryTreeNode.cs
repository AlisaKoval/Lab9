using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab9._6
{
     public struct Game
    {
        public int leftTeamScore, rightTeamScore;
        public string leftTeam, rightTeam;
        public string toString ()
        {
            return (leftTeam + " - " + rightTeam + ": " + leftTeamScore + " - " + rightTeamScore);
        }
    }
    public class BinaryTreeNode
    {
        public Game data;
        public BinaryTreeNode left = null;
        public BinaryTreeNode right = null;
    }
}
