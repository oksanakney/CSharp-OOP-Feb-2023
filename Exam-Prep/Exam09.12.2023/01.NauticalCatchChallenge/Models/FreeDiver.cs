using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int oxygenLevel = 120;
        private const double decreaseOxyIndex = 0.6;
        public FreeDiver(string name) : base(name, oxygenLevel)
        {
        }

        public override void Miss(int timeToCatch)
        {
            int usedOxy = (int)Math.Round(timeToCatch * decreaseOxyIndex);
            base.OxygenLevel -= usedOxy;
        }

        public override void RenewOxy()
        {
            base.OxygenLevel = oxygenLevel;//???

        }
    }
}
