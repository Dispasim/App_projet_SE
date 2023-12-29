using System.Media;

namespace App_projet_SE
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainPage());


        }

        public class MyModel
        {
            public string titre { get; set; }
            public int id { get; set; }
            public string album { get; set; }
            public string duree { get; set; }
            
        }

        public class IdModel
        {
            public int id { get; set; }
        }
    }
}