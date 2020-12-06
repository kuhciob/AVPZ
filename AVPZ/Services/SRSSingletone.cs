using AVPZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVPZ.Services
{
    public class SRSSingletone
    {
        private static SRSSingletone instance;
        public SRS SRS = new SRS();
        private SRSSingletone()
        {
            
        }
        public static SRSSingletone getInstance()
        {
            if (instance == null)
            {
                instance = new SRSSingletone();
            }
            return instance;
        }
    }
}
