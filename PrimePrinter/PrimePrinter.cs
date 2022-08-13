using System.Diagnostics;

public class PrimePrinterHelper
{
    private int[] primes = new int[numberOfPrimes + 1];
    private int pagenumber;
    private int pageoffset;
    private int rowoffset;
    private int column;
    private int cacndidate;
    private int primeIndex;
    private bool possiblyPrime;
    private int ord;
    private int square;
    private int N;
    private int[] multiples = new int[Ordmax + 1];
    private const int numberOfPrimes = 1000;
    private const int linesPerPage = 50;
    private const int columns = 4;
    private const int Ordmax = 30;

    public void primeMethod()
    {
        N = 0;

        cacndidate = 1;
        primeIndex = 1;
        primes[1] = 2;
        ord = 2;
        square = 9;

        while (primeIndex < numberOfPrimes)
        {
            do
            {
                cacndidate += 2;
                if (cacndidate == square)
                {
                    ord++;
                    square = primes[ord] * primes[ord];
                    multiples[ord - 1] = cacndidate;
                }

                N = 2;
                possiblyPrime = true;
                while (N < ord && possiblyPrime)
                {
                    while (multiples[N] < cacndidate)
                        multiples[N] += primes[N] + primes[N];
                    if (multiples[N] == cacndidate)
                        possiblyPrime = false;
                    N++;
                }
            } while (!possiblyPrime);

            primeIndex++;
            primes[primeIndex] = cacndidate;
        }

        pagenumber = 1;
        pageoffset = 1;
        while (pageoffset <= numberOfPrimes)
        {
            Console.Write("The First ");
            Console.Write(numberOfPrimes);
            Console.Write(" Prime Numbers --- Page ");
            Console.Write(pagenumber);
            Console.WriteLine("\n");
            for (rowoffset = pageoffset; rowoffset <= pageoffset + linesPerPage - 1; rowoffset++)
            {
                for (column = 0; column <= columns - 1; column++)
                    if (rowoffset + column * linesPerPage <= numberOfPrimes)
                        Console.Write("{0} ", primes[rowoffset + column * linesPerPage]);
                Console.WriteLine();
            }

            Console.WriteLine("");

            pagenumber++;
            pageoffset += linesPerPage * columns;
        }
    }
}

public class PrimePrinter
{
    public static void Main(string[] args)
    {
        PrimePrinterHelper printerHelper = new PrimePrinterHelper();
        printerHelper.primeMethod();
    }
}