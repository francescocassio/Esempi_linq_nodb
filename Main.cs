using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQuerySyntaxConsole
{
    public class Student
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Degree { get; set; }
        public List<int> Grades { get; set; } = new();
    }

    class Program
    {
        static List<Student> students = new()
        {
            new Student { Id = 1, Name = "Alice", Degree = "Informatica", Grades = new() { 28, 30, 29 } },
            new Student { Id = 2, Name = "Bob", Degree = "Ingegneria", Grades = new() { 25, 26 } },
            new Student { Id = 3, Name = "Charlie", Degree = "Matematica", Grades = new() { 30, 30, 30 } },
            new Student { Id = 4, Name = "Diana", Degree = "Fisica", Grades = new() { 27, 28, 26 } },
            new Student { Id = 5, Name = "Edoardo", Degree = "Informatica", Grades = new() { 24, 22 } }
        };

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("🎓 MENU LINQ con query commentate e indentate:");
                Console.WriteLine("1. Tutti gli studenti");
                Console.WriteLine("2. Studenti di Informatica");
                Console.WriteLine("3. Studenti con media > 27");
                Console.WriteLine("4. Ordinati per nome");
                Console.WriteLine("5. Ordinati per media decrescente");
                Console.WriteLine("6. Raggruppa per corso");
                Console.WriteLine("7. Solo i nomi");
                Console.WriteLine("8. Primo studente di Matematica");
                Console.WriteLine("9. Studenti con almeno un 30");
                Console.WriteLine("10. Tutti i voti >= 26");
                Console.WriteLine("11. Almeno 3 voti");
                Console.WriteLine("12. Conta voti per studente");
                Console.WriteLine("13. Studenti con voto 22");
                Console.WriteLine("14. Nomi che iniziano per A");
                Console.WriteLine("15. Corsi che contengono 'ica'");
                Console.WriteLine("16. Voto massimo per studente");
                Console.WriteLine("17. Somma voti > 80");
                Console.WriteLine("18. Media per studente");
                Console.WriteLine("19. Nome più lungo di 5 lettere");
                Console.WriteLine("20. Media massima tra tutti");
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");
                string scelta = Console.ReadLine();
                Console.WriteLine();

                switch (scelta)
                {
                    case "1": MostraTuttiGliStudenti2(); break;
                    case "2": MostraStudentiInformatica2(); break;
                    case "3": MostraStudentiMediaAlta2(); break;
                    case "4": MostraStudentiOrdinatiPerNome2(); break;
                    case "5": MostraStudentiPerMediaDesc2(); break;
                    case "6": RaggruppaPerCorsoDiLaurea(); break;
                    case "7": MostraSoloNomi(); break;
                    case "8": PrimoStudenteDiMatematica(); break;
                    case "9": StudentiConAlmenoUnTrenta(); break;
                    case "10": StudentiConTuttiVotiAlti(); break;
                    case "11": StudentiConAlmenoTreEsami(); break;
                    case "12": NumeroVotiPerStudente(); break;
                    case "13": StudentiConVotoVentidue(); break;
                    case "14": StudentiConNomeCheIniziaConA(); break;
                    case "15": StudentiInCorsoConIca(); break;
                    case "16": VotoMassimoPerStudente(); break;
                    case "17": SommaVotiMaggioriDiOttanta(); break;
                    case "18": MediaPerStudente(); break;
                    case "19": NomiLunghi(); break;
                    case "20": MediaMassimaTraTutti(); break;
                    case "0": return;
                    default: Console.WriteLine("Scelta non valida"); break;
                }

                Console.WriteLine("\nPremi un tasto per continuare...");
                Console.ReadKey();
            }
        }

        // 1. Seleziona tutti gli studenti
        static void MostraTuttiGliStudenti()
        {
            // Crea una query LINQ che seleziona tutti gli studenti
            var query =
                from s in students                 // 's' è una variabile temporanea che rappresenta ogni elemento della lista
                select s;                          // 'select s' restituisce l'intero oggetto studente

            // Scorre la query ed esegue una stampa per ogni studente
            foreach (var s in query)
                Console.WriteLine($"{s.Name} - {s.Degree}");  // Stampa nome e corso di laurea
        }

        static void MostraTuttiGliStudenti2()
        {
            // Crea una query LINQ che seleziona tutti gli studenti
            var query = students
                .Select(s => s);
            // Scorre la query ed esegue una stampa per ogni studente
            foreach (var s in query)
                Console.WriteLine($"{s.Name} - {s.Degree}");  // Stampa nome e corso di laurea
        }

        // 2. Studenti di Informatica
        static void MostraStudentiInformatica()
        {
            var query = 
                from s in students
                where s.Degree == "Informatica"    // Filtra solo gli studenti con Degree = "Informatica"
                select s;

            foreach (var s in query)
                Console.WriteLine(s.Name);         // Stampa solo il nome
        }

        static void MostraStudentiInformatica2()
        {
            var query = students
                .Where(s => s.Degree == "Informatica")
                .Select(s => s);
            foreach (var s in query)
                Console.WriteLine(s.Name);         // Stampa solo il nome
        }

        // 3. Studenti con media > 27
        static void MostraStudentiMediaAlta()
        {
            var query =
                from s in students
                where s.Grades.Average() > 27      // Calcola la media dei voti e filtra chi ha media > 27
                select s;

            foreach (var s in query)
                Console.WriteLine($"{s.Name} - Media: {s.Grades.Average():F2}");
        }

        static void MostraStudentiMediaAlta2()
        {
            var query = students
                .Where(s => s.Grades.Average() > 27)
                .Select(s => s);
            foreach (var s in query)
                Console.WriteLine($"{s.Name} - Media: {s.Grades.Average():F2}");

            //select nome, avg(voto) as media from studenti
            //group by voto
            //having media > 27
        }

        // 4. Ordinamento alfabetico
        static void MostraStudentiOrdinatiPerNome()
        {
            var query =
                from s in students
                orderby s.Name                     // Ordina alfabeticamente per nome
                select s;

            foreach (var s in query)
                Console.WriteLine(s.Name);
        }

        static void MostraStudentiOrdinatiPerNome2()
        {
            var query = students
                .OrderBy(s => s.Name)
                .Select(s => s.Name);

            foreach (var s in query)
                Console.WriteLine(s);
        }

        // 5. Ordinamento per media decrescente
        static void MostraStudentiPerMediaDesc()
        {
            var query =
                from s in students
                orderby s.Grades.Average() descending // Ordina per media in ordine decrescente
                select s;

            foreach (var s in query)
                Console.WriteLine($"{s.Name} - Media: {s.Grades.Average():F2}");
        }

        static void MostraStudentiPerMediaDesc2()
        {
            var query = students
                .OrderByDescending(s => s.Grades.Average())
                .Select(s => s);

            foreach (var s in query)
                Console.WriteLine($"{s.Name} - Media: {s.Grades.Average():F2}");
        }

        // 6. Raggruppa per corso
        static void RaggruppaPerCorsoDiLaurea()
        {
            var query =
                from s in students
                group s by s.Degree into g         // Raggruppa per Degree (corso di laurea)
                select g;

            foreach (var g in query)
            {
                Console.WriteLine($"Corso: {g.Key}");  // g.Key è il nome del corso
                foreach (var s in g)
                    Console.WriteLine($" - {s.Name}");
            }
        }

        // 7. Estrae solo i nomi
        static void MostraSoloNomi()
        {
            var query =
                from s in students
                select s.Name;                     // Seleziona solo il campo Name

            foreach (var name in query)
                Console.WriteLine(name);
        }

        // 8. Primo studente di Matematica
        static void PrimoStudenteDiMatematica()
        {
            var student =
                (from s in students
                 where s.Degree == "Matematica"    // Cerca studenti di Matematica
                 select s).FirstOrDefault();       // Prende il primo oppure null

            if (student != null)
                Console.WriteLine(student.Name);
        }

        // 9. Studenti con almeno un 30
        static void StudentiConAlmenoUnTrenta()
        {
            var query =
                from s in students
                where s.Grades.Any(g => g == 30)   // Qualche voto è uguale a 30
                select s;

            foreach (var s in query)
                Console.WriteLine(s.Name);
        }

        // 10. Tutti voti >= 26
        static void StudentiConTuttiVotiAlti()
        {
            var query =
                from s in students
                where s.Grades.All(g => g >= 26)   // Tutti i voti sono maggiori o uguali a 26
                select s;

            foreach (var s in query)
                Console.WriteLine(s.Name);
        }

        // 11. Almeno 3 esami
        static void StudentiConAlmenoTreEsami()
        {
            var query =
                from s in students
                where s.Grades.Count >= 3          // Lo studente ha almeno 3 voti
                select s;

            foreach (var s in query) 
                Console.WriteLine(s.Name);
        }

        // 12. Numero di voti per studente
        static void NumeroVotiPerStudente()
        {
            var query =
                from s in students
                select new { s.Name, Count = s.Grades.Count };  // Proiezione: nome + numero voti

            foreach (var s in query)
                Console.WriteLine($"{s.Name} ha {s.Count} voti");
        }

        // 13. Studenti con voto 22
        static void StudentiConVotoVentidue()
        {
            var query =
                from s in students
                where s.Grades.Contains(22)        // Verifica se almeno un voto è 22
                select s;

            foreach (var s in query)
                Console.WriteLine(s.Name);
        }

        // 14. Nomi che iniziano con 'A'
        static void StudentiConNomeCheIniziaConA()
        {
            var query =
                from s in students
                where s.Name.StartsWith("A")       // Filtra per iniziale del nome
                select s;

            foreach (var s in query)
                Console.WriteLine(s.Name);
        }

        // 15. Corso contiene 'ica'
        static void StudentiInCorsoConIca()
        {
            var query =
                from s in students
                where s.Degree.Contains("ica")     // Cerca "ica" nella stringa del corso
                select s;

            foreach (var s in query)
                Console.WriteLine($"{s.Name} - {s.Degree}");
        }

        // 16. Voto massimo
        static void VotoMassimoPerStudente()
        {
            var query =
                from s in students
                select new { s.Name, Max = s.Grades.Max() };  // Proiezione con voto massimo

            foreach (var r in query)
                Console.WriteLine($"{r.Name}: {r.Max}");
        }

        // 17. Somma voti > 80
        static void SommaVotiMaggioriDiOttanta()
        {
            var query =
                from s in students
                where s.Grades.Sum() > 80          // Somma dei voti maggiore di 80
                select s;

            foreach (var s in query)
                Console.WriteLine($"{s.Name} - Totale voti: {s.Grades.Sum()}");
        }

        // 18. Media per studente
        static void MediaPerStudente()
        {
            var query =
                from s in students
                select new { s.Name, Media = s.Grades.Average() };  // Calcolo media

            foreach (var r in query)
                Console.WriteLine($"{r.Name}: {r.Media:F2}");
        }

        // 19. Nomi più lunghi di 5 lettere
        static void NomiLunghi()
        {
            var query =
                from s in students
                where s.Name.Length > 5            // Verifica lunghezza del nome
                select s;

            foreach (var s in query)
                Console.WriteLine(s.Name);
        }

        // 20. Media massima tra tutti
        static void MediaMassimaTraTutti()
        {
            var max =
                (from s in students
                 select s.Grades.Average()).Max(); // Prende la media di ogni studente e poi la Max

            Console.WriteLine($"Media massima: {max:F2}");
        }

    }
}