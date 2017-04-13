using System;
using System.Linq;
using System.Reflection;
using DbUp;

namespace Realty.Sql
{
   class Program
   {
      static void Main(string[] args)
      {
         var connectionString = args.FirstOrDefault()
            ?? "Server=(local); Database=realty; Integrated Security=SSPI";

         var upgrader = DeployChanges.To.SqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

         var result = upgrader.PerformUpgrade();

         if(!result.Successful)
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            Console.ResetColor();
            return;
         }

         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine("Success!");
         Console.ResetColor();
      }
   }
}
