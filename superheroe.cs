class superheroe{
    public string nombre {get; set;}
    public string ciudad {get; set;}
    public double peso {get; set;}
    public double velocidad {get; set;}
    public double fuerza {get; set;}
    public double inteligencia {get; set;}

    public superheroe(){
        nombre = "sin nombre";
    }

    public superheroe(string nom, string ciudadd, double pesoo, double vel, double f, double inte)
    {
        nombre = nom;
        ciudad = ciudadd;
        peso = pesoo;
        velocidad = vel;
        fuerza = f;
        inteligencia = inte;

    }

    public double obtenerSkill(double vel, double fuer, double inte)
    {
        double velCalculada = vel * 0.6;
        double fuerCalculada = fuer * 0.8;
        double inteCalculada = inte * 0.25;
        
        Random rnd = new Random();
        double random = rnd.Next(1, 10);

        double skill = fuerCalculada + velCalculada + random + inteCalculada; 
        return skill;
    }

    public double atributosAleatorios()
    {
            Random rnd = new Random();
            double random = rnd.Next(1, 100);
            return random;
    }
   
}