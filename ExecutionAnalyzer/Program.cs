// See https://aka.ms/new-console-template for more information

using ExecutionAnalyzer.Boubble_Sort;
using ExecutionAnalyzer.Heap_Sort;
using ExecutionAnalyzer.Insertion_Sort;
using ExecutionAnalyzer.Merge_Sort;
using ExecutionAnalyzer.Quick_Sort;
using ExecutionAnalyzer.Selection_Sort;

static int[] GenerateArray(int cantidad)
{
    Random random = new Random();
    HashSet<int> numeros = new HashSet<int>();

    while (numeros.Count < cantidad)
    {
        numeros.Add(random.Next(1, cantidad * 10));
    }

    return numeros.ToArray();
}

void AnalyzeSortingAlgorithm(Func<int[], int[]> sortingAlgorithm, int[] cant)
{
    foreach (int cantidad in cant)
    {
        int[] array = GenerateArray(cantidad);

        Console.WriteLine($"Array de tamaño {cantidad}:");

        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var result = sortingAlgorithm(array);
        stopwatch.Stop();

        var tiempoDeEjecucion = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Tiempo de ejecución: {tiempoDeEjecucion} ms");
        Console.WriteLine();
    }
}

int[] cant = { 100, 5000, 10000, 40000 };

Console.WriteLine("Analizando algoritmos de ordenamiento...");
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Bubble Sort:");
AnalyzeSortingAlgorithm(BubbleSort.Sort, cant);
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Heap Sort:");
AnalyzeSortingAlgorithm(HeapSort.Sort, cant);
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Insertion Sort:");
AnalyzeSortingAlgorithm(InsertionSort.Sort, cant);
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Merge Sort:");
AnalyzeSortingAlgorithm(MergeSort.Sort, cant);
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Quick Sort:");
AnalyzeSortingAlgorithm(QuickSort.Sort, cant);
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Seleccion Sort:");
AnalyzeSortingAlgorithm(SelectionSort.Sort, cant);
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Fin de la ejecución.");