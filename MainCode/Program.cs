using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Container;

namespace MainCode
{
    class Program
    {
        static void Main(string[] args)
        {
            DIC dc = new DIC();
            //Workable
            //dc.Register<ISomeInterface, SomeClassReaization>();//A1,R1:A1
            //dc.Register<MyAbstractClass, UsefullClass>();//A2,R2:A2
            //Console.WriteLine(dc.Resolve<ISomeInterface>().IsDoingNothingMethod());//true
            //Console.WriteLine(dc.Resolve<MyAbstractClass>().UselessMethod());//false

            //UnWorkable
            dc.Register<ISomeInterface, UsefullClass>();//A1, R2:A2-exception
            dc.Register<MyAbstractClass,SomeClassReaization>();// R1:A1, A2-exception
            //Console.WriteLine(dc.Resolve<ISomeInterface>().IsDoingNothingMethod());//true
            Console.WriteLine(dc.Resolve<MyAbstractClass>().UselessMethod());//false


        }
    }
    public interface ISomeInterface
    {
        bool IsDoingNothingMethod();
    }
    public class SomeClassReaization : ISomeInterface
    {
        public bool IsDoingNothingMethod()
        {
            return true;
        }
    }

    public abstract class MyAbstractClass
    {
        public abstract bool UselessMethod();
    }

    public class UsefullClass : MyAbstractClass
    {
        public override bool UselessMethod()
        {
            return false;
        }
    }
}
