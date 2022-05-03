using System;
using System.Collections.Generic;
using System.Text;

namespace NicotineCalculatorApp.Models
{
    internal class NicAmount
    {
        public string NicShotMg { get; set; }
        public string BaseMl { get; set; }
        public string NicShotMl { get; set; }
        public string TargetMg { get; set; }

        public NicAmount(string NicsShotMg, string BaseMl, string NicShotMl, string TargetMg)
        {
            this.NicShotMg = NicsShotMg;
            this.BaseMl = BaseMl;
            this.NicShotMl = NicShotMl;
            this.TargetMg = TargetMg;
        }
    }
}
