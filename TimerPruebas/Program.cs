using Autofac;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TimerPruebas.Abstractions;
using TimerPruebas.Implementations;
//3 Probando... de Ahmed Tarek


namespace TimerPruebas
{
    //class Program
    //{
        //static void Main(string[] args)
        //{
        //    //IPublisher publi = new Publisher(new Implementations.Consola());
        //    //publi.StartPublishing();
        //    //Console.ReadLine();
        //    //publi.StopPublishing();
        //    //   Bad Solution
        //    //In this solution, we would directly use System.Timers.Timer without providing a layer of abstraction.
        //    //It is a UsingTimer solution with only one Console TimerApp project.

        //    //I intentionally invested some time and effort in abstracting System.
        //    //Console into IConsole to prove that this would not solve our problem with the Timer.

        class Program
        {
            private static Autofac.IContainer Container;

            static void Main(string[] args)
            {
                var builder = new ContainerBuilder();//aqui pide autofac
                builder.RegisterType<ConsolaLogger>().As<ILogger>();
                builder.RegisterType<IncomeTaxCalculator>().As<ITaxCalculator>();
                builder.RegisterType<VatTaxCalculator>().As<ITaxCalculator>();
                Container = builder.Build();

                using (var scope = Container.BeginLifetimeScope())
                {
                    var logger = scope.Resolve<ILogger>();
                    var taxCalculators = scope.Resolve<IEnumerable<ITaxCalculator>>();
                    var monthlyIncome = 2000.0;
                    var totalTax = 0.0;

                    foreach (var taxCalculator in taxCalculators)
                    {
                        totalTax += taxCalculator.CalculateTaxPerMonth(monthlyIncome);
                    }

                    logger.LogMessage($"Total Tax for Monthly Income: {monthlyIncome} equals {totalTax}");
                }

                Console.ReadLine();
            }
    }

    }

//What we can notice here:

//This is the Program class. It is the main entry point to the whole application,
//    which is, by the way, a C# Console Application.
//We are using AutoFac IoC Container, so you will need to install it from the Nuget package manager.
//In the Main method, the first thing we are doing is that we are initializing the IoC container, 
//defining our abstractions-implementations pairs, and creating our IoC container scope.
//Inside the scope, we are resolving an instance of the ILogger,
//and a list of all available ITaxCalculator implementations.
//Then we are using all the Tax Calculators to get the sum of all combined Taxes.
//And finally logging a message.

//Autofac is an IoC container for Microsoft .NET. 
//    It manages the dependencies between classes 
//    so that applications stay easy to change as they grow in size and complexity.


//-----------------

//Great, the application is working as expected, we have defined our dependencies,
//    we are using DI, IoC, and IoC Containers… perfect.

//Ok, you might find this perfect and easy to read and understand. However,
//what if you have too many modules, too many loggers, too many calculators,…