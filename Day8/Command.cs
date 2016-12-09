using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Command
    {
        public Command(string command, Screen myScreen)
        {
            if (command.Contains("="))
            {
                var section = command.Substring(command.IndexOf("=") + 1);
                var ints = section.Remove(section.IndexOf("by"), 2);
                while (ints.Contains("  "))
                    ints = ints.Replace("  ", " ");
                string[] indexByAmount = ints.Split(' ');
                var index = int.Parse(indexByAmount[0]);
                var amount = int.Parse(indexByAmount[1]);

                if (command.Contains("row"))
                {
                    //Console.WriteLine("RotateRow(" + index + ", " + amount + ")");
                    myScreen.RotateRow(index, amount);
                }

                if (command.Contains("column"))
                {
                    //Console.WriteLine("RotateColumn(" + index + ", " + amount + ")");
                    myScreen.RotateColumn(index, amount);
                }
            }
            else
            {
                var size = command.Substring(command.IndexOf(' '));
                var array = size.Split('x');
                var wide = int.Parse(array[0]);
                var height = int.Parse(array[1]);
                //Console.WriteLine("Command= DrawRectangle(" + wide + ", " + height + ")");
                myScreen.DrawRectangle(wide, height);
            }
            Console.WriteLine(myScreen.PrintScreen());

        }
    }
}
