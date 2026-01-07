using System;

namespace FileHandling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConcatCompareString cc=new ConcatCompareString();
            cc.Call(10000);

            //for readlinebyline
            // ReadLineByLine rlb=new ReadLineByLine();
            // rlb.Call();
            // rlb.Call2();
            //

        //for StringManipulation
        // StringManipulation sm=new StringManipulation();
        // sm.Call();

            // --- File Handling Problems ---
            // ByteToCharStream.Run();
            // UserInputToFile.Run();

            

            Console.ReadKey();
        }
    }
}
