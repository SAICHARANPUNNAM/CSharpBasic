//using C_SharpBasic;
//using C_SharpBasic.Concepts;
//CreateClass callingMethodFromAnotherClass = new CreateClass();
//callingMethodFromAnotherClass.getData();
//using System;     
 // This is Global scope of Main..
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpBasic.Concepts
{
    class CreateObject
    {
        public void Main()
        {
            CreateClass dataFromAnotherClass = new CreateClass();
            dataFromAnotherClass.getData();
        }
    }
}
