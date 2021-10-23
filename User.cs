using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_User_GC
{
    public class User:IDisposable
    {

        public string FirstName { get; set; }   //имя
        public string LastName { get; set; }    //фамилия
        public string MiddlName { get; set; }   //отчество
        int adg { get; set; }                   //возраст

        public User(){}

        public User(string FirstName, string LastName, string MiddlName, int adg)

        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddlName = MiddlName;
            this.adg = adg;
        }
        public override string ToString()
        {
            return String.Format(" FirstName: {0}\n LastName: {1}\n MiddlName: {2}\n adg: {3} ",
                                 this.FirstName, this.LastName, this.MiddlName, this.adg);
        }
       
       
        public void Dispose()
        {
            GC.Collect(GC.GetGeneration(this));
        }
    }
}
