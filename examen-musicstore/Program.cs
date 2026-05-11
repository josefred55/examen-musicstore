using examen_musicstore;

//apartado 2.3
static void guardarAlbumes(List<Album> albumes, String ruta) {
    StreamWriter flujoSalida = File.CreateText(ruta);
    foreach(Album album in albumes)
    {
        flujoSalida.WriteLine(album.Titulo + ";" + album.Artista + ";" +
            album.Anyo + ";" + album.Disponible); 
    }
    Console.WriteLine("Albumes guardados correctamente");
    flujoSalida.Close();
}
static void Main(string[] args)
{
    //Apartado 2.1
    //A
    List<Album> albumes = new List<Album>();
    albumes.Add(new Album("Plastic Beach", "Gorillaz", 2010, true));
    albumes.Add(new Album("Thriller", "Michael Jackson", 1982, false));
    albumes.Add(new Album("Muerte", "Canserbero", 2012, true));

    //B
    foreach(Album album in albumes)
    {
        Console.WriteLine(album.ToString());
    }

    //C
    foreach(Album album in albumes)
    {
        if (album.Artista.Contains("Metallica"))
        {
            Console.WriteLine(album.ToString());
        }
    }

    //apartado 2.2
    DateTime fecha = DateTime.Now;
    Console.WriteLine("Fecha actual: " + fecha.ToShortDateString());

    guardarAlbumes(albumes, "albumes.txt");
}

Main(args);