using System;
using System.IO;
using System.Windows.Forms;

namespace RestaurantChapeau
{
    class ErrorLogger
    {
        private static ErrorLogger instance;
        public static ErrorLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ErrorLogger();
                }

                return instance;
            }
        }

        const string LogFileName = "Logs.txt";

        private ErrorLogger() { }

        /// <summary>
        /// Writes a new error to the lgo file and shows an error message (if displayError is set to true).
        /// </summary>
        /// <param name="ex">Exception to pass on.</param>
        /// <param name="displayError">If set to false, message box won't appear.</param>
        public void WriteError(Exception ex, bool displayError = true)
        {
            string error = $"({DateTime.Now:yyyy-MM-dd HH:mm:ss}) {ex.Message}\n    {ex.StackTrace}\n";
            StreamWriter sw = new StreamWriter(LogFileName, true);
            sw.WriteLine(error);
            sw.Close();
            sw.Dispose();

            if (displayError)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
