using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           Application.Run(new Dashbord());
           //Application.Run(new Dashbord());


            //Application.Run(new Master_IPD_Sergical_Procedure());
            //Application.Run(new Employeeregistration());
            //Application.Run(new OPD_Consultaion_mainform());
            // Application.Run(new Master_Procedures());
        }
    }
}
