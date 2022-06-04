using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public class StepCount
    {
        public int stepCount { get; private set; }

        public StepCount(int stepCount)
        {
            this.stepCount = stepCount;
        }

        public void StepCountDown()
        {
            stepCount--;
        }
    }
}
