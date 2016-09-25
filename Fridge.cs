/*Fridge.cs
 * 
 * Made by: Ahmet Sezer, 2016-09-16
 * Changed by: Ahmet Sezer, lagt till mer kommentarer 2016-09-18
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fridge
{
    /// <summary>
    /// 
    /// Konsol applikation som frågar efter vad som saknas i kylskåpet sedan
    /// lägger till varan med pris i shoppinglistan.
    /// Slutligen printar ut allt med totalkostnad.
    /// 
    /// Den här klassen, innehåller Main, som använder sig av en annan klass, Product. 
    /// </summary>
    class Fridge
    {
        static void Main(string[] args) //Main som startar programmet/assemblyn
        {
            Console.Title = "Apu's Refrigerator!"; //Namnet på konsolen
            Console.Clear(); //rensar 

            Product shoppingListObj = new Product();    //skapar ny objekt av klassen Product
            shoppingListObj.ShoppingList(); //anropar objektes publika metod i klassen Product


            Console.WriteLine("Press Enter to Exit!");
            Console.ReadLine();
        }
    }
}
