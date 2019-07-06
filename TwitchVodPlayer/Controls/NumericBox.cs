using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TwitchVodPlayer.Controls {
    public enum NumericBoxType {
        Hours,
        Minutes,
        Seconds
    }
    public class NumericBox : TextBox {
        private NumericBoxType numericBoxType;
        [Description("Numeric Box Type"), Category("Behavior")]
        public NumericBoxType NumericBoxType {
            get {
                return numericBoxType;
            }
            set {
                numericBoxType = value;
            }
        }

    string previousText;

        public NumericBox() {
            previousText = Text;
        }

        public int Value {
            get {
                return int.Parse(Text);
            }
        }

        protected override void OnTextChanged(EventArgs e) {
            int value;
            bool isNumeric = Int32.TryParse(Text, out value);
            if (isNumeric) {
                /*
                ((numericBoxType == NumericBoxType.Hours && value <= VodSetCreatorForm.Instance.MaxHours) ||
                (numericBoxType == NumericBoxType.Minutes && value <= VodSetCreatorForm.Instance.MaxMinutes) ||
                (numericBoxType == NumericBoxType.Seconds && value <= VodSetCreatorForm.Instance.MaxSeconds))) {
                */

                Text = value.ToString("00");
                Text = Text.Substring(0, 2);
                base.OnTextChanged(e);
                previousText = Text;

            } else {
                Text = previousText;
            }
            SelectionStart = Text.Length;
            SelectionLength = 0;
        }
    }
}
