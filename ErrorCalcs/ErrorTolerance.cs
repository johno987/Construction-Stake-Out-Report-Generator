namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport
    {
        private void DefineErrorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ToleranceTextBox.Visible = !ToleranceTextBox.Visible;
            ToleranceTextBox.Text = null;

            //set actual value back to null?
            DefinedErrorTolerance = null;
        }

        private void ToleranceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isValid(e.KeyChar))
            {
                e.Handled = true; //wont allow us to enter non integers 
            }
        }


        private void ToleranceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ToleranceTextBox.Text))
                DefinedErrorTolerance = decimal.Parse(ToleranceTextBox.Text) / 1000;
        }

        private bool isValid(char keyChar)
        {
            return char.IsControl(keyChar) || (char.IsDigit(keyChar));
        }
    }
}