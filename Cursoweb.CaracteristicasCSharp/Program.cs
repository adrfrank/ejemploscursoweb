using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursoweb.CaracteristicasCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonasModelContainer db = 
                new PersonasModelContainer();
           
            //db.PersonaSet.Add(new Persona() {  Nombre = "Xavi", 
            //    Apellido="Delgado", FechaDeNacimiento = DateTime.Now.AddYears(-18)});
            var xavi = (from p in db.PersonaSet
                       where p.Nombre.StartsWith("X")
                       select p).FirstOrDefault();
            if (xavi != null) {
                xavi.Nombre = "Xavier";
                db.SaveChanges();
            }
            
            var personas = db.PersonaSet.ToList();
            foreach (var item in personas)
            {
                Console.WriteLine(item.Id+"-"+item.Nombre+"  "+item.Apellido+ " "+item.FechaDeNacimiento);
            }       

            
            Console.ReadKey();
            db.Dispose();
        }
    }
}
