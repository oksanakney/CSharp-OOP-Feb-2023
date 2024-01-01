using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int oxygenLevel = 540;
        private const double decreaseOxyIndex = 0.3;
        public ScubaDiver(string name) : base(name, oxygenLevel)
        {
        }

        public override void Miss(int timeToCatch)
        {
            base.OxygenLevel = (int)Math.Round(timeToCatch * decreaseOxyIndex);
        }

        public override void RenewOxy()
        {
           base.OxygenLevel = oxygenLevel;
        }
    }
}
