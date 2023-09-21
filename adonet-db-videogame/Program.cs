// See https://aka.ms/new-console-template for more information


using adonet_db_videogame;

Console.WriteLine("Benvenuto nel nostro sistema di gestione Videogiochi!");


while (true)
{
    Console.WriteLine(@"
- 1: Inserisci un nuovo videogioco;
- 2: Ricerca un videogioco per id;
- 3: Ricerca tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input;
- 4: Cancella un videogioco;
- 5: Chiudi il programma;
");

    Console.Write("Seleziona l'opzione desiderata: ");

    int selectOption = int.Parse(Console.ReadLine());

    switch (selectOption)
    {
        case 1:
            Console.WriteLine("Inserisci i dati del nuovo Videogioco: ");
            Console.Write("Inserisci il nome del videogioco: ");
            string name = Console.ReadLine();

            Console.Write("Inserisci la descrizione del videogioco: ");
            string overview = Console.ReadLine();

            Console.Write("Inserisci la data di rilascio del videogioco (dd/mm/yyyy): ");
            DateTime releaseDate;

            while (!DateTime.TryParse(Console.ReadLine(), out releaseDate))
            Console.WriteLine("Inserisci formato Valido! (dd/mm/yyyy)");

            Console.Write("Inserisci l'ID della Software House del videogioco: ");
            long softwareHouseId = long.Parse(Console.ReadLine());

            Videogame newVideogame = new Videogame(0, name, overview, releaseDate, softwareHouseId);
            bool inserted = VideogameManager.InsertVideogame(newVideogame);

            if(inserted)
            {
                Console.WriteLine("Il tuo videogioco è stato aggiunto correttamente!");
            }
                else
            {
                Console.WriteLine("Videogioco non inserito!");
            }

            break;
        case 2:
            Console.Write("Inserisci l'id del videogioco da cercare: ");
            long id = long.Parse(Console.ReadLine());

            Videogame videogame = VideogameManager.SearchById(id);

            if (videogame == null)
            {
                Console.WriteLine($"Il videogioco con ID {id} non è presente!");
            } else
            {
                Console.WriteLine($"Il videogioco é: {videogame}");
                Console.WriteLine();
            }
            break;

        default:
            Console.WriteLine("Non hai selezionato un opzione valida!");
            break;

    }






}
