using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Com.CodeGame.CodeWizards2016.DevKit.CSharpCgdk
{

       

    static class GeoUtils
    {


        public static double Hypot(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a,2) + Math.Pow(b,2));
        }

        public static MapPoint HalfLine(MapPoint a, MapPoint b)
        {

            return new MapPoint(0, 0, MyMap.PointType.Waypoint);
        }

    }


    class UtilsClass
    {
        public UtilsClass()
        {
            
        }

        public void Log(string log_text)
        {
            Logger log = new Logger("log.txt",true);
            log.LogToFile(log_text);
        }

        
    }

    class Logger
    {
        public Logger(string fname, bool log_on)
        {
            logging_on = log_on;
            logFileName = fname;
        }

        public void LogToFile(string log)
        {
            using (FileStream fstream = new FileStream(@logFileName, FileMode.OpenOrCreate))
            {
                log = Convert.ToString(DateTime.Now) + ">:" + log;
                byte[] array = System.Text.Encoding.Default.GetBytes(log);
                fstream.Write(array, 0, array.Length);
            }
        }

        private bool logging_on;
        private string logFileName;

        public bool IsLogging => logging_on;
        public string LogFileName => logFileName;
    }
}
