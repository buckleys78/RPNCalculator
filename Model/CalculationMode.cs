using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.Model {
    public enum CalcMode {
        Unknown,
        RPN,
        TI
    };

    class CalculationMode {
        
        public CalcMode CurrentMode { get; set; }

        public CalculationMode (CalcMode modeOnStartup) {
            CurrentMode = modeOnStartup;
        }
    }
}
