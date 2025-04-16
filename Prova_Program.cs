//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace ConsoleAppLinqDemo
//{
//    public class Student
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Degree { get; set; }
//        public List<int> Grades { get; set; } = new(); 
//    }

//    class Program
//    {
//        // ✅ Lista statica di studenti, ognuno con una lista di voti
//        static List<Student> students = new List<Student>
//        {
//            new Student { Id = 1, Name = "Alice", Degree = "Informatica", Grades = new List<int> { 28, 30, 29 } },
//            new Student { Id = 2, Name = "Bob", Degree = "Ingegneria", Grades = new List<int> { 25, 26 } },
//            new Student { Id = 3, Name = "Charlie", Degree = "Matematica", Grades = new List<int> { 30, 30, 30 } },
//            new Student { Id = 4, Name = "Diana", Degree = "Fisica", Grades = new List<int> { 27, 28, 26 } },
//            new Student { Id = 5, Name = "Edoardo", Degree = "Informatica", Grades = new List<int> { 24, 22 } }
//        };

//        static void Main(string[] args)
//        {
//            while (true)
//            {
//                Console.Clear();
//                Console.WriteLine("🎓 MENU LINQ - Seleziona un'opzione:");
//                Console.WriteLine("1. Visualizza tutti gli studenti");
//                Console.WriteLine("2. Studenti con media > 27");
//                Console.WriteLine("3. Nomi degli studenti");
//                Console.WriteLine("4. Studenti ordinati per media (desc)");
//                Console.WriteLine("5. Studenti con almeno un 30");
//                Console.WriteLine("6. Studenti con tutti i voti >= 26");
//                Console.WriteLine("7. Studenti raggruppati per corso");
//                Console.WriteLine("8. Top 2 studenti per media");
//                Console.WriteLine("9. Numero studenti con media < 27");
//                Console.WriteLine("10. Primo studente di Informatica");
//                Console.WriteLine("11. Media massima e minima");
//                Console.WriteLine("0. Esci");
//                Console.Write("\nScelta: ");

//                var input = Console.ReadLine();
//                Console.WriteLine();

//                switch (input)
//                {
//                    case "1": MostraTutti(); break;
//                    case "2": StudentiConMediaAlta(); break;
//                    case "3": MostraNomi(); break;
//                    case "4": OrdinaPerMedia(); break;
//                    case "5": StudentiConTrenta(); break;
//                    case "6": StudentiSolid(); break;
//                    case "7": RaggruppaPerCorso(); break;
//                    case "8": Top2(); break;
//                    case "9": ContaMediaBassa(); break;
//                    case "10": PrimoInformatica(); break;
//                    case "11": MostraMaxMin(); break;
//                    case "0": return;
//                    default: Console.WriteLine("❌ Scelta non valida."); break;
//                }

//                Console.WriteLine("\nPremi un tasto per continuare...");
//                Console.ReadKey();
//            }
//        }

//        static void MostraTutti()
//        {
//            foreach (var s in students)
//                Console.WriteLine($"{s.Name} - {s.Degree}");
//        }

//        static void StudentiConMediaAlta()
//        {
//            // ➤ .Where(): filtra gli elementi di una lista
//            // ➤ .Average(): calcola la media dei voti
//            var result = students
//                .Where(s => s.Grades.Average() > 27); // seleziona solo chi ha media > 27

//            foreach (var s in result)
//                Console.WriteLine($"{s.Name} - Media: {s.Grades.Average():F2}");
//        }

//        static void MostraNomi()
//        {
//            // ➤ .Select(): estrae solo il nome da ogni studente
//            var result = students
//                .Select(s => s.Name); // proietta solo il campo Name

//            foreach (var name in result)
//                Console.WriteLine(name);
//        }

//        static void OrdinaPerMedia()
//        {
//            // ➤ .OrderByDescending(): ordina i dati in ordine decrescente
//            var result = students
//                .OrderByDescending(s => s.Grades.Average()); // ordina per media dei voti

//            foreach (var s in result)
//                Console.WriteLine($"{s.Name} - Media: {s.Grades.Average():F2}");
//        }

//        static void StudentiConTrenta()
//        {
//            // ➤ .Any(): restituisce true se almeno un elemento soddisfa la condizione
//            var result = students
//                .Where(s => s.Grades.Any(g => g == 30)); // almeno un voto 30

//            foreach (var s in result)
//                Console.WriteLine($"{s.Name}");
//        }

//        static void StudentiSolid()
//        {
//            // ➤ .All(): restituisce true solo se TUTTI gli elementi soddisfano la condizione
//            var result = students
//                .Where(s => s.Grades.All(g => g >= 26)); // tutti i voti >= 26

//            foreach (var s in result)
//                Console.WriteLine($"{s.Name}");
//        }

//        static void RaggruppaPerCorso()
//        {
//            // ➤ .GroupBy(): raggruppa gli elementi per una chiave (in questo caso Degree)
//            var groups = students
//                .GroupBy(s => s.Degree); // gruppi per corso di laurea

//            foreach (var group in groups)
//            {
//                Console.WriteLine($"Corso: {group.Key} ({group.Count()} studenti)");
//                foreach (var s in group)
//                    Console.WriteLine($" - {s.Name}");
//            }
//        }

//        static void Top2()
//        {
//            // ➤ .Take(): restituisce i primi N risultati
//            var result = students
//                .OrderByDescending(s => s.Grades.Average()) // ordina per media
//                .Take(2); // prende i primi 2

//            foreach (var s in result)
//                Console.WriteLine($"{s.Name} - Media: {s.Grades.Average():F2}");
//        }

//        static void ContaMediaBassa()
//        {
//            // ➤ .Count(): restituisce quanti elementi rispettano la condizione
//            int count = students
//                .Count(s => s.Grades.Average() < 27); // quanti con media < 27

//            Console.WriteLine($"📉 Numero di studenti con media < 27: {count}");
//        }

//        static void PrimoInformatica()
//        {
//            // ➤ .FirstOrDefault(): restituisce il primo elemento trovato, oppure null
//            var s = students
//                .FirstOrDefault(s => s.Degree == "Informatica"); // primo studente di Informatica

//            if (s != null)
//                Console.WriteLine($"{s.Name} - Media: {s.Grades.Average():F2}");
//        }

//        static void MostraMaxMin()
//        {
//            // ➤ .Max(): restituisce il valore massimo della funzione passata
//            // ➤ .Min(): restituisce il valore minimo
//            var max = students.Max(s => s.Grades.Average());
//            var min = students.Min(s => s.Grades.Average());

//            Console.WriteLine($"📊 Media massima: {max:F2}, minima: {min:F2}");
//        }
//    }
//}
