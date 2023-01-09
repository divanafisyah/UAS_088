using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_088
{
    class Node
    {
        public int NoInduk;
        public string NamaSiswa;
        public Node next;
        public Node prev;
    }
    class Kelas
    {
        Node START, NoInduk, NamaSiswa;
        public Kelas()
        {
            START = null;
            NoInduk = null;
            NamaSiswa = null;
        }
        public void addData()
        {
            int NoInd;
            Console.Write("\nMasukkan Nomor Induk Siswa: ");
            NoInd = Convert.ToInt32(Console.ReadLine());

            string NameSiswa;
            Console.Write("\nMasukkan Nama Siswa :");
            NameSiswa = Console.ReadLine();

            Node newNode = new Node();
            newNode.NoInduk = NoInd;
            newNode.NamaSiswa = NameSiswa;

            if (START == null || NoInd <= START.NoInduk)
            {
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = START;
                current != null && NoInd >= current.NoInduk;
                previous = current,
                current = current.next)
            {
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public void viewData()
        {
            if (NoInduk == null)
            {
                Console.WriteLine("Data is empty");
                return;
            }
            Node viewNoInd;
            for (viewNoInd = NoInduk; viewNoInd != null; viewNoInd = viewNoInd.next)
                Console.WriteLine(viewNoInd.NoInduk);

            if (NamaSiswa == null)
            {
                Console.WriteLine("Data is empty");
                return;
            }
            Node viewNama;
            for (viewNama = NamaSiswa; viewNama != null; viewNama = viewNama.next)
                Console.WriteLine(viewNama.NamaSiswa);
        }
        public bool searchData(int rollNoInd, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                rollNoInd != current.NoInduk; previous = current,
                current = current.next) { }
            return (current != null);
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                Kelas obj = new Kelas();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMENU DATA SISWA SD NEGERI");
                        Console.WriteLine("1. Add data");
                        Console.WriteLine("2. View data");
                        Console.WriteLine("3. Search");
                        Console.WriteLine("4. Exit");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addData();
                                }
                                break;
                            case '2':
                                {
                                    obj.viewData();
                                }
                                break;
                            case '3':
                                {
                                    obj.searchData();
                                }
                                break;
                            case '4':
                                return;
                            default:
                                Console.WriteLine("Invalid Option");
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Check for the values entered.");
                    }
                }
            }
        }
    }
/* Jawaban essay :
 * 2. Saya menggunakan algoritma Double Linked List dan Queue
 * 3. TOP pada algoritma Stack adalah data yang bisa di tambahkan dan dihapus hanya melalui 1 jalur terakhir.
 * 4. Rear, Front
 * 5. a) 4 Level
 *    b) Preorder : 50, 48, 30, 20, 15, 25, 32, 31, 35, 70, 65, 67, 66, 69, 90, 98, 94, 99
*/
