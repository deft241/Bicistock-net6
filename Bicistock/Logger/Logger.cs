using System;
using System.IO;

namespace Logger
{
    public class Logger
    {
        public string ruta = Environment.CurrentDirectory + "\\wwwroot\\log.log";

        public void Info(string texto)
        {
            string hora = "[" + Convert.ToString(DateTime.Now) + "] ";
            string textoLog = "(Info) "+ hora + texto;

            Escribir(textoLog);
        }


        public void Alerta(string texto)
        {
            string hora = "[" + Convert.ToString(DateTime.Now) + "] ";
            string textoLog = "(ALERTA) " + hora + texto;

            Escribir(textoLog);
        }


        public void Error(string texto)
        {
            string hora = "[" + Convert.ToString(DateTime.Now) + "] ";
            string textoLog = "(ERROR!!) " + hora + texto;

            Escribir(textoLog);
        }

        private void Escribir(string escribirTexto)
        {
            string textoArch;

            if (!File.Exists(ruta))
            {
                File.Create(ruta).Close();
            }

            using (StreamReader readtext = new StreamReader(ruta))
            {
                textoArch = readtext.ReadToEnd();
            }

            using (StreamWriter escribirLog = new StreamWriter(ruta))
            {
                escribirLog.Write(textoArch + "\n" + escribirTexto);            }
        }
    }
}
