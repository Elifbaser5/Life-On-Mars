using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Net;

namespace proje_DNA
{
    internal class Program
    {
        static char[] StringToCharArray(string str)
        {
            char[] a = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                a[i] = str[i];
            }
            return a;
        }

        static string[] CharArrToStrArr(char[] a)
        {
            string[] array = new string[a.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToString(a[3 * i]) + Convert.ToString(a[3 * i + 1]) + Convert.ToString(a[3 * i + 2]);
            }
            return array;

        }
        static string Console_print(string a)
        {
            int c = 0;
            char[] b = new char[a.Length];
            b = StringToCharArray(a);
            for (int i = 0; i <= (b.Length/3); i++)
            {
                try
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(b[c]);
                        c++;
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    continue;
                }
                Console.Write(" ");
            }
            Console.WriteLine();
            return a;
        }
        
        static void Main(string[] args)
        {
            string dna1 = "";
            string dna2 = "";
            string dna3 = "";
            char[] dnafirst = { ' ' };
            string dnastring = "";
            int opr = 0;
            int opr1 = 0;
            do
            {
                Console.WriteLine("<--------------------MENU-------------------->"
                             + "\n1-  LOAD DNA SEQUENCE FROM A FILE "
                             + "\n2-  LOAD DNA SEQUENCE FROM A STRING"
                             + "\n3-  GENERATE RANDOM DNA FOR BLOB"
                             + "\n0-  EXİT"
                             + "\n<-------------------------------------------->");

                Console.Write("Please select the operation you want to do:");
                opr = Convert.ToInt32(Console.ReadLine());
                switch (opr)
                {
                    case 1:
                        {
                            Console.Write("Please choose DNA strand (1,2,3):");
                            string strand = Console.ReadLine();
                            Console.Write("Please enter file name:");
                            string filename = Console.ReadLine();
                            StreamReader sw = File.OpenText("C:\\" + filename);
                            dna1 = sw.ReadLine();
                            dna2 = sw.ReadLine();
                            dna3 = sw.ReadLine();

                            if (strand == "1")
                            {
                                dnastring = dna1;
                                dnafirst = new char[dna1.Length];
                                for (int i = 0; i < dna1.Length; i++)
                                {
                                    dnafirst[i] = dna1[i];
                                }
                                Console_print(dna1);
                            }
                            else if (strand == "2")
                            {
                                dnastring = dna2;
                                dnafirst = new char[dna2.Length];
                                for (int i = 0; i < dna2.Length; i++)
                                {
                                    dnafirst[i] = dna2[i];
                                }
                                Console_print(dna2);
                            }
                            else
                            {
                                dnastring= dna3;
                                dnafirst = new char[dna3.Length];
                                for (int i = 0; i < dna3.Length; i++)
                                {
                                    dnafirst[i] = dna3[i];
                                }
                                Console_print(dna3);
                            }
                            sw.Close();
                            break;
                        }

                    case 2:
                        {
                            Console.Write("Please choose DNA strand (1,2,3):");
                            string strand = Console.ReadLine();
                            if (strand == "1")
                            {
                                Console.Write("Please enter DNA strand 1: ");
                                dna1 = Console.ReadLine();
                                dnastring = dna1;
                                dnafirst = new char[dna1.Length];
                                for (int i = 0; i < dna1.Length; i++)
                                {
                                    dnafirst[i] = dna1[i];
                                }
                                Console_print(dna1);
                            }
                            else if (strand == "2")
                            {
                                Console.Write("Please enter DNA strand 2: ");
                                dna2 = Console.ReadLine();
                                dnastring = dna2;
                                dnafirst = new char[dna2.Length];
                                for (int i = 0; i < dna2.Length; i++)
                                {
                                    dnafirst[i] = dna2[i];
                                }
                                Console_print(dna2);
                            }
                            else
                            {
                                Console.Write("Please enter DNA strand 3: ");
                                dna3 = Console.ReadLine();
                                dnastring= dna3;
                                dnafirst = new char[dna3.Length];
                                for (int i = 0; i < dna3.Length; i++)
                                {
                                    dnafirst[i] = dna3[i];
                                }
                                Console_print(dna3);
                            }
                            break;
                        }

                    case 3:
                        {
                            char[] nucleotids = new char[] { 'A', 'T', 'G', 'C' };
                            Random rstgl = new Random();
                            int sayaçcodon = rstgl.Next(0, 6);
                            int sayaçgene = rstgl.Next(1, 7);
                            string BLOB1()
                            {
                                int i = 1;
                                while (i <= sayaçcodon)
                                {
                                    
                                    int createNuc1 = rstgl.Next(0, nucleotids.Length);
                                    int createNuc2 = rstgl.Next(0, nucleotids.Length);
                                    int createNuc3 = rstgl.Next(0, nucleotids.Length);
                                    if (((createNuc1 == 0) && (createNuc2 == 1) && (createNuc3 == 2)) || ((createNuc1 == 1) && (createNuc2 == 0) && (createNuc3 == 2)) || ((createNuc1 == 1) && (createNuc2 == 2) && (createNuc3 == 0)) || ((createNuc1 == 1) && (createNuc2 == 0) && (createNuc3 == 0)))
                                    {
                                        createNuc1 = rstgl.Next(0, nucleotids.Length);
                                        createNuc2 = rstgl.Next(0, nucleotids.Length);
                                        createNuc3 = rstgl.Next(0, nucleotids.Length);
                                        Console.Write(nucleotids[createNuc1]);
                                        Console.Write(nucleotids[createNuc2]);
                                        Console.Write(nucleotids[createNuc3]);
                                    }
                                    else
                                    {
                                        Console.Write(nucleotids[createNuc1]);
                                        Console.Write(nucleotids[createNuc2]);
                                        Console.Write(nucleotids[createNuc3]);
                                    }
                                    i++;
                                }
                                return null;
                            }

                            string[] blob = new string[] { "ATGAAATTTTAG", "ATGTTTAAATAG", "ATGTTTTTTTAG", "ATGAAAAAATAG", "ATGTTTCCCTAG", "ATGGGGAAATAG", "ATGGGGTTTTAG", "ATGTTTGGGTAG", "ATGCCCAAATAG", "ATGAAAGGGTAG", "ATGAAACCCTAG" };
                            int nblob = rstgl.Next(0, blob.Length);

                            // BLOB DNA:nfemale | nmale + "ATG" + WHILE DONGUSU + stopr
                            
                            Console.Write(blob[nblob]);
                            int p = 1;
                            while (p <= sayaçgene)
                            {
                                string[] stop = new string[] { "TAA", "TGA", "TAG" };
                                int stopr = rstgl.Next(0, stop.Length);

                                Console.Write("ATG");
                                BLOB1();
                                Console.Write(stop[stopr]);
                                p++;
                            }
                            dnastring = Console.ReadLine();
                            dnafirst = new char[dnastring.Length];
                            for (int b = 0; b < dnastring.Length; b++)
                            { dnafirst[b] = dnastring[b]; }
                            Console_print(dnastring);

                            if (nblob == 0 || nblob == 1 || nblob == 2)
                            {
                                Console.WriteLine("The BLOB1 is female.");
                            }
                            else
                                Console.WriteLine("The BLOB1 is male.");
                            break;
                        }
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        break;
                }
                do
                {
                    Console.WriteLine("<--------------------MENU-------------------->"
                             + "\n4-  CHECK DNA GENE STRUCTURE"
                             + "\n5-  CHECK DNA OF BLOB"
                             + "\n6-  PRODUCE COMPLEMENT"
                             + "\n7-  DETERMINE AMINO ACIDS"
                             + "\n8-  DELETE CODONS"
                             + "\n9-  INSERT CODOONS"
                             + "\n10- FIND CODONS"
                             + "\n11- REVERSE CODONS"
                             + "\n12- NUMBER OF GENES IN A DNA"
                             + "\n13- SHORTEST GENE IN DNA"
                             + "\n14- LONGEST GENE IN DNA"
                             + "\n15- THE MOST REPEATED NUCLEOTIDE SEQUENCE"
                             + "\n16- HYDROGEN BOND STATISTICS"
                             + "\n17- BLOB GENERATION SIMULATION"
                             + "\n0-  EXİT"
                             + "\n<-------------------------------------------->");
                    Console.Write("Please select the operation you want to do:");
                    opr1 = Convert.ToInt32(Console.ReadLine());
                    switch (opr1)
                    {
                        case 4:
                            {
                                Console_print(dnastring);
                                int np = 0;
                                int error1 = 0;
                                int error2 = 0;
                                int error3 = (dnafirst.Length % 3);
                                int sayac = 0;
                                int gender = 0;
                                int notaBLOB = 0;

                                //is there any sex gene or not control
                                if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'A' && dnafirst[4] == 'A' && dnafirst[5] == 'A' && dnafirst[6] == 'T' && dnafirst[7] == 'T' && dnafirst[8] == 'T' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { gender = 1; }
                                else if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'T' && dnafirst[4] == 'T' && dnafirst[5] == 'T' && dnafirst[6] == 'A' && dnafirst[7] == 'A' && dnafirst[8] == 'A' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { gender = 1; }
                                else if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'T' && dnafirst[4] == 'T' && dnafirst[5] == 'T' && dnafirst[6] == 'T' && dnafirst[7] == 'T' && dnafirst[8] == 'T' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { gender = 1; }
                                else if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'T' && dnafirst[4] == 'T' && dnafirst[5] == 'T' && dnafirst[6] == 'C' && dnafirst[7] == 'C' && dnafirst[8] == 'C' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { gender = 1; }
                                else if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'G' && dnafirst[4] == 'G' && dnafirst[5] == 'G' && dnafirst[6] == 'A' && dnafirst[7] == 'A' && dnafirst[8] == 'A' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { gender = 1; }
                                else if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'G' && dnafirst[4] == 'G' && dnafirst[5] == 'G' && dnafirst[6] == 'T' && dnafirst[7] == 'T' && dnafirst[8] == 'T' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { gender = 1; }
                                else { notaBLOB = 1; }

                                //codon control
                                for (int i = 3; i < dnafirst.Length - 3; i = i + 3)
                                {
                                    if ((dnafirst[i] == 'A' && dnafirst[i + 1] == 'T' && dnafirst[i + 2] == 'G') || ((dnafirst[i] == 'T' && dnafirst[i + 1] == 'A' && dnafirst[i + 2] == 'A') || (dnafirst[i] == 'T' && dnafirst[i + 1] == 'G' && dnafirst[i + 2] == 'A') || (dnafirst[i] == 'T' && dnafirst[i + 1] == 'A' && dnafirst[i + 2] == 'G')))
                                    { sayac += 1; }
                                }
                                if (dnafirst.Length % 3 != 0)
                                { error2++; }

                                //outputs
                                if ((dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G') && ((dnafirst[dnafirst.Length - 1] == 'A' && dnafirst[dnafirst.Length - 2] == 'A' && dnafirst[dnafirst.Length - 3] == 'T') || (dnafirst[dnafirst.Length - 1] == 'A' && dnafirst[dnafirst.Length - 2] == 'G' && dnafirst[dnafirst.Length - 3] == 'T') || (dnafirst[dnafirst.Length - 1] == 'G' && dnafirst[dnafirst.Length - 2] == 'A' && dnafirst[dnafirst.Length - 3] == 'T')))
                                {
                                    for (int i = 3; i < dnafirst.Length - 3; i = i + 3)
                                    {
                                        if ((dnafirst[i] == 'T' && dnafirst[i + 1] == 'A' && dnafirst[i + 2] == 'A') || (dnafirst[i] == 'T' && dnafirst[i + 1] == 'G' && dnafirst[i + 2] == 'A') || (dnafirst[i] == 'T' && dnafirst[i + 1] == 'A' && dnafirst[i + 2] == 'G'))
                                        {
                                            if ((dnafirst[i + 3] == 'A' && dnafirst[i + 4] == 'T' && dnafirst[i + 5] == 'G') && (gender == 1))
                                            { Console.WriteLine("DNA Strand is Okey! -And it is a BLOB DNA!-"); }
                                            else if ((dnafirst[i + 3] == 'A' && dnafirst[i + 4] == 'T' && dnafirst[i + 5] == 'G') && (notaBLOB == 1))
                                            { Console.WriteLine("DNA Strand is Okey! -It is Not a BLOB DNA but it is Okey!-"); }
                                            else
                                            { error1++; }
                                        }
                                        else if (sayac == 0)
                                        {
                                            np = np + 1;
                                            if ((np == dnafirst.Length / 3 - 2) && (gender == 1))
                                            { Console.WriteLine("DNA Strand is Okay! -And it is a BLOB DNA!-"); }
                                            else if ((np == dnafirst.Length / 3 - 2) && (notaBLOB == 1))
                                            {
                                                Console.WriteLine("DNA Strand is Okey!");
                                            }
                                            else if ((dnafirst[i + 3] == 'A' && dnafirst[i + 4] == 'T' && dnafirst[i + 5] == 'G') && (notaBLOB == 1))
                                            { Console.WriteLine("DNA Strand is Okey! -It is Not a BLOB DNA but it is Okey!-"); }
                                        }
                                        else if (dnafirst[3] == 'A' && dnafirst[4] == 'T' && dnafirst[5] == 'G')
                                        { error1++; }
                                    }
                                }
                                else
                                { error1++; }
                                if ((error1 != 0) && (error3 == 0))
                                { Console.WriteLine("Gene structure Error."); }
                                else if ((error2 != 0) || (error3 != 0))
                                { Console.WriteLine("Codon structure Error."); }
                                Console.ReadKey();
                                break;
                            }

                        case 5:
                            {
                                Console_print(dnastring);
                                //input and variables
                                int error1 = 0;
                                int error2 = 0;
                                int sayacatg = 0;
                                int sayacend = 0;

                                //Number of codons control
                                for (int z = 0; z <= dnafirst.Length - 2; z = z + 3)
                                {
                                    if (dnafirst[z] == 'A' && dnafirst[z + 1] == 'T' && dnafirst[z + 2] == 'G')
                                    {
                                        if (dnafirst[z + 3] == 'T' && dnafirst[z + 4] == 'A' && dnafirst[z + 5] == 'A')
                                        { error1 += 1; }
                                        else if (dnafirst[z + 3] == 'T' && dnafirst[z + 4] == 'G' && dnafirst[z + 5] == 'A')
                                        { error1 += 1; }
                                        else if (dnafirst[z] == 'T' && dnafirst[z + 1] == 'A' && dnafirst[z + 2] == 'G')
                                        { error1 += 1; }
                                        else
                                        { error1 = 0; }
                                    }
                                }

                                //start and finish of each gene control
                                for (int z = 0; z <= dnafirst.Length - 2; z = z + 3)
                                {
                                    if (dnafirst[z] == 'A' && dnafirst[z + 1] == 'T' && dnafirst[z + 2] == 'G')
                                    { sayacatg += 1; }
                                    else if ((dnafirst[z] == 'T' && dnafirst[z + 1] == 'A' && dnafirst[z + 2] == 'A') || (dnafirst[z] == 'T' && dnafirst[z + 1] == 'G' && dnafirst[z + 2] == 'A') || (dnafirst[z] == 'T' && dnafirst[z + 1] == 'A' && dnafirst[z + 2] == 'G'))
                                    { sayacend += 1; }
                                }

                                //sex control
                                if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'A' && dnafirst[4] == 'A' && dnafirst[5] == 'A' && dnafirst[6] == 'T' && dnafirst[7] == 'T' && dnafirst[8] == 'T' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { error2 = 0; }
                                else if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'T' && dnafirst[4] == 'T' && dnafirst[5] == 'T' && dnafirst[6] == 'A' && dnafirst[7] == 'A' && dnafirst[8] == 'A' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { error2 = 0; }
                                else if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'T' && dnafirst[4] == 'T' && dnafirst[5] == 'T' && dnafirst[6] == 'T' && dnafirst[7] == 'T' && dnafirst[8] == 'T' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { error2 = 0; }
                                else if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'T' && dnafirst[4] == 'T' && dnafirst[5] == 'T' && dnafirst[6] == 'C' && dnafirst[7] == 'C' && dnafirst[8] == 'C' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { error2 = 0; }
                                else if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'G' && dnafirst[4] == 'G' && dnafirst[5] == 'G' && dnafirst[6] == 'A' && dnafirst[7] == 'A' && dnafirst[8] == 'A' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { error2 = 0; }
                                else if (dnafirst[0] == 'A' && dnafirst[1] == 'T' && dnafirst[2] == 'G' && dnafirst[3] == 'G' && dnafirst[4] == 'G' && dnafirst[5] == 'G' && dnafirst[6] == 'T' && dnafirst[7] == 'T' && dnafirst[8] == 'T' && dnafirst[9] == 'T' && dnafirst[10] == 'A' && dnafirst[11] == 'G')
                                { error2 = 0; }
                                else
                                { error2 += 1; }

                                //outputs
                                if (error2 == 0)
                                {
                                    if ((sayacatg == sayacend) && (error1 == 0) && (sayacatg != 1 && sayacend != 1))
                                    { Console.WriteLine("BLOB is Okey!"); }
                                    else if (error1 != 0)
                                    { Console.WriteLine("Number of Codons Error."); }
                                    else
                                    { Console.WriteLine("Number of Genes Error."); }
                                }
                                else if ((error2 != 0) && ((sayacatg != sayacend) || (sayacatg == 1 && sayacend == 1)))
                                { Console.WriteLine("Gender error. Number of Genes Error."); }
                                else if (error2 != 0 && (error1 != 0))
                                { Console.WriteLine("Gender error. Number of Codon Error."); }
                                else
                                { Console.WriteLine("Gender Error."); }
                                Console.ReadKey();
                                break;
                            }

                        case 6:
                            {
                                Console_print(dnastring);
                                for (int i = 0; i < dnafirst.Length; i++)
                                {
                                    if (dnafirst[i] == 'A')
                                    {
                                        Console.Write('T');
                                        
                                    }

                                    else if (dnafirst[i] == 'C')
                                    {
                                        Console.Write('G');
                                        
                                    }

                                    else if (dnafirst[i] == 'G')
                                    {
                                        Console.Write('C');
                                        
                                    }

                                    else if (dnafirst[i] == 'T')
                                    {
                                        Console.Write('A');
                                        

                                    }
                                    if (dnafirst[i] == ' ')
                                    {
                                        Console.Write(' ');
                                       
                                    }
                                    

                                }
                                Console.ReadLine();
                                break;
                            }

                        case 7:
                            {
                                Console_print(dnastring);
                                string[] codons = { "GCT", "GCC", "GCA", "GCG", "CGT", "CGC", "CGA", "CGG", "AGA", "AGG", "AAT", "AAC", "GAT", "GAC", "TGT", "TGC", "CAA", "CAG", "GAA", "GAG", "GGT", "GGC", "GGA", "GGG", "CAT", "CAC", "ATT", "ATC", "ATA", "CTT", "CTC", "CTA", "CTG", "TTA", "TTG", "AAA", "AAG", "ATG", "TTT", "TTC", "CCT", "CCC", "CCA", "CCG", "TCT", "TCC", "TCA", "TCG", "AGT", "AGC", "ACT", "ACC", "ACA", "ACG", "TGG", "TAT", "TAC", "GTT", "GTC", "GTA", "GTG", "TAA", "TGA", "TAG" };
                                string[] aminoacids = { "ala", "ala", "ala", "ala", "arg", "arg", "arg", "arg", "arg", "arg", "asn", "asn", "asp", "asp", "cys", "cys", "gln", "gln", "glu", "glu", "gly", "gly", "gly", "gly", "his", "his", "ile", "ile", "ile", "leu", "leu", "leu", "leu", "leu", "leu", "lys", "lys", "met", "phe", "phe", "pro", "pro", "pro", "pro", "ser", "ser", "ser", "ser", "ser", "ser", "thr", "thr", "thr", "thr", "trp", "tyr", "tyr", "val", "val", "val", "val", "stop", "stop", "stop" };



                                for (int i = 0; i < dnafirst.Length; i = i + 3)
                                {
                                    string codon = "";
                                    for (int j = i; j < i + 3; j++)
                                        codon = codon + dnafirst[j];

                                    for (int j = 0; j < codons.Length; j++)
                                    {
                                        if (codon == codons[j])
                                            if (j <= 3)
                                                Console.Write(aminoacids[0] + " ");//ala


                                            else if (j > 3 & j <= 9)
                                                Console.Write(aminoacids[4] + " ");//arg


                                            else if (j > 9 & j <= 11)
                                                Console.Write(aminoacids[10] + " ");//asn


                                            else if (j > 11 & j <= 13)
                                                Console.Write(aminoacids[12] + " ");//asp


                                            else if (j > 13 & j <= 15)
                                                Console.Write(aminoacids[14] + " ");//cys

                                            else if (j > 15 & j <= 17)
                                                Console.Write(aminoacids[16] + " ");//gln

                                            else if (j > 17 & j <= 19)
                                                Console.Write(aminoacids[18] + " ");//glu

                                            else if (j > 19 & j <= 23)
                                                Console.Write(aminoacids[20] + " ");//gly

                                            else if (j > 23 & j <= 25)
                                                Console.Write(aminoacids[24] + " ");//his

                                            else if (j > 25 & j <= 28)
                                                Console.Write(aminoacids[26] + " ");//ile

                                            else if (j > 28 & j <= 34)
                                                Console.Write(aminoacids[29] + " ");//leu

                                            else if (j > 34 & j <= 36)
                                                Console.Write(aminoacids[35] + " ");//lys

                                            else if (j > 36 & j <= 37)
                                                Console.Write(aminoacids[37] + " ");//met

                                            else if (j > 37 & j <= 39)
                                                Console.Write(aminoacids[38] + " ");//phe

                                            else if (j > 39 & j <= 43)
                                                Console.Write(aminoacids[40] + " ");//pro

                                            else if (j > 43 & j <= 49)
                                                Console.Write(aminoacids[44] + " ");//ser

                                            else if (j > 49 & j <= 53)
                                                Console.Write(aminoacids[50] + " ");//thr

                                            else if (j > 53 & j <= 54)
                                                Console.Write(aminoacids[54] + " ");//trp

                                            else if (j > 54 & j <= 56)
                                                Console.Write(aminoacids[55] + " ");//tyr

                                            else if (j > 56 & j <= 60)
                                                Console.Write(aminoacids[57] + " ");//val

                                            else if (j > 60 & j <= 63)
                                                Console.Write(aminoacids[61] + " ");//stop
                                    }
                                }
                                Console.ReadLine();
                                break;
                            }

                        case 8:
                            {
                                string dnastring1 = "";
                                Console_print(dnastring);
                                Console.Write("How many codons you want to delete : ");
                                int a = Convert.ToInt32(Console.ReadLine());
                                Console.Write("From which codon you want to start deletion : ");
                                int b = Convert.ToInt32(Console.ReadLine());
                                int c = 0;
                                for (int j = 0; j < (3 * b - 3) / 3; j++)
                                {
                                    for (int k = 0; k < 3; k++)
                                    {
                                        Console.Write(dnafirst[c]);
                                        dnastring1=dnastring1+dnafirst[c];
                                        c++;
                                    }
                                    Console.Write(" ");
                                }
                                for (int m = 0; m < (dnafirst.Length - 3 * b - 3 * a + 3) / 3; m++)
                                {
                                    for (int n = 0; n < 3; n++)
                                    {
                                        Console.Write(dnafirst[c + 3 * a]);
                                        dnastring1 = dnastring1 + dnafirst[c+3*a];
                                        c++;
                                    }
                                    Console.Write(" ");
                                }
                                dnastring = dnastring1;
                                dnafirst = StringToCharArray(dnastring1);
                                Console.ReadLine();
                                break;
                            }
                        case 9:
                            {
                                string dnastring1 = "";
                                Console_print(dnastring);
                                Console.Write("Enter the codons you want to insert : ");
                                string a = Console.ReadLine();
                                Console.Write("From which codon you want to start insertion : ");
                                int b = Convert.ToInt32(Console.ReadLine());
                                char[] ac = new char[a.Length];
                                int c = 0;
                                int d = 0;
                                for (int i = 0; i < a.Length; i++)
                                {
                                    ac[i] = a[i];
                                }
                                for (int j = 0; j < (3 * b - 3) / 3; j++)
                                {
                                    for (int k = 0; k < 3; k++)
                                    {
                                        Console.Write(dnafirst[c]);
                                        dnastring1 = dnastring1 + dnafirst[c];
                                        c++;
                                    }
                                    Console.Write(" ");
                                }
                                for (int i = 0; i < a.Length / 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(ac[d]);
                                        dnastring1 = dnastring1 + ac[d];
                                        d++;
                                    }
                                    Console.Write(" ");
                                }
                                for (int j = 0; j < (dnafirst.Length - 3 * b + 3) / 3; j++)
                                {
                                    for (int k = 0; k < 3; k++)
                                    {
                                        Console.Write(dnafirst[c]);
                                        dnastring1 = dnastring1 + dnafirst[c];
                                        c++;
                                    }
                                    Console.Write(" ");
                                }
                                dnastring = dnastring1;
                                dnafirst = StringToCharArray(dnastring1);
                                Console.ReadLine();
                                break;
                            }

                        case 10:
                            {
                                Console_print(dnastring);
                                Console.Write("Enter the codons you want to find : ");
                                string a = Console.ReadLine();
                                Console.Write("From which codon you want to start findation : ");
                                int b = Convert.ToInt32(Console.ReadLine());
                                char[] ac = new char[a.Length];
                                int result = -1;
                                int c = 0;
                                for (int i = 0; i < a.Length; i++)
                                {
                                    ac[i] = a[i];
                                }
                                for (int i = 3 * b - 3; i < dnafirst.Length - ac.Length; i = i + 3)
                                {
                                    if (dnafirst[i] == ac[0])
                                    {
                                        c = 1;
                                    }
                                    for (int j = 1; j < ac.Length; j++)
                                    {
                                        if (dnafirst[i + j] == ac[j])
                                        {
                                            c++;
                                        }
                                    }

                                    if (c == ac.Length)
                                    {
                                        result = (i / 3) + 1;
                                        Console.WriteLine(result);
                                        break;
                                    }

                                }

                                Console.ReadLine();

                                break;
                            }

                        case 11:
                            {
                                string dnastring1 = "";
                                Console_print(dnastring);
                                Console.Write("How many codons do you want to reverse : ");
                                int a = Convert.ToInt32(Console.ReadLine());
                                Console.Write("From which codon you want to start reversetion : ");
                                int b = Convert.ToInt32(Console.ReadLine());
                                int c = 0;
                                int d = 3 * a;
                                for (int j = 0; j < (3 * b - 3) / 3; j++)
                                {
                                    for (int k = 0; k < 3; k++)
                                    {
                                        Console.Write(dnafirst[c]);
                                        dnastring1 = dnastring1 + dnafirst[c];
                                        c++;
                                    }
                                    Console.Write(" ");
                                }
                                int e = c;
                                for (int i = 0; i < a; i++)
                                {

                                    for (int j = 0; j < 3; j++)
                                    {

                                        Console.Write(dnafirst[e+d-3]);
                                        dnastring1 = dnastring1 + dnafirst[e+d-3];
                                        d++;
                                        c++;
                                    }
                                    Console.Write(" ");
                                    d = d - 6;
                                }
                                for (int i = 0; i < (dna1.Length - 3 * b + 3 - 3 * a) / 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(dnafirst[c]);
                                        dnastring1 = dnastring1 + dnafirst[c];
                                        c++;
                                    }
                                    Console.Write(" ");
                                }
                                dnastring = dnastring1;
                                dnafirst = StringToCharArray(dnastring1);
                                Console.ReadLine();
                                break;
                            }

                        case 12:
                            {
                                Console_print(dnastring);
                                int counter = 0;

                                for (int i = 0; i < dnafirst.Length - 3; i++)
                                {
                                    if (dnafirst[i] == 'A' & dnafirst[i + 1] == 'T' & dnafirst[i + 2] == 'G')
                                    {
                                        counter++;
                                    }
                                    i += 3;
                                }
                                Console.WriteLine(counter);
                                Console.ReadLine();
                                break;
                            }

                        case 13:
                            {
                                Console_print(dnastring);
                                int uzunluk = 0;
                                int index = 0;
                                int a = 99999999;



                                Console.Write("Shortest gene: ");
                                for (int i = 0; i < dnafirst.Length; i = i + 3)
                                {
                                    if (dnafirst[i] == 'A' && dnafirst[i + 1] == 'T' && dnafirst[i + 2] == 'G')
                                    {
                                        for (int j = i + 3; j < dnafirst.Length; j = j + 3)
                                        {

                                            if ((dnafirst[j] == 'T' && dnafirst[j + 1] == 'A' && dnafirst[j + 2] == 'G') || (dnafirst[j] == 'T' && dnafirst[j + 1] == 'A' && dnafirst[j + 2] == 'A') || (dnafirst[j] == 'T' && dnafirst[j + 1] == 'G' && dnafirst[j + 2] == 'A'))
                                            {
                                                uzunluk = (j - i) / 3 + 1;


                                                if (uzunluk <= a)
                                                {
                                                    index = i / 3;
                                                    a = uzunluk;


                                                }
                                                break;

                                            }

                                        }

                                    }

                                }
                                for (int i = 3 * index; i < 3 * (a + index); i++)
                                {
                                    Console.Write(dnafirst[i]);
                                }



                                Console.WriteLine();
                                Console.WriteLine("number of codons in the gene: {0}", a);

                                Console.WriteLine("position of the gene : " + (index + 1));

                                Console.ReadKey();
                                break;
                            }

                        case 14:
                            {
                                Console_print(dnastring);
                                int uzunluk = 0;
                                int index = 0;
                                int a = 0;



                                Console.Write("Longest gene: ");
                                for (int i = 0; i < dnafirst.Length; i = i + 3)
                                {
                                    if (dnafirst[i] == 'A' && dnafirst[i + 1] == 'T' && dnafirst[i + 2] == 'G')
                                    {
                                        for (int j = i + 3; j < dnafirst.Length; j = j + 3)
                                        {

                                            if ((dnafirst[j] == 'T' && dnafirst[j + 1] == 'A' && dnafirst[j + 2] == 'G') || (dnafirst[j] == 'T' && dnafirst[j + 1] == 'A' && dnafirst[j + 2] == 'A') || (dnafirst[j] == 'T' && dnafirst[j + 1] == 'G' && dnafirst[j + 2] == 'A'))
                                            {
                                                uzunluk = (j - i) / 3 + 1;


                                                if (uzunluk >= a)
                                                {
                                                    index = i / 3;
                                                    a = uzunluk;


                                                }
                                                break;

                                            }

                                        }

                                    }

                                }
                                for (int i = 3 * index; i < 3 * (a + index); i++)
                                {
                                    Console.Write(dnafirst[i]);
                                }



                                Console.WriteLine();
                                Console.WriteLine("number of codons in the gene: {0}", a);

                                Console.WriteLine("position of the gene : " + (index + 1));

                                Console.ReadKey();
                                break;
                            }

                        case 15:
                            {
                                Console_print(dnastring);
                                int number;
                                Console.Write("Please enter sequance: ");
                                number = Convert.ToInt32(Console.ReadLine());
                                char[] nucledite = new char[number];
                                char[] nucledite2 = new char[number];
                                int index1 = 0;
                                int temprorary = 0;
                                int index2 = 0;


                                for (int i = 0; i < dnafirst.Length - number + 1; i++)
                                {

                                    for (int j = 0; j < number; j++)
                                    {
                                        nucledite[j] = dnafirst[i + j];


                                    }

                                    int counter = 0;
                                    int counter2 = 0;

                                    temprorary = index1;
                                    for (int k = 0; k < dnafirst.Length - number + 1; k++)
                                    {
                                        counter = 0;
                                        for (int l = 0; l < number; l++)
                                        {
                                            if (nucledite[l] == dnafirst[k + l])
                                            {
                                                counter++;
                                            }
                                            if (counter == nucledite.Length)
                                            {
                                                counter2++;
                                            }
                                        }
                                    }
                                    index1 = counter2;

                                    if (index1 > temprorary && index2 < index1)
                                    {
                                        index2 = index1;
                                        for (int j = 0; j < nucledite.Length; j++)
                                        {
                                            nucledite2[j] = nucledite[j];
                                        }
                                    }
                                    else if (index1 <= temprorary && index2 < temprorary)
                                    {
                                        index2 = temprorary;
                                        for (int j = 0; j < nucledite.Length; j++)
                                        {
                                            nucledite2[j] = nucledite[j];
                                        }
                                    }



                                }
                                Console.Write("The most repeated sequance is: ");
                                Console.Write(nucledite2);
                                Console.WriteLine();
                                Console.Write("Frequency: ");
                                Console.Write(index2);
                                Console.ReadLine();
                                break;
                            }

                        case 16:
                            {
                                Console_print(dnastring);
                                int sayac2 = 0;
                                int sayac3 = 0;

                                for (int i = 0; i < dnafirst.Length; i++)
                                {

                                    if (dnafirst[i] == 'G' || dnafirst[i] == 'C')
                                    {
                                        sayac3 = sayac3 + 1;
                                    }
                                    else if (dnafirst[i] == 'A' || dnafirst[i] == 'T')
                                    {
                                        sayac2 = sayac2 + 1;
                                    }

                                }
                                Console.WriteLine("number of pairing with 2-hydrogen bonds :" + sayac2);
                                Console.WriteLine("number of pairing with 3-hydrogen bonds : " + sayac3);
                                Console.ReadLine ();
                                break;
                            }

                        case 17:
                            char[] nucleotids = new char[] { 'A', 'T', 'G', 'C' };
                            Random rstgl = new Random();
                            int sayaçcodon = rstgl.Next(0, 6);
                            int sayaçgene = rstgl.Next(1, 7);
                            string BLOB1()
                            {
                                int i = 1;
                                while (i <= sayaçcodon)
                                {
                                    Console.Write(" ");
                                    int createNuc1 = rstgl.Next(0, nucleotids.Length);
                                    int createNuc2 = rstgl.Next(0, nucleotids.Length);
                                    int createNuc3 = rstgl.Next(0, nucleotids.Length);
                                    if (((createNuc1 == 0) && (createNuc2 == 1) && (createNuc3 == 2)) || ((createNuc1 == 1) && (createNuc2 == 0) && (createNuc3 == 2)) || ((createNuc1 == 1) && (createNuc2 == 2) && (createNuc3 == 0)) || ((createNuc1 == 1) && (createNuc2 == 0) && (createNuc3 == 0)))
                                    {
                                        createNuc1 = rstgl.Next(0, nucleotids.Length);
                                        createNuc2 = rstgl.Next(0, nucleotids.Length);
                                        createNuc3 = rstgl.Next(0, nucleotids.Length);
                                        Console.Write(nucleotids[createNuc1]);
                                        Console.Write(nucleotids[createNuc2]);
                                        Console.Write(nucleotids[createNuc3]);
                                    }
                                    else
                                    {
                                        Console.Write(nucleotids[createNuc1]);
                                        Console.Write(nucleotids[createNuc2]);
                                        Console.Write(nucleotids[createNuc3]);
                                    }
                                    i++;
                                }
                                return null
                                    ;
                            }

                            string[] blob = new string[] { "ATG AAA TTT TAG ", "ATG TTT AAA TAG ", "ATG TTT TTT TAG ", "ATG TTT CCC TAG ", "ATG GGG AAA TAG ", "ATG GGG TTT TAG " };
                            int nblob = rstgl.Next(0, blob.Length);

                            // BLOB DNA:nfemale + "ATG" + WHILE DONGUSU + stopr
                            Console.Write("BLOB1 " + blob[nblob]);
                            int p = 1;
                            while (p <= sayaçgene)
                            {
                                string[] stop = new string[] { " TAA ", " TGA ", " TAG " };
                                int stopr = rstgl.Next(0, stop.Length);

                                Console.Write("ATG");
                                BLOB1();
                                Console.Write(stop[stopr]);
                                p++;
                            }
                            Console.WriteLine();


                            if (nblob == 0 || nblob == 1 || nblob == 2)
                            {
                                Console.WriteLine("The BLOB1 is female.");
                            }
                            else
                                Console.WriteLine("The BLOB1 is male.");


                            //OP17
                            //BLOB2

                            if (nblob == 0 || nblob == 1 || nblob == 2)//blob 1 female
                            {
                                char[] nucleotids1 = new char[] { 'A', 'T', 'G', 'C' };
                                Random rstg1l = new Random();
                                int sayaçcodon1 = rstgl.Next(0, 6);
                                int sayaçgene1 = rstgl.Next(1, 7);
                                string BLOB2()
                                {
                                    int i = 1;
                                    while (i <= sayaçcodon)
                                    {
                                        Console.Write(" ");
                                        int createNuc1 = rstgl.Next(0, nucleotids.Length);
                                        int createNuc2 = rstgl.Next(0, nucleotids.Length);
                                        int createNuc3 = rstgl.Next(0, nucleotids.Length);
                                        if (((createNuc1 == 0) && (createNuc2 == 1) && (createNuc3 == 2)) || ((createNuc1 == 1) && (createNuc2 == 0) && (createNuc3 == 2)) || ((createNuc1 == 1) && (createNuc2 == 2) && (createNuc3 == 0)) || ((createNuc1 == 1) && (createNuc2 == 0) && (createNuc3 == 0)))
                                        {
                                            createNuc1 = rstgl.Next(0, nucleotids.Length);
                                            createNuc2 = rstgl.Next(0, nucleotids.Length);
                                            createNuc3 = rstgl.Next(0, nucleotids.Length);
                                            Console.Write(nucleotids[createNuc1]);
                                            Console.Write(nucleotids[createNuc2]);
                                            Console.Write(nucleotids[createNuc3]);
                                        }
                                        else
                                        {
                                            Console.Write(nucleotids[createNuc1]);
                                            Console.Write(nucleotids[createNuc2]);
                                            Console.Write(nucleotids[createNuc3]);
                                        }
                                        i++;
                                    }
                                    return null;
                                }

                                string[] male = new string[] { "ATG TTT CCC TAG ", "ATG GGG AAA TAG ", "ATG GGG TTT TAG " };
                                int nmale = rstgl.Next(0, male.Length);

                                // BLOB DNA:emale + "ATG" + WHILE DONGUSU + stopr
                                Console.Write("BLOB2 " + male[nmale]);
                                int k = 1;
                                while (k <= sayaçgene)
                                {
                                    string[] stop = new string[] { " TAA ", " TGA ", " TAG " };
                                    int stopr = rstgl.Next(0, stop.Length);

                                    Console.Write("ATG");
                                    BLOB2();
                                    Console.Write(stop[stopr]);
                                    k++;
                                }
                                Console.WriteLine();
                                Console.WriteLine("The BLOB 2 is male.");
                            }


                            else if (nblob == 3 || nblob == 4 || nblob == 5)
                            {

                                char[] nucleotids1 = new char[] { 'A', 'T', 'G', 'C' };
                                Random rstg1l = new Random();
                                int sayaçcodon1 = rstgl.Next(0, 6);
                                int sayaçgene1 = rstgl.Next(1, 7);
                                string BLOB2()
                                {
                                    int i = 1;
                                    while (i <= sayaçcodon)
                                    {
                                        Console.Write(" ");
                                        int createNuc1 = rstgl.Next(0, nucleotids.Length);
                                        int createNuc2 = rstgl.Next(0, nucleotids.Length);
                                        int createNuc3 = rstgl.Next(0, nucleotids.Length);
                                        if (((createNuc1 == 0) && (createNuc2 == 1) && (createNuc3 == 2)) || ((createNuc1 == 1) && (createNuc2 == 0) && (createNuc3 == 2)) || ((createNuc1 == 1) && (createNuc2 == 2) && (createNuc3 == 0)) || ((createNuc1 == 1) && (createNuc2 == 0) && (createNuc3 == 0)))
                                        {
                                            createNuc1 = rstgl.Next(0, nucleotids.Length);
                                            createNuc2 = rstgl.Next(0, nucleotids.Length);
                                            createNuc3 = rstgl.Next(0, nucleotids.Length);
                                            Console.Write(nucleotids[createNuc1]);
                                            Console.Write(nucleotids[createNuc2]);
                                            Console.Write(nucleotids[createNuc3]);
                                        }
                                        else
                                        {
                                            Console.Write(nucleotids[createNuc1]);
                                            Console.Write(nucleotids[createNuc2]);
                                            Console.Write(nucleotids[createNuc3]);
                                        }
                                        i++;
                                    }
                                    return null;
                                }

                                string[] female1 = new string[] { "ATG AAA TTT TAG ", "ATG TTT AAA TAG ", "ATG TTT TTT TAG " };
                                int nfemale = rstgl.Next(0, female1.Length);

                                // BLOB DNA:emale + "ATG" + WHILE DONGUSU + stopr
                                Console.Write("BLOB2 " + female1[nfemale]);
                                int k = 1;
                                while (k <= sayaçgene)
                                {
                                    string[] stop = new string[] { " TAA ", " TGA ", " TAG " };
                                    int stopr = rstgl.Next(0, stop.Length);

                                    Console.Write("ATG");
                                    BLOB2();
                                    Console.Write(stop[stopr]);
                                    k++;
                                }
                                Console.WriteLine();
                                Console.WriteLine("The BLOB2 is female.");
                            }




                            //BLOB3

                            //blob1



                            string[] female2 = new string[] { "ATGAAATTTTAG", "ATGTTTAAATAG ", "ATGTTTTTTTAG" };
                            string[] male2 = new string[] { "ATGTTTCCCTAG", "ATGGGGAAATAG", "ATGGGGTTTTAG" };
                            if (nblob == 0)
                            {

                                char[] a = StringToCharArray(female2[0]);
                                for (int k = 0; k < 3; k++)
                                {
                                    Console.Write(a[3]);
                                }

                            }


                            else if (nblob == 1)
                            {
                                char[] a = StringToCharArray(female2[1]);
                                for (int k = 0; k < 3; k++)
                                {
                                    Console.Write(a[3]);
                                }


                            }
                            else if (nblob == 2)
                            {
                                char[] a = StringToCharArray(female2[2]);
                                for (int k = 0; k < 3; k++)
                                {
                                    Console.Write(a[3]);
                                }


                            }
                            Console.ReadLine();
                            break;


                        default:
                            break;
                    }
                } while (opr1!=0);
            } while (true);
            
            
































































            






        }
    }
}
