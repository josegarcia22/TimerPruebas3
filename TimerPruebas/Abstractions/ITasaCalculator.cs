using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerPruebas.Abstractions
{

    public interface ITaxCalculator
    {
        double CalculateTaxPerMonth(double monthlyIncome);
    }
}

//Lo que podemos notar aquí:

//Esta es la interfaz ITaxCalculator.
//Representa todas las calculadoras de impuestos que podríamos tener en la solución.
//Define solo un método con el encabezado double CalculateTaxPerMonth(double monthlyIncome);.