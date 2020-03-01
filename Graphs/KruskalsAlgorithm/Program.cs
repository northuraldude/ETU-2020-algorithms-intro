/**
 * Дисциплина: Построение и анализ алгоритмов
 * Тема: Алгоритмы на графах - алгоритм Краскала и СНМ
 * Разработал: Белоусов Евгений
 * Группа: 6305
 */

using System;
using System.Collections.Generic;
using KruskalsAlgorithm.UFDS;

namespace KruskalsAlgorithm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Раскомментировать требуемый метод
            
            // Передать в метод "naive" для использования наивной реализации,
            // либо любую строку для использования леса корневых деревьев
            DoKruskal("forest");
            
            //DoUFDSForest();
        }
        
        /// <summary>
        /// Выполнить алгоритм Краскала
        /// </summary>
        /// <remarks>
        /// В первой строке задаются количество вершин и количество рёбер,
        /// в последующих строках - вершина u, вершина v и вес ребра
        /// </remarks>
        /// <param name="type"> Тип реализации - наивная или лес корневых деревьев </param>
        private static void DoKruskal(string type)
        {
            // Инициализация графа с помощью введённых в консоль параметров
            var size = Console.ReadLine().Split(null);
            var verticlesCount = Convert.ToInt32(size[0]);
            var edges = new List<Edge>();
            for (var i = 0; i < Convert.ToInt32(size[1]); i++)
            {
                var parameters = Console.ReadLine().Split(null);
                edges.Add(new Edge(Convert.ToInt32(parameters[0]),
                                         Convert.ToInt32(parameters[1]),
                                         Convert.ToInt32(parameters[2])));
            }
            
            // Выполнение алгоритма с выбранной реализацией (наивная или лес)
            var kruskal = type == "naive" ? new Kruskal(new UfdsNaive()) 
                                          : new Kruskal(new UfdsForest());
            var result = kruskal.BuildMST(edges, verticlesCount);
            
            // Вывод результатов в заданной форме
            Console.Out.Write(result.Count + " " + kruskal.Cost + "\n");
            foreach (var edge in result)
                Console.Out.Write(edge.U + " " + edge.V + "\n");
        }

        /// <summary>
        /// Выполнить проверку работы СНМ
        /// </summary>
        /// <remarks>
        /// Используется реализация с помощью леса корневых деревьев
        /// </remarks>
        /// <param name="type"> Тип реализации - наивная или лес корневых деревьев </param>
        private static void DoUFDSForest()
        {
            // Инициализация множеств
            var ufds = new UfdsForest();
            var result = new List<string>();
            var countItems = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < countItems; i++)
                ufds.MakeSet(i);
            
            // Выполнение объединения множеств
            for (var i = 0; i < countItems - 1; i++)
            {
                var elems = Console.ReadLine().Split(null);
                ufds.Union(Convert.ToInt32(elems[0]), Convert.ToInt32(elems[1]));
                result.Add(ufds.Find(0) == ufds.Find(countItems - 1) ? "YES" : "NO");
            }

            // Вывод результата в заданном формате
            foreach (var line in result)
                Console.Out.Write(line + "\n");
        }
    }
}
