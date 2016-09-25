/*Product.cs
 * Made by: Ahmet Sezer 2016-09-16
 * Change by: Ahmet Sezer 2016-09-17 , lagt till slutliga if-satser i metoder så det funkar Om nej
 * Changed by: Ahmet Sezer 2016-09-18, lagt till slutliga kommentarer
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
    /// Klass som frågar vad som saknas i ens kylskåp med pris mm som
    /// sedan lägger till varan i shoppinglistan.
    /// Slutligen printar ut all inmatning. Finns två olika utprintningsalternativ som kan kommenteras bort.	
    /// Innehåller alla metoder och variabler
    /// 
    /// NOTE: I min dator funkar det enbart med kommatecken (,) när man matar in en double.    
    /// </summary>
    public class Product // den publika klassen som innehåller alla metoder och variabler
    {
        //Att göra: 1.a) kommunicera med användaren, vad saknas i kylen och vad det kostar, 2 saker
        //          1.b) Fråga ja/nej-fråga, t.ex. lägga till mjölk? om ja, lägga det i shoppinglista och beräkna. Om nej gå till nästa steg för att lägga till en annan vara
        //          2. Beräkna kostnad för shoppinglistan
        //          3. Redogör för användaren vad shoppinglistan innehåller samt vad det kommer att kosta. Print

        //Här deklareras variabler
        
        private string item1, item2; //varorna
        private bool addToChart, addToChart2; //lägga till i shoppinglistan? y/n
        private double itemPrice, itemPrice2; //enhetspris
        private int amount, amount2;   //anatl/mängd av en vara
        private int totalAmount;    //antalat vara av item1 och item2
        private double total1, total2;    //totalpris utan moms per vara
        private double totalPrice;  //utan moms
        private double incVat;      //endast moms delen
        private double totalPriceIncVat; //total priset inklusive moms
        private const double foodVat = 0.12; //endast mat moms 12% i och med kylskåp

        //Här kommer alla metoder
        public void ShoppingList()  //den stora metoden som har åtkomst publik och innehåller andra metoder. Det är den som anropas från Main
        {

            ReadInput();        //metod för inläsning från användaren som innehåller flera mindre metoder
            Calculate();        //metod för beräkning, innehåller flera metoder
            PrintOnScreen();    //utför utskriften, finns en alterntiv också

        }
        private void ReadInput()
        {

            ReadProduct();  //frågar första varan
            ReadAddToChart(); //bool ja/nej lägg till i shoppinglistan
            
            ReadUnitPrice();    //läser av inmatade enhetspriset
            ReadAmount();       //antal av en vara

            ReadAnotherItem(); //bool ja/nej till ytterligare en vara
            ReadProduct2();     //läser av en andra vara
            ReadUnitPrice1();   //enhetspris för andra varan
            ReadAmount1();      //antal för andra varan
            
        }
        private void ReadProduct()
        {
            Console.Write("What do you miss in your fridge? ");     //frågar använadáren
            item1 = Console.ReadLine();                             //lägger första varan i variabeln 
        }
        private void ReadAddToChart() //metoden som frågar Om varan ska läggas till, (y/n)
        {
            Console.Write("Add " + item1 + " to shoppinglist (y/n)?: ");    //Frågar om varan ska läggas till i shoppiinglistan
            char answer = char.Parse(Console.ReadLine());

            if ((answer == 'y') || (answer == 'Y')) //om y eller Y
            {
                addToChart = true;                  //sätter variabeln till sant om y/Y
            }
            else
                //om nej nollställ item1 och hoppa över till att lägga till en annan vara
            { 
                addToChart = false; //annars falskt
                item1 = ""; //nollställer variabeln
                
            }
        }
        private void ReadUnitPrice() //Läser av inmatade enhetspriset
        {
            if (addToChart == true) // Om, lägga till i varukorgen är sant
            {
                Console.Write("What is the price for " + item1 + "?: ");
                itemPrice = double.Parse(Console.ReadLine());
            }
        }
        private void ReadAmount() //Läser av inmatad antal av varan
        {
            if (addToChart == true) //OM, lägga till i varukorgen är sant
            {
                Console.Write("How many " + item1 + " would you like to add?: ");
                amount = int.Parse(Console.ReadLine());
            }
        }

        private void ReadAnotherItem()  //frågar om en till vara ska läggas till
        {
            Console.Write("Do you want to add another item to the list? (y/n): ");
            char answer2 = char.Parse(Console.ReadLine());  //tar emot en bokstav 

            if ((answer2 == 'y') || (answer2 == 'Y'))    //om y/Y så är det sant annars falskt
               
                    addToChart2 = true;
               
            else //om falskt nollställ andra varan
                addToChart2 = false;
                item2 = "";     
        }
        
         private void ReadProduct2() // Om lägga till andra varan i varukorgen sant, fråga vad varan är
        {
            if (addToChart2 == true)
            {
                Console.Write("What is the second item: ");
                item2 = Console.ReadLine(); //tilldelar inmatningen till variablen
            }

        }

        private void ReadUnitPrice1() //Om,lägga till i varukorgen är sant fråfa enhetspris
        {
            if (addToChart2 == true)
            {
                Console.Write("What is the price for " + item2 + "?: ");
                itemPrice2 = double.Parse(Console.ReadLine());
            }
        }       
       
        private void ReadAmount1()  //Om sant, fråga antal
        {
            if (addToChart2 == true)
            {
                Console.Write("How many " + item2 + " would you like to add?: ");
                amount2 = int.Parse(Console.ReadLine());
            }
        }
        private void Calculate() //beräkningsmetoden som inheåller flera metoder
        {     
            TotalAmount(); //summerar antal 
            TotalOfProd1(); //total pris för första varan, utan moms
            TotalOfProd2(); // total pris för andra varan, utan moms
            TotalPrice();   // summerar, totalpriserna som är utan moms
            IncVat();       // endast moms delen
            TotalPriceIncVat(); //totalpriset med moms
        }
        private void TotalAmount() //Ska räkna totala antalet produkter av allt
        {
            totalAmount = amount + amount2;
        }
        private void TotalOfProd1() 
        {
            total1 = amount * itemPrice;
        }
        private void TotalOfProd2()
        {
            total2 = amount2 * itemPrice2;
        }
        private void TotalPrice()
        {
            totalPrice = total1 + total2;   //Obs utan moms!
        }
       
        private void IncVat()
        {
            incVat = totalPrice * foodVat;
        }
        private void TotalPriceIncVat() //Att betala inklusive moms
        {
            totalPriceIncVat = incVat + totalPrice; 
        }
        private void PrintOnScreen() //utskrift, gjort två stycken 
        {
            
             Console.WriteLine();
             Console.WriteLine();
             Console.WriteLine();
             Console.WriteLine("*********************** WELCOME TO APU'S ShoppingList ***********************");
             Console.WriteLine("***");
             Console.WriteLine("{0,-35}{1,30}", "*** Name of the product:", item1);
             Console.WriteLine("{0,-35}{1,30}", "*** Qantity of " + item1 + ":", amount);
             Console.WriteLine("{0,-35}{1,30}", "*** Unit price for " + item1 + ":", itemPrice);
             Console.WriteLine("{0,-35}{1,30}", "*** Add to list:", addToChart);
             Console.WriteLine("{0,-35}{1,30}", "*** Name of the second product:", item2);
             Console.WriteLine("{0,-35}{1,30}", "*** Qantity of " + item2 + ":", amount2);
             Console.WriteLine("{0,-35}{1,30}", "*** Unit price for " + item2 + ":", itemPrice2);
             Console.WriteLine("{0,-35}{1,30}", "*** Add to list:", addToChart2);
             Console.WriteLine("{0,-35}{1,30}", "*** Total Amount of items:", totalAmount);
             Console.WriteLine("***");
             Console.WriteLine("*** You have added " + item1 + " and " + item2 + " to the Shoppinglist!***");
             Console.WriteLine("***");
             Console.WriteLine("{0,-35}{1,30}", "*** It will cost you:", totalPriceIncVat);
             Console.WriteLine("{0,-35}{1,30}", "*** Including VAT at " + foodVat * 100 + " %", incVat);
             Console.WriteLine("***");
             Console.WriteLine("*** This program has been developed by: Ahmet Sezer ***");
             Console.WriteLine("*************************PLEASE COME AGAIN!***********************************");
             Console.WriteLine();
             Console.WriteLine();
             Console.WriteLine();


            //Alternativ utskrift, kommentera bort första
            /*
            Console.WriteLine();
            Console.WriteLine("*********************** WELCOME TO APU'S ShoppingList ***********************");
            Console.WriteLine("You have added " +totalAmount +" items to you shoppinglist!");
            Console.WriteLine("Shoppinglist: "+ item1 + ", "+ item2 + "." );
            Console.WriteLine("It's going to cost you " + totalPriceIncVat + " kr.");
            Console.WriteLine("*** This program has been developed by: Ahmet Sezer ***");
            Console.WriteLine("*************************PLEASE COME AGAIN!***********************************");
            Console.WriteLine();*/

        }
    }
}
