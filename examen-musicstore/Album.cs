using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_musicstore
{
    internal class Album
    {
        private string titulo;
        private string artista;
        private int anyo;
        private bool disponible;

        public Album(string titulo, string artista, int anyo, bool disponible)
        {
            this.titulo = titulo;
            this.artista = artista;
            this.anyo = anyo;
            this.disponible = disponible;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Artista { get => artista; set => artista = value; }
        public int Anyo { get => anyo; set => anyo = value; }
        public bool Disponible { get => disponible; set => disponible = value; }

        public override string ToString()
        {
            return titulo + " - " + artista + " (" + anyo + ")";
        }
    }
}
