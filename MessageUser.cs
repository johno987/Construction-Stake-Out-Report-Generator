namespace StakeOutReport_WinForms
{
    internal class MessageUser
    {
        public static void BadFileRead()
        {
            //make the message variables to pass to the message box
            string message = "File choice in invalid. Ensure the csv file is ordered:\n" +
                    "PointID\n" +
                    "Easting\n" +
                    "Northing\n" +
                    "Elevation";
            string caption = "Error detected in the file selection";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            //display the message box
            result = MessageBox.Show(message, caption, buttons);
        }
        public static void BadDataPrefix() //need to append the specified prefix to the end of the 
            //warning message box that appears
        {
            //make the message variables to pass to the message box
            string message = "As-Built data prefix did not match the expected prefix";
            string caption = "Error detected within the provided prefix";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            //display the message box
            result = MessageBox.Show(message, caption, buttons);
        }
        public static void EmptyAsBuiltDataWarning()
        {
            //make the message variables to pass to the message box
            string message = "As-Built data cannot be empty";
            string caption = "Empty As-Built data collection";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            //display the message box
            result = MessageBox.Show(message, caption, buttons);
        }
        public static void EmptyReportSelection()
        {
            //make the message variables to pass to the message box
            string message = "No report format has been selected";
            string caption = "Null report selection";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            //display the message box
            result = MessageBox.Show(message, caption, buttons);
        }
    }

}
