﻿namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport
    {
        private void InitialiseComboBox()
        {
            PrefixSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            PrefixSelector.TabIndex = 0;
            string[] choices = ["STKE", "Custom", "None"];
            PrefixSelector.Items.AddRange(choices);
            PrefixSelector.SelectedIndex = 0;
        }

        private void PrefixSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            AsBuiltPrefixSelection = PrefixSelector.Text; //stores the selected prefix within the string variable
            if (PrefixSelector.Text == "None")
            {
                AsBuiltPrefixSelection = string.Empty;
            }
            //spawn text box to enter custom selection
            CustomPrefixTextBox.Visible = AsBuiltPrefixSelection == "Custom" ? true : false;
        }

        private void CustomPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            //Here, we assign the custom prefix to the string variable
            AsBuiltPrefixSelection = CustomPrefixTextBox.Text;
        }

        private bool ConfirmPrefix() //need to decide where this is called from
        //need a bool to set depending on whether the prefix matches the as built data
        {
            try
            {
                return AsBuiltData[0].PointID.Contains(AsBuiltPrefixSelection);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
