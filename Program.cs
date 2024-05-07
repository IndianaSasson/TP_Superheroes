namespace TP02_BIS_Superheroes_Sasson_Izraelewicz;

class Program
{
    static void Main(string[] args)
    {
        int opcion;
        superheroe sup1 = new superheroe();
        superheroe sup2 = new superheroe();

        Console.WriteLine("1. Cargar datos de superheroe 1: ");
        Console.WriteLine("2. Cargar datos de superheroe 2: ");
        Console.WriteLine("3. ¡Competir!: ");
        Console.WriteLine("4. Cambiar Velocidad y Fuerza de un superheroe: ");
        Console.WriteLine("5. Atributos Aleatorios:");
        Console.WriteLine("6. Salir.");

        opcion= ingresarOpcion("Ingrese la opción que desea: ");
        do
        {
            switch (opcion)
        {
            case 1:
             
                sup1 = ingresarDatos(); 
                
                opcion= ingresarOpcion("Ingrese la opción que desea: ");
            break;

            case 2:
                sup2 = ingresarDatos();
                opcion = ingresarOpcion("Ingrese la opción que desea: ");   
            break;

            case 3: 
                calcularGanador(sup1, sup2); 
                opcion = ingresarOpcion("Ingrese la opción que desea: ");   

            break;

            case 4:
                if(sup1.nombre != "sin nombre" && sup2.nombre != "sin nombre")
                {
                     int supElegido = ingresarSuperheroe("Ingrese el Superheroe del que quiera cambiar la Velocidad y Fuerza (ingrese 1 / 2):");
                     if (supElegido == 1)
                     {
                         sup1.velocidad = ingresarDouble ("Ingresa la nueva velocidad:", "ERROR! Ingrese nuevamente", 1, 100);
                         sup1.fuerza = ingresarDouble ("Ingresa la nueva fuerza:", "ERROR! Ingrese nuevamente", 1, 100);
                     }
                     else
                     {
                         sup2.velocidad = ingresarDouble ("Ingresa la nueva velocidad:", "ERROR! Ingrese nuevamente", 1, 100);
                         sup2.fuerza = ingresarDouble ("Ingresa la nueva fuerza:", "ERROR! Ingrese nuevamente", 1, 100);
                     }
                     
                     calcularGanador(sup1, sup2); 
                     opcion = ingresarOpcion("Ingrese la opción que desea: ");   

                } else opcion = ingresarOpcion("ERROR! Todavía no existe ningún superheroe, Ingrese la opción que desea: ");
                
               
            break;

            case 5: 
                 if(sup1.nombre != "sin nombre" && sup2.nombre != "sin nombre")
                 {
                      sup1.velocidad = sup1.atributosAleatorios();
                      sup1.fuerza = sup1.atributosAleatorios();
                      sup2.velocidad = sup2.atributosAleatorios();
                      sup2.fuerza = sup2.atributosAleatorios();
                    
                     calcularGanador(sup1, sup2); 
                     opcion = ingresarOpcion("Ingrese la opción que desea: ");   
                 }
                 else opcion = ingresarOpcion("ERROR! Todavía no existe ningún superheroe, Ingrese la opción que desea: ");   
                
            break;
           
        }

        } while (opcion != 6);
        
    }

    public static void calcularGanador(superheroe sup1, superheroe sup2)
    {
        if(sup1.nombre != "sin nombre" && sup2.nombre != "sin nombre")
        {
                    double puntos1 = sup1.obtenerSkill(sup1.velocidad, sup1.fuerza, sup1.inteligencia);
                    double puntos2 = sup2.obtenerSkill(sup2.velocidad, sup2.fuerza, sup2.inteligencia);
                    
                    double puntosGanador;
                    double puntosPerdedor;
                    string nombreGanador;
                   
                    if (puntos1 > puntos2)
                    {
                        puntosGanador = puntos1;
                        puntosPerdedor = puntos2;
                        nombreGanador = sup1.nombre;
                    }
                    else if (puntos2 > puntos1)
                    {
                        puntosGanador = puntos2;
                        puntosPerdedor = puntos1;
                        nombreGanador = sup2.nombre;
                    }
                    else
                    {
                        nombreGanador = sup2.nombre + " y " + sup1.nombre;
                        puntosGanador = puntos2;
                        puntosPerdedor = puntos1;
                    }

                   
                    double dif = puntosGanador - puntosPerdedor;
                    if(dif == 0) Console.WriteLine("Empate!");
                    else if(dif < 10 && dif>0) Console.WriteLine("Ganó " + nombreGanador + " por nada!");
                    else if (dif >= 10 && dif < 30) Console.WriteLine("Ganó " + nombreGanador + " estuvo muy parejo!");
                    else if (dif >= 30) Console.WriteLine("Ganó " + nombreGanador + " por una amplia diferencia");
        } 
        else Console.WriteLine("ERROR! No se puede dar la pelea si no existe alguno de los 2 superheroes");
    }
    
    public static int ingresarSuperheroe(string msj)
    {
        int op;
        do
        {
            Console.WriteLine(msj);
            op = int.Parse(Console.ReadLine());

            if (op != 1 && op != 2) Console.WriteLine("ERROR! Solo existe el superheroe 1 o 2, ingrese de nuevo: ");
            
        } while (op != 1 && op != 2);
        return op;
    }
   
    public static superheroe ingresarDatos()
    {
        superheroe supp = new superheroe();
        supp.nombre = ingresarString("Ingresa el nombre del superheroe:", "ERROR! Ingrese nuevamente");
        supp.ciudad = ingresarString ("Ingresa la ciudad:", "ERROR! Ingrese nuevamente");
       
        int max = int.MaxValue;
        
        supp.peso = ingresarDouble ("Ingresa el peso del superheroe:", "ERROR! Ingrese nuevamente", 1, max);
        supp.inteligencia = ingresarDouble ("Ingresa la inteligencia del superheroe (en números):", "ERROR! Ingrese nuevamente", 1, max);
        supp.velocidad = ingresarDouble ("Ingresa la velocidad:", "ERROR! Ingrese nuevamente", 1, 100);
        supp.fuerza = ingresarDouble ("Ingresa la fuerza:", "ERROR! Ingrese nuevamente", 1, 100);

        Console.WriteLine("Se creó el superheroe: " + supp.nombre);
        return supp;
    }

      static string ingresarString (string msj, string msjError)
    {
        string var;
        do
        {
            Console.WriteLine(msj);
            var = Console.ReadLine();

            if (var == string.Empty)
            {
                Console.WriteLine(msjError);
            }
        } while (var == string.Empty);
        return var;
    }

    static double ingresarDouble(string msj, string msjError, int min, int max)
    {
        double var;
        do
        {
            Console.WriteLine(msj);
            var = int.Parse(Console.ReadLine());

            if (var < min || var > max)
            {
                Console.WriteLine(msjError);
            }
        } while (var < min || var > max);
        return var;
    }
    static int ingresarOpcion(string msj)
    {
        int op;
        do
        {
            Console.WriteLine(msj);
            op = int.Parse(Console.ReadLine());
        } while (op < 1 || op >6);
        return op;
    }
}
