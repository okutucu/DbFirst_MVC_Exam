using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbFirst_MVCProject_1.Models;

namespace DbFirst_MVCProject_1.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
         DBTool() { }

        static NORTHWNDEntities _dbInstance;

        public static NORTHWNDEntities DbInstance
        {
            get 
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new NORTHWNDEntities();
                }
                return _dbInstance;
            }
        }
    }
}