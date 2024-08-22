namespace StakeOutReport_WinForms
{
    internal class MessageUser
    {
        public static void BadFileRead()
        {
            //make the message variables to pass to the message box
            string message = "File choice in invalid, please ensure the csv file is ordered:\n" +
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
        public static void BadDataPrefix()
        {
            //make the message variables to pass to the message box
            string message = "As-Built data prefix did not match the expected prefix";
            string caption = "Error detected within the provided prefix";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            //display the message box
            result = MessageBox.Show(message, caption, buttons);
        }
    }

}
