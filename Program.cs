using System;
using System.Windows.Forms;
using Serilog;

namespace avaliacao_tecnica_visualsoft
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                                .CreateLogger();
            try
            {
                Log.Information("Iniciando a aplicação");
                Application.Run(new Home());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "A aplicação falhou ao iniciar");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
