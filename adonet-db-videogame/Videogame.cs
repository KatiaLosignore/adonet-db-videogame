using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        // ATTRIBUTI
        public long Id { get; private set; }

        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(null, "Il campo \"Nome\" non può essere vuoto!");
                }
                else
                {
                    this.name = value;
                }

            }
        }

        private string overview;
        public string Overview
        {
            get
            {
                return this.overview;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(null, "Il campo \"Descrizione\" non può essere vuoto!");
                }
                else
                {
                    this.overview = value;
                }

            }
        }
            
        public DateTime ReleaseDate { get; private set; }
        public long SoftwareHouseId {  get; private set; }

        // COSTRUTTORE
        public Videogame(long id, string name, string overview, DateTime releaseDate, long softwarehouse_id)
        {
            this.Id = id;
            this.Name = name;
            this.Overview = overview;
            this.ReleaseDate = releaseDate;
            this.SoftwareHouseId = softwarehouse_id;
        }

        // METODI
        public override string ToString()
        {
            return $"ID: {Id} Nome: {Name} Descrizione: {Overview} Data di rilascio: {ReleaseDate.ToString("dd/MM/yyyy")}";
        }

    }
}
