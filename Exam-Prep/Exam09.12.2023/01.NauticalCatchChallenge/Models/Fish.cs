using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        public Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;                
        }
        private string name;
        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            { 
                if(String.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }
                name = value; 
            }
        }

        private double points;

        public double Points
        {
            get 
            { 
                return points; 
            }
            set 
            { 
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.PointsNotInRange);
                }
                points = value; 
            }
        }

        public int timeToCatch;

        public int TimeToCatch
        {
            get { return timeToCatch; }
            set { timeToCatch = value; }
        }

        //check gettype
        public override string ToString() 
        { 
            StringBuilder sb = new StringBuilder();
            sb.Append($"{GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]");
            return sb.ToString().TrimEnd();        
        }

    }
}
