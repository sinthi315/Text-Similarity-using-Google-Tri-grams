using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace Islam_Milios
{
    static class StopwordTool
    {
        static Dictionary<string, bool> _stops = new Dictionary<string, bool>
        {
            { "a", true },
            { "about", true },
            { "above", true },
            { "across", true },
            { "after", true },
            { "afterwards", true },
            { "again", true },
            { "against", true },
            { "all", true },
            { "almost", true },
            { "alone", true },
            { "along", true },
            { "already", true },
            { "also", true },
            { "although", true },
            { "always", true },
            { "am", true },
            { "amn't", true },
            { "amnt", true },
            { "among", true },
            { "amongst", true },
            { "amoungst", true },
            { "amount", true },
            { "an", true },
            { "and", true },
            { "another", true },
            { "any", true },
            { "anyhow", true },
            { "anyone", true },
            { "anything", true },
            { "anyway", true },
            { "anywhere", true },
            { "are", true },
            { "aren't", true },
            { "arent", true },
            { "around", true },
            { "as", true },
            { "at", true },
            { "back", true },
            { "be", true },
            { "became", true },
            { "because", true },
            { "become", true },
            { "becomes", true },
            { "becoming", true },
            { "been", true },
            { "before", true },
            { "beforehand", true },
            { "behind", true },
            { "being", true },
            { "below", true },
            { "beside", true },
            { "besides", true },
            { "between", true },
            { "beyond", true },
            { "bill", true },
            { "both", true },
            { "bottom", true },
            { "but", true },
            { "by", true },
            { "call", true },
            { "can", true },
            { "cannot", true },
            { "cant", true },
            { "can't", true },
            { "cann't", true },
            { "co", true },
            { "computer", true },
            { "con", true },
            { "could", true },
            { "couldnt", true },
            { "couldn't", true },
            { "cry", true },
            { "de", true },
            { "describe", true },
            { "detail", true },
            { "do", true },
            { "don't", true },
            { "dont", true },
            { "does", true },
            { "doesn't", true },
            { "did", true },
            { "didn't", true },
            { "done", true },
            { "down", true },
            { "due", true },
            { "during", true },
            { "each", true },
            { "eg", true },
            { "eg.", true },
            { "e.g.", true },
            { "eight", true },
            { "either", true },
            { "eleven", true },
            { "else", true },
            { "elsewhere", true },
            { "empty", true },
            { "enough", true },
            { "etc", true },
            { "etc.", true },
            { "even", true },
            { "ever", true },
            { "every", true },
            { "everyone", true },
            { "everything", true },
            { "everywhere", true },
            { "except", true },
            { "few", true },
            { "fifteen", true },
            { "fify", true },
            { "fill", true },
            { "find", true },
            { "fire", true },
            { "first", true },
            { "five", true },
            { "for", true },
            { "former", true },
            { "formerly", true },
            { "forty", true },
            { "found", true },
            { "four", true },
            { "from", true },
            { "front", true },
            { "full", true },
            { "further", true },
            { "get", true },
            { "give", true },
            { "go", true },
            { "had", true },
            { "hadn't", true },
            { "hadnt", true },
            { "has", true },
            { "hasnt", true },
            { "hasn't", true },
            { "have", true },
            { "haven't", true },
            { "havent", true },
            { "he", true },
            { "he's", true },
            { "hence", true },
            { "her", true },
            { "here", true },
            { "hereafter", true },
            { "hereby", true },
            { "herein", true },
            { "hereupon", true },
            { "hers", true },
            { "herself", true },
            { "him", true },
            { "himself", true },
            { "his", true },
            { "how", true },
            { "however", true },
            { "hundred", true },
            { "i", true },
            { "i'm", true },
            { "ie", true },
            { "i.e.", true },
            { "ie.", true },
            { "if", true },
            { "in", true },
            { "inc", true },
            { "indeed", true },
            { "interest", true },
            { "into", true },
            { "is", true },
            { "isn't", true },
            { "isnt", true },
            { "it", true },
            { "its", true },
            { "it's", true },
            { "it'd", true },
            { "it'll", true },
            { "itself", true },
            { "keep", true },
            { "last", true },
            { "latter", true },
            { "latterly", true },
            { "least", true },
            { "less", true },
            { "ltd", true },
            { "ltd.", true },
            { "made", true },
            { "many", true },
            { "may", true },
            { "me", true },
            { "meanwhile", true },
            { "might", true },
            { "mill", true },
            { "mine", true },
            { "more", true },
            { "moreover", true },
            { "most", true },
            { "mostly", true },
            { "move", true },
            { "much", true },
            { "must", true },
            { "my", true },
            { "myself", true },
            { "name", true },
            { "namely", true },
            { "neither", true },
            { "never", true },
            { "nevertheless", true },
            { "next", true },
            { "nine", true },
            { "no", true },
            { "nobody", true },
            { "none", true },
            { "noone", true },
            { "nor", true },
            { "not", true },
            { "n't", true },
            { "nothing", true },
            { "now", true },
            { "nowhere", true },
            { "of", true },
            { "off", true },
            { "often", true },
            { "on", true },
            { "once", true },
            { "one", true },
            { "only", true },
            { "onto", true },
            { "or", true },
            { "other", true },
            { "others", true },
            { "other's", true },
            { "otherwise", true },
            { "our", true },
            { "ours", true },
            { "our's", true },
            { "ourselves", true },
            { "out", true },
            { "over", true },
            { "own", true },
            { "part", true },
            { "per", true },
            { "perhaps", true },
            { "please", true },
            { "put", true },
            { "rather", true },
            { "re", true },
            { "re.", true },
            { "same", true },
            { "see", true },
            { "seem", true },
            { "seemed", true },
            { "seeming", true },
            { "seems", true },
            { "serious", true },
            { "several", true },
            { "she", true },
            { "should", true },
            { "show", true },
            { "side", true },
            { "since", true },
            { "sincere", true },
            { "six", true },
            { "sixty", true },
            { "so", true },
            { "some", true },
            { "somehow", true },
            { "someone", true },
            { "something", true },
            { "sometime", true },
            { "sometimes", true },
            { "somewhere", true },
            { "still", true },
            { "such", true },
            { "system", true },
            { "take", true },
            { "ten", true },
            { "than", true },
            { "that", true },
            { "that's", true },
            { "the", true },
            { "their", true },
            { "theirs", true },
            { "their's", true },
            { "them", true },
            { "themselves", true },
            { "then", true },
            { "thence", true },
            { "there", true },
            { "thereafter", true },
            { "thereby", true },
            { "therefore", true },
            { "therein", true },
            { "thereupon", true },
            { "these", true },
            { "they", true },
            { "they're", true },
            { "they'll", true },
            { "they've", true },
            { "they'd", true },
            { "thick", true },
            { "thin", true },
            { "third", true },
            { "this", true },
            { "those", true },
            { "though", true },
            { "three", true },
            { "through", true },
            { "throughout", true },
            { "thru", true },
            { "thus", true },
            { "to", true },
            { "together", true },
            { "too", true },
            { "top", true },
            { "toward", true },
            { "towards", true },
            { "twelve", true },
            { "twenty", true },
            { "two", true },
            { "un", true },
            { "under", true },
            { "until", true },
            { "up", true },
            { "upon", true },
            { "us", true },
            { "very", true },
            { "via", true },
            { "was", true },
            { "we", true },
            { "well", true },
            { "were", true },
            { "what", true },
            { "whatever", true },
            { "when", true },
            { "whence", true },
            { "whenever", true },
            { "where", true },
            { "whereafter", true },
            { "whereas", true },
            { "whereby", true },
            { "wherein", true },
            { "whereupon", true },
            { "wherever", true },
            { "whether", true },
            { "which", true },
            { "while", true },
            { "whither", true },
            { "who", true },
            { "whoever", true },
            { "whole", true },
            { "whom", true },
            { "whose", true },
            { "why", true },
            { "will", true },
            { "won't", true },
            { "with", true },
            { "within", true },
            { "without", true },
            { "would", true },
            { "yet", true },
            { "you", true },
            { "you'll", true },
            { "you're", true },
            { "you'd", true },
            { "your", true },
            { "yours", true },
            { "your's", true },
            { "yourself", true },
            { "yourselves", true }
        };

        static char[] _delimiters = new char[]
        {
            ' ',
            ',',
            ';',
            '.',
            '?',
            '-',
            '[',
            ']',
            '(',
            ')'
        };

        public static string RemoveStopwords(string input)
        {
            var words = input.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries);

            var found = new Dictionary<string, bool>();

            StringBuilder builder = new StringBuilder();

            foreach (string currentWord in words)
            {
                string lowerWord = currentWord.ToLower();
                if (!_stops.ContainsKey(lowerWord) && !found.ContainsKey(lowerWord))
                {
                    builder.Append(currentWord).Append(' ');
                    found.Add(lowerWord, true);
                }
            }
            return builder.ToString().Trim();
        }
    }
    public enum EmptyLineBehavior
    {
        /// <summary>
        /// Empty lines are interpreted as a line with zero columns.
        /// </summary>
        NoColumns,
        /// <summary>
        /// Empty lines are interpreted as a line with a single empty column.
        /// </summary>
        EmptyColumn,
        /// <summary>
        /// Empty lines are skipped over as though they did not exist.
        /// </summary>
        Ignore,
        /// <summary>
        /// An empty line is interpreted as the end of the input file.
        /// </summary>
        EndOfFile,
    }
    /// <summary>
    /// Common base class for CSV reader and writer classes.
    /// </summary>
    public abstract class CsvFileCommon
    {
        /// <summary>
        /// These are special characters in CSV files. If a column contains any
        /// of these characters, the entire column is wrapped in double quotes.
        /// </summary>
        protected char[] SpecialChars = new char[] { ',', '"', '\r', '\n' };

        // Indexes into SpecialChars for characters with specific meaning
        private const int DelimiterIndex = 0;
        private const int QuoteIndex = 1;

        /// <summary>
        /// Gets/sets the character used for column delimiters.
        /// </summary>
        public char Delimiter
        {
            get { return SpecialChars[DelimiterIndex]; }
            set { SpecialChars[DelimiterIndex] = value; }
        }

        /// <summary>
        /// Gets/sets the character used for column quotes.
        /// </summary>
        public char Quote
        {
            get { return SpecialChars[QuoteIndex]; }
            set { SpecialChars[QuoteIndex] = value; }
        }
    }
    /// <summary>
    /// Class for reading from comma-separated-value (CSV) files
    /// </summary>
    public class CsvFileReader : CsvFileCommon, IDisposable
    {
        // Private members
        private StreamReader Reader;
        private string CurrLine;
        private int CurrPos;
        private EmptyLineBehavior EmptyLineBehavior;

        /// <summary>
        /// Initializes a new instance of the CsvFileReader class for the
        /// specified stream.
        /// </summary>
        /// <param name="stream">The stream to read from</param>
        /// <param name="emptyLineBehavior">Determines how empty lines are handled</param>
        public CsvFileReader(Stream stream,
            EmptyLineBehavior emptyLineBehavior = EmptyLineBehavior.NoColumns)
        {
            Reader = new StreamReader(stream);
            EmptyLineBehavior = emptyLineBehavior;
        }

        /// <summary>
        /// Initializes a new instance of the CsvFileReader class for the
        /// specified file path.
        /// </summary>
        /// <param name="path">The name of the CSV file to read from</param>
        /// <param name="emptyLineBehavior">Determines how empty lines are handled</param>
        public CsvFileReader(string path,
            EmptyLineBehavior emptyLineBehavior = EmptyLineBehavior.NoColumns)
        {
            Reader = new StreamReader(path);
            EmptyLineBehavior = emptyLineBehavior;
        }

        /// <summary>
        /// Reads a row of columns from the current CSV file. Returns false if no
        /// more data could be read because the end of the file was reached.
        /// </summary>
        /// <param name="columns">Collection to hold the columns read</param>
        public bool ReadRow(List<string> columns)
        {
            // Verify required argument
            if (columns == null)
                throw new ArgumentNullException("columns");

            ReadNextLine:
            // Read next line from the file
            CurrLine = Reader.ReadLine();
            CurrPos = 0;
            // Test for end of file
            if (CurrLine == null)
                return false;
            // Test for empty line
            if (CurrLine.Length == 0)
            {
                switch (EmptyLineBehavior)
                {
                    case EmptyLineBehavior.NoColumns:
                        columns.Clear();
                        return true;
                    case EmptyLineBehavior.Ignore:
                        goto ReadNextLine;
                    case EmptyLineBehavior.EndOfFile:
                        return false;
                }
            }

            // Parse line
            string column;
            int numColumns = 0;
            while (true)
            {
                // Read next column
                if (CurrPos < CurrLine.Length && CurrLine[CurrPos] == Quote)
                    column = ReadQuotedColumn();
                else
                    column = ReadUnquotedColumn();
                // Add column to list
                if (numColumns < columns.Count)
                    columns[numColumns] = column;
                else
                    columns.Add(column);
                numColumns++;
                // Break if we reached the end of the line
                if (CurrLine == null || CurrPos == CurrLine.Length)
                    break;
                // Otherwise skip delimiter
                Debug.Assert(CurrLine[CurrPos] == Delimiter);
                CurrPos++;
            }
            // Remove any unused columns from collection
            if (numColumns < columns.Count)
                columns.RemoveRange(numColumns, columns.Count - numColumns);
            // Indicate success
            return true;
        }

        /// <summary>
        /// Reads a quoted column by reading from the current line until a
        /// closing quote is found or the end of the file is reached. On return,
        /// the current position points to the delimiter or the end of the last
        /// line in the file. Note: CurrLine may be set to null on return.
        /// </summary>
        private string ReadQuotedColumn()
        {
            // Skip opening quote character
            Debug.Assert(CurrPos < CurrLine.Length && CurrLine[CurrPos] == Quote);
            CurrPos++;

            // Parse column
            StringBuilder builder = new StringBuilder();
            while (true)
            {
                while (CurrPos == CurrLine.Length)
                {
                    // End of line so attempt to read the next line
                    CurrLine = Reader.ReadLine();
                    CurrPos = 0;
                    // Done if we reached the end of the file
                    if (CurrLine == null)
                        return builder.ToString();
                    // Otherwise, treat as a multi-line field
                    builder.Append(Environment.NewLine);
                }

                // Test for quote character
                if (CurrLine[CurrPos] == Quote)
                {
                    // If two quotes, skip first and treat second as literal
                    int nextPos = (CurrPos + 1);
                    if (nextPos < CurrLine.Length && CurrLine[nextPos] == Quote)
                        CurrPos++;
                    else
                        break;  // Single quote ends quoted sequence
                }
                // Add current character to the column
                builder.Append(CurrLine[CurrPos++]);
            }

            if (CurrPos < CurrLine.Length)
            {
                // Consume closing quote
                Debug.Assert(CurrLine[CurrPos] == Quote);
                CurrPos++;
                // Append any additional characters appearing before next delimiter
                builder.Append(ReadUnquotedColumn());
            }
            // Return column value
            return builder.ToString();
        }

        /// <summary>
        /// Reads an unquoted column by reading from the current line until a
        /// delimiter is found or the end of the line is reached. On return, the
        /// current position points to the delimiter or the end of the current
        /// line.
        /// </summary>
        private string ReadUnquotedColumn()
        {
            int startPos = CurrPos;
            CurrPos = CurrLine.IndexOf(Delimiter, CurrPos);
            if (CurrPos == -1)
                CurrPos = CurrLine.Length;
            if (CurrPos > startPos)
                return CurrLine.Substring(startPos, CurrPos - startPos);
            return String.Empty;
        }

        // Propagate Dispose to StreamReader
        public void Dispose()
        {
            Reader.Dispose();
        }
    }

    class Program
    {
        public static List<string> makeNGram(string a)
        {
            List<string> nGram = new List<string>();
            for(int i=0; i < a.Length - 3 + 1; i++)
            {
                nGram.Add(a.Substring(i, 3));
            }
            return nGram;
        }
        public static List<string> makeUniGram(string a)
        {
            List<string> uniGram = new List<string>();
            for (int i = 0; i < a.Length - 1 + 1; i++)
            {
                uniGram.Add(a.Substring(i, 1));
            }
            return uniGram;
        }
        public static double frequency(List<string> a)
        {
            double count = 0;
            List<string> googleNGram = new List<string>();
            List<string> columns = new List<string>();
            using (var reader = new StreamReader(File.OpenRead(@"C:\Users\Musa\Documents\Visual Studio 2015\Projects\Islam_Milios\googlebooks-eng-1M-3gram-20090715-0.csv")))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] values = line.Split(';');
                    foreach (string st in values)
                    {
                        googleNGram.Add(st);
                    }
                }
            }

            foreach (string str in googleNGram)
            {
                foreach(string sr in a)
                {
                    if(str == sr)
                    {
                        count = count + 1;
                        Console.WriteLine(count);
                    }
                }
            }
            Console.WriteLine("returning count: {0}", count);
            return count;
        }
        public static KeyValuePair<double, double> googleUniGramfrequency(List<string> a)
        {
            double count = 0;
            double maximumF;
            List<string> googlUniGram = new List<string>();
            List<string> columns = new List<string>();
            using (var reader = new StreamReader(File.OpenRead(@"C:\Users\Musa\Documents\Visual Studio 2015\Projects\Islam_Milios\googlebooks-eng-1M-1gram-20090715-0.csv")))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] values = line.Split(';');
                    foreach(string st in values)
                    {
                        googlUniGram.Add(st);
                    }
                }
            }

            maximumF = googlUniGram.Count;

            foreach (string str in googlUniGram)
            {
                foreach (string sr in a)
                {
                    if (str==sr)
                    {
                        count = count + 1;
                        Console.WriteLine(count);
                    }
                }
            }
            Console.WriteLine("returning count: {0}", count);
            return new KeyValuePair < double, double> (count, maximumF);
        }
        public static double meu(double a, double b)
        {
            double value = 1 / 2 * (a + b);
            return value;
        }

        public static double Sim(string a, string b)
        {
            double frequency1;
            double frequency2;
            double uniGramFrequency1;
            double uniGramFrequency2;
            double meanFrequency;
            double C;
            double value;
            double value1;
            double SemanticRelatedness = 0.0;
            List<string> ngramA = new List<string>();
            List<string> ngramB = new List<string>();
            List<string> unigramA = new List<string>();
            List<string> unigramB = new List<string>();

            ngramA = makeNGram(a);
            ngramB = makeNGram(b);

            unigramA = makeUniGram(a);
            unigramB = makeUniGram(b);

            frequency1 = frequency(ngramA);
            Console.WriteLine("Frequency1: {0}", frequency1);
            frequency2 = frequency(ngramB);
            Console.WriteLine("Frequency2: {0}", frequency2);
            var pair1 = googleUniGramfrequency(unigramA);
            uniGramFrequency1 = pair1.Key;
            Console.WriteLine("Uni Gram Frequency1: {0}", uniGramFrequency1);
            C = pair1.Value;
            Console.WriteLine("C: {0}", C);
            var pair2 = googleUniGramfrequency(unigramB);
            uniGramFrequency2 = pair2.Key;
            Console.WriteLine("Uni Gram Frequency2: {0}", uniGramFrequency2);
            meanFrequency = meu(frequency1, frequency2);
            value = (meanFrequency * Math.Pow(C, 2)) / (uniGramFrequency1 * uniGramFrequency2 * Math.Min(uniGramFrequency1, uniGramFrequency2));
            value1 = Math.Min(uniGramFrequency1, uniGramFrequency2) / C;
            if (value > 1)
            {
                SemanticRelatedness = Math.Log(value) / (-2 * Math.Log(value1));
            }
            else if(value <= 1)
            {
                SemanticRelatedness = Math.Log(1.01) / (-2 * Math.Log(value1));
            }
            else if(meanFrequency == 0)
            {
                SemanticRelatedness = 0;
            }
            else
            {
                Console.WriteLine("ERROR!");
            }

            return SemanticRelatedness;
        }
        public static double[,] createMatrix(List<string> p, List<string> r)
        {
            double[,] matrix = new double[p.Count(), r.Count()];
            List<double> semanticRelatedness = new List<double>();
            foreach(string a in p)
            {
                foreach(string b in r)
                {
                    semanticRelatedness.Add(Sim(a, b));
                }
            }
            foreach(double value in semanticRelatedness)
            {
                Console.WriteLine("Semantic Relatedness is: {0}", value);
            }

            for (int i = 0; i < p.Count(); i++)
            {
                for (int j = 0; j < r.Count(); j++)
                {
                    matrix[i, j] = semanticRelatedness.ElementAt(i);
                }
            }
            foreach(double value in matrix)
            {
                Console.WriteLine("Matrix is: {0}", value);
            }
            return matrix;
        }
        public static double meanStandardDeviation(double[,] m)
        {
            List<double> matrixValue = new List<double>();
            double mean = 0.0;
            double standardDeviation = 0.0;
            double x = m.Length;
            double y = 0.0;
            for(int i = 0; i < matrixValue.Count; i++)
            {
                for(int j = 0; j < matrixValue.Count; j++)
                {
                    matrixValue.Add(m[i, j]);
                }
            }
            foreach(double value in matrixValue)
            {
                Console.WriteLine("Matrix value: {0}", value);
                mean = 1 / x * (value + mean);
                y = Math.Pow((value - mean), 2) + y;
                standardDeviation = Math.Sqrt(1 / x * y);
                if (value > (mean + standardDeviation))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
            Console.WriteLine("The mean is: {0}", mean);
            Console.WriteLine("The standard deviation is: {0}", standardDeviation);
            return mean;
        }
        public static double step5(double mean, double match, double m, double n)
        {
            double s = ((match + mean) * (m + n)) / (2 * m * n);
            return s;
        }
        static void Main(string[] args)
        {
            string line1;
            string line2;
            double final;
            double M = 0.0;
            string[] splitLine1;
            string[] splitLine2;
            string filteredLine1;
            string filteredLine2;
            List<string> P = new List<string>();
            List<string> R = new List<string>();
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            List<string> intersect = new List<string>();
            FileStream file1 = File.Open("C:\\Users\\Musa\\Documents\\Visual Studio 2015\\Projects\\Islam_Milios\\test1.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BufferedStream bs1 = new BufferedStream(file1);
            StreamReader sr1 = new StreamReader(bs1);

            FileStream file2 = File.Open("C:\\Users\\Musa\\Documents\\Visual Studio 2015\\Projects\\Islam_Milios\\test2.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BufferedStream bs2 = new BufferedStream(file2);
            StreamReader sr2 = new StreamReader(bs2);

            while ((line1 = sr1.ReadLine()) != null)
            {
                filteredLine1 = StopwordTool.RemoveStopwords(line1);
                splitLine1 = filteredLine1.Split(' ');
                for (int i = 0; i < splitLine1.Length; i++)
                {
                    list1.Add(splitLine1[i]);
                }
            }

            file1.Close();

            while ((line2 = sr2.ReadLine()) != null)
            {
                filteredLine2 = StopwordTool.RemoveStopwords(line2);
                splitLine2 = filteredLine2.Split(' ');
                for (int i = 0; i < splitLine2.Length; i++)
                {
                    list2.Add(splitLine2[i]);
                }
            }
            Console.WriteLine("LIST1:");
            foreach(string str in list1)
            {
                Console.WriteLine("{0}", str);
            }
            Console.WriteLine("LIST2:");
            foreach(string s in list2)
            {
                Console.WriteLine("{0}", s);
            }

            double m = list1.Count;
            Console.WriteLine("List1 item count: {0}", m);
            double n = list2.Count;
            Console.WriteLine("List2 item count: {0}", n);

            if (n >= m)
            {
                intersect = list1.Intersect(list2).ToList();
                double matched = intersect.Count;
                Console.WriteLine("Intersect Count: {0}", matched);
                P = list1.Except(intersect).ToList();
                foreach(string value1 in P)
                {
                    Console.WriteLine("Values in P: {0}", value1);
                }
                R = list2.Except(intersect).ToList();
                foreach (string value2 in R)
                {
                    Console.WriteLine("Values in R: {0}", value2);
                }
                if ((m - matched) == 0)
                {
                    final = step5(M, matched, m, n);
                    Console.WriteLine("The Final Similarity is: {0}", final);
                }
                else
                {
                    double[,] matrix = new double[P.Count(), R.Count()];
                    matrix = createMatrix(P, R);
                    M = meanStandardDeviation(matrix);
                    Console.WriteLine("Mean & Standard Deviation: {0}", M);
                    final = step5(M, matched, m, n);
                    Console.WriteLine("The Final Similarity is: {0}", final);
                }
            }
            else
            {
                intersect = list2.Intersect(list1).ToList();
                double matched = intersect.Count;
                Console.WriteLine("Intersect Count: {0}", matched);
                P = list2.Except(intersect).ToList();
                foreach (string value3 in P)
                {
                    Console.WriteLine("Values in P: {0}", value3);
                }
                R = list1.Except(intersect).ToList();
                foreach (string value4 in R)
                {
                    Console.WriteLine("Values in R: {0}", value4);
                }
                if ((m - matched) == 0)
                {
                    final = step5(M, matched, m, n);
                    Console.WriteLine("The Final Similarity is: {0}", final);
                }
                else
                {
                    double[,] matrix = new double[P.Count(), R.Count()];
                    matrix = createMatrix(P, R);
                    M = meanStandardDeviation(matrix);
                    Console.WriteLine("Mean & Standard Deviation: {0}", M);
                    final = step5(M, matched, m, n);
                    Console.WriteLine("The Final Similarity is: {0}", final);
                }
            }
        }
    }
}
