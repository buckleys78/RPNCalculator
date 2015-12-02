using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.Model {
    class XRegister {

        private Values ParentStack { get; set; }
        private double ValueInX {
            get {
                return ParentStack.TopValue();
            }
            set {
                ParentStack.UpdateTopValue(value);
            }
        }

        public string NewEntryBuffer { get; set; }

        // Constructors(s)
        public XRegister(Values parentStack) {
            ParentStack = parentStack;
            NewEntryBuffer = "";
        }

        public bool BufferHasDecimalPoint() {
            return NewEntryBuffer.Contains(".");
        }

        // Methods/Functions
        public void AddDigit(string digit) {
            char chngSignChar = (char)0x00B1; //   +/- symbol
            if (digit.Length != 1) return;
            if (char.IsDigit(digit,0) || (digit == "." && !BufferHasDecimalPoint())) {
                if (BufferIsEmpty() && !XRegisterIsPlaceholder) {
                    ParentStack.Push(0);
                }
                XRegisterIsPlaceholder = false;
                NewEntryBuffer += digit;
                ValueInX = double.Parse(NewEntryBuffer);
            } else if (digit.CompareTo(chngSignChar.ToString()) == 0) {
                ValueInX *= -1;
                if (NewEntryBuffer.Length > 0) {
                    if (ValueInX < 0) {
                        if (NewEntryBuffer.Substring(0, 1) != "-") {
                            NewEntryBuffer = "-" + NewEntryBuffer;
                        }
                    } else if (ValueInX > 0) {
                        if (NewEntryBuffer.Substring(0, 1) == "-") {
                            NewEntryBuffer = NewEntryBuffer.Substring(1);
                        }
                    }
                }
            }
        }

        public bool BufferIsEmpty() {
            return NewEntryBuffer.Length == 0;
        }

        public double BufferValue() {
            double bufferValue = 0.0;
            if (double.TryParse(NewEntryBuffer, out bufferValue)) {
                return bufferValue;
            } else {
                return 0.0;
            }
        }

        public void ClearBuffer() {
            NewEntryBuffer = "";
        }

        public void DeleteLastDigit() {
            if (NewEntryBuffer.Length > 0) {
                NewEntryBuffer = NewEntryBuffer.Substring(0, NewEntryBuffer.Length - 1);
            }
            if (NewEntryBuffer.Length > 0) {
                ValueInX = double.Parse(NewEntryBuffer);
            } else {
                ValueInX = 0.0;
            }
        }

        public bool XRegisterIsPlaceholder { get; set; }

        public void PushBufferUpTheStack() {
            ParentStack.Push(ValueInX);
            ClearBuffer();
        }
    }
}
