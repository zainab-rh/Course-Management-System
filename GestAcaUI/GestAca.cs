using GestAca.Persistence;
using GestAca.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestAcaUI {
    internal static class GestAca {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            IGestAcaService service = new GestAcaService(
                new EntityFrameworkDAL(
                    new GestAcaDbContext()
                 ));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GestAcaApp(service));
        }
    }
}
