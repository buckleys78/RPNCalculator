using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.Model {
    class Stack {
        private Stack<double> valuesStack;

        public Stack() {
            valuesStack = new Stack<double>();
        }

        public int NumberOfValues() {
            return valuesStack.Count;
        }

        public double XValue() {
            return valuesStack.Peek();
        }
    }
}
