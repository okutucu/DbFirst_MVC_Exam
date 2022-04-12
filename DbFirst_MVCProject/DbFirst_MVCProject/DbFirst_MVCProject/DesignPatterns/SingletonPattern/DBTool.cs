using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbFirst_MVCProject.Models;

namespace DbFirst_MVCProject.DesignPatterns.SingletonPattern
{
    public class DBTool
    {

        //DbTool constructor'ını private tanımlamımızın sebebi;
        // DbTool classımızın dışardan ulaşılmasını istemiyoruz.
        // Abstract tanımlayamazdık cunku abstract sınıfların ram'de anlamsız veri modelli oluşturmamak için SADECE miras verme görevini ustlenir.
        // Static yapmamızızın sebebi ise, bir classa static keywordu verdiğimizde classın bütün üyeleri static olmak zorunda ve instance alamayacağızdan classın içindeki üyelere de ulaşamazdık.
        // Abstract ve static yapamadığımızdan constructor'a dışardan erişimi kapatmak için private yaptık.
        DBTool() { }

        // Ram'de kalıcı bir yer oluşturması için _dbInstance değişkenini static tanımladık.
        static NORTHWNDEntities _dbInstance;

        //  database işlemi yapmak için NORTHWNDEntities classımıza ulaşmamız gerekir.
        // Her database işlemi için sürekli instance oluşturmak yerine method içinde  _dbInstance oluşuturuluo oluşturulmadığını kontrol ettirdik ve böylelikle 1 kere database instancesi oluşturduk.
        
        public static NORTHWNDEntities DBInstance
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