using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Game
    {   // Member Variables (HAS A)
        private Player player;
        private List<Day> days;
        private int currentDay;
        //Constructor
        public Game()
        {
            
        }
        //Member Methods (CAN DO)





        public void RunGame()
        {
            Player play = new Player("Player");
            UserInterface.DisplayIntroMessage();
            
            

        }


    }
}
