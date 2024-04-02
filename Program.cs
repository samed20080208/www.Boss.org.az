using System.Text;
using www.Boss.org.az.Models.Menu;

class Program
{
    static void Main(string[] args)
    {
        try
        {

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            ProgramMenegment.Start();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}