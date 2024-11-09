using System;
using System.Reflection;


namespace BitCraft.Classes
{
    public class Helper
    {
        static Random random = new Random();

        public static Version AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        internal static string GetVersion()
        {
            return String.Format("Version {0}", AssemblyVersion.ToString()) + " (" + DecodeDate(AssemblyVersion) + ")";
        }

        private static string DecodeDate(Version version)
        {
            var buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(TimeSpan.TicksPerDay * version.Revision));
      
            return buildDateTime.ToShortDateString();
        }

    }
}
