using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        public Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            this.@catch = new List<string>();
            competitionPoints = 0;
            hasHealthIssues = false;            
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set 
            { 
                if(String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                name = value; 
            }
        }

        private int oxygenLevel;

        public int OxygenLevel
        {
            get { return oxygenLevel; }
            protected set 
            { 
                value = Math.Max(0, value);
                oxygenLevel = value; 
            }
        }

        private List<string> @catch;
        public IReadOnlyCollection<string> Catch => @catch.AsReadOnly();

        private double competitionPoints;

        public double CompetitionPoints => Math.Round(competitionPoints, 1);


        private bool hasHealthIssues;
        public bool HasHealthIssues => hasHealthIssues;

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            @catch.Add(fish.Name);
            competitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);


        public abstract void RenewOxy();


        public void UpdateHealthStatus() 
        {
            hasHealthIssues = !hasHealthIssues;
        }
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]");
            return sb.ToString().TrimEnd();
        }
    }
}
