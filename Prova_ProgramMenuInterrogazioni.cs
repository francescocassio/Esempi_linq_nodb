//using System;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;

//namespace SerieAConsoleApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using var context = new SerieADbContext(); 

//            while (true) 
//            {
//                Console.Clear();
//                Console.WriteLine("📊 MENU INTERROGAZIONI SERIE A");
//                Console.WriteLine("1. Squadre con più di 5 giocatori");
//                Console.WriteLine("2. Giocatori per squadra");
//                Console.WriteLine("3. Elenco partite con squadre e risultato");
//                Console.WriteLine("4. Età media giocatori per squadra");
//                Console.WriteLine("0. Esci");
//                Console.Write("Scegli un'opzione: ");
//                string scelta = Console.ReadLine();

//                Console.WriteLine();
//                switch (scelta)
//                {
//                    case "1":
//                        var squadre = context.Squadre
//                            .Include(s => s.Giocatori)
//                            .Where(s => s.Giocatori.Count > 5)
//                            .Select(s => new
//                            {
//                                s.Nome,
//                                Giocatori = s.Giocatori.Count
//                            }).ToList();

//                        foreach (var s in squadre)
//                            Console.WriteLine($"{s.Nome}: {s.Giocatori} giocatori");
//                        break;

//                    case "2":
//                        var elenco = context.Giocatori
//                            .Include(g => g.Squadra)
//                            .OrderBy(g => g.Squadra.Nome)
//                            .ThenBy(g => g.Nome)
//                            .Select(g => new { g.Nome, g.Ruolo, Squadra = g.Squadra.Nome })
//                            .ToList();

//                        foreach (var g in elenco)
//                            Console.WriteLine($"{g.Nome} ({g.Ruolo}) - {g.Squadra}");
//                        break;

//                    case "3":
//                        var partite = context.Partite
//                            .Include(p => p.SquadraCasa)
//                            .Include(p => p.SquadraTrasferta)
//                            .Select(p => new
//                            {
//                                Data = p.Data.ToShortDateString(),
//                                Casa = p.SquadraCasa.Nome,
//                                Trasferta = p.SquadraTrasferta.Nome,
//                                p.GolCasa,
//                                p.GolTrasferta
//                            }).ToList();

//                        foreach (var p in partite)
//                            Console.WriteLine($"{p.Data}: {p.Casa} {p.GolCasa} - {p.GolTrasferta} {p.Trasferta}");
//                        break;

//                    case "4":
//                        var etaMedia = context.Squadre
//                            .Include(s => s.Giocatori)
//                            .Select(s => new
//                            {
//                                s.Nome,
//                                MediaEta = s.Giocatori.Any() ? s.Giocatori.Average(g => g.Età) : 0
//                            }).ToList();

//                        foreach (var s in etaMedia)
//                            Console.WriteLine($"{s.Nome}: Età media {s.MediaEta:F1}");
//                        break;

//                    case "0":
//                        return;

//                    default:
//                        Console.WriteLine("❌ Scelta non valida.");
//                        break;
//                }

//                Console.WriteLine("\nPremi un tasto per continuare...");
//                Console.ReadKey();
//            }
//        }
//    }
//}