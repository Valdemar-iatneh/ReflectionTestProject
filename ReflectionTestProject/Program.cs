using System;
using System.Reflection;

namespace ReflectionTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string dllName = "C:/Users/vladi/Source/Repos/MangaOYomu/MangaOYomuConsole/bin/Debug/netcoreapp3.1/MangaOYomu.dll";
            Assembly asm = Assembly.LoadFile(dllName);

            Type type = asm.GetType("MangaOYomu.DataAccess", true, true);

            Console.WriteLine($"Type: {type.AssemblyQualifiedName}");


            Console.WriteLine();
            Console.WriteLine($"Members: ");
            foreach (MemberInfo memberInfo in type.GetMembers())
            {
                Console.WriteLine($"  {memberInfo.DeclaringType} {memberInfo.MemberType} {memberInfo.Name}");
            }

            Console.WriteLine();
            Console.WriteLine($"Metods: ");
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                Console.Write($"  {methodInfo.ReturnType} {methodInfo.Name} (");
                foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
                {
                    Console.Write($"{parameterInfo.ParameterType.Name} {parameterInfo.Name}, ");
                }
                Console.WriteLine(" )");
            }

            //Run
            //Console.WriteLine();
            //
            //object genre = Activator.CreateInstance(type, 12, "test", "test1");
            //MethodInfo methodDisplayGenres = type.GetMethod("GetGenres");
            //methodDisplayGenres.Invoke(genre, new object[] { });
            //Console.WriteLine(methodDisplayGenres);
        }
    }
}
