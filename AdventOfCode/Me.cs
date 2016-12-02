using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Me
    {
        public int X { get; set; }
        public int Y { get; set; }

        public List<Coords> everyCoordTouched { get; set; }

        public int Facing { get; set; }

        public Me()
        {
            X = 0;
            Y = 0;
            Facing = 0;
            everyCoordTouched = new List<Coords>() {new Coords(0, 0)};
        }

        public void Move(Move move)
        {
            DetermineCoordinates(move);
            

        }

        public int DetermineDirection(Move move)
        {
            if(move.Turn != 'L' && move.Turn!='R')
                throw new InvalidOperationException("Turn wasn't right or left");
            if (move.Turn == 'L')
            {
                if (Facing == 0)//north
                    return 270;
                if (Facing == 90) //east
                    return 0;
                if (Facing == 180) //south
                    return 90;
                if (Facing == 270)
                    return 180;
            }
            if (Facing == 0)//north
                return 90;
            if (Facing == 90) //east
                return 180;
            if (Facing == 180) //south
                return 270;
            return 0; //facing = 270 or west
        }

        public override string ToString()
        {
            return String.Format("Current Location x:{0} y:{1} I'm facing {2}", X, Y, Facing);
        }

        public void DetermineCoordinates(Move move)
        {
            var direction = DetermineDirection(move);
            if (direction == 0)//North, increment y
            {
                for (int i = 0; i < move.Length; i++)
                {
                    if (BeenHereBefore(new Coords(X, Y + i)))
                    {
                        Console.WriteLine("THIS IS THE PLACE: " + X + ", " + (Y+i));
                        Console.ReadKey();
                    }
                    everyCoordTouched.Add(new Coords(X, Y + i));
                }
                Y += move.Length;
                Facing = direction;
                return;
            }
            if (direction == 90) //west, increment x
            {
                for (int i = 0; i < move.Length; i++)
                {
                    if (BeenHereBefore(new Coords(X+i, Y)))
                    {
                        Console.WriteLine("THIS IS THE PLACE: " + (X+i) + ", " + (Y));
                        Console.ReadKey();
                    }
                    everyCoordTouched.Add(new Coords(X+i, Y));
                }
                X += move.Length;
                Facing = direction;
                return;
            }
            if (direction == 180) //south decrement y
            {
                for (int i = 0; i < move.Length; i++)
                {
                    if (BeenHereBefore(new Coords(X, Y-i)))
                    {
                        Console.WriteLine("THIS IS THE PLACE: " + (X) + ", " + (Y-i));
                        Console.ReadKey();
                    }
                    everyCoordTouched.Add(new Coords(X , Y-i));
                }
                Y -= move.Length;
                Facing = direction;
                return;
            }
            if (direction == 270) // west decrement x
            {
                for (int i = 0; i < move.Length; i++)
                {
                    if (BeenHereBefore(new Coords(X - i, Y)))
                    {
                        Console.WriteLine("THIS IS THE PLACE: " + (X - i) + ", " + (Y));
                        Console.ReadKey();
                    }
                    everyCoordTouched.Add(new Coords(X - i, Y));
                }
                X -= move.Length;
                Facing = direction;
                return;
            }
        }

        private bool BeenHereBefore(Coords c)
        {
            foreach (var d in everyCoordTouched)
            {
                if (d.X == c.X && d.Y == c.Y)
                    return true;
            }
            return false;
        }
    }

    public class Move
    {
        public char Turn { get; set; }

        public int Length { get; set; }

        public Move(string move)
        {
            Turn = move[0];
            Length = int.Parse(move.Substring(1, move.Length - 1));
        }

    }

    public class Coords
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coords(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType()) return false;

            Coords c = (Coords)obj;
            return (this.X == c.X) && (this.Y == c.Y);
        }


        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }

        public override string ToString()
        {
            return "x: " + X + "\ty: " + Y;
        }
    }
}
