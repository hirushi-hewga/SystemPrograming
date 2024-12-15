using static System.Console;

namespace _2024_10_14___Lesson__Unsafe_Code._Registry_
{
    #region stackalloc

    /**/
    class Program
    {
        // Project -> Properties -> Build -> Allow Unsafe Code
        unsafe struct Unsafe
        {
            public int* Pointer { get; set; }
            //public string Name { get; set; } // "ds" "ddgg" "dfhfhfjfdjdf,jdpfojdofjodfjhg"
            public float A { get; set; }
            //public float Name { get; set; }
        }
        unsafe static int* UnsafeMethod()
        {
            int[] arr1 = { 1, 2, 3 }; // Array

            const int size = 10;
            int* arr = stackalloc int[size];
            int* p = arr;
            *(p) = 3;
            *(++p) = 1;
            for (int i = 0; i < size; ++i)
            {
                Write(arr[i] + " ");
            }
            WriteLine();
            for (int i = 2; i <= size; i++, p++)
            {
                *p = p[-1] * i;
            }
            for (int i = 0; i < size; ++i)
            {
                WriteLine(arr[i]);
            }
            return arr;
        }
        unsafe static int* GenerateArr(out int size)
        {
            Random rnd = new Random();
            size = rnd.Next(20);
            //size = int.Parse(ReadLine());
            int[] arr = new int[size]; // Array
            //drop
            //int* arr = stackalloc int[size];
            fixed (int* arrPtr = arr)
            {
                //int* arrPtr = arr
                for (int* p = arrPtr; p < arrPtr + size; ++p)
                {
                    *p = rnd.Next(100);
                }
                for (int i = 0; i < size; i++)
                {
                    Write(arr[i] + " ");
                }
                WriteLine();
                return arrPtr;
            }
        }
        static void Main(string[] args)
        {
            //Int32 b = new Int32();
            //int a; // a = 0
            //string str = "hello";
            //string str2; // null
            //// unsafe block allow use a pointers (* & ->)

            unsafe
            {
                //////// pointer to base type
                //int num = 10;
                //int* pointer = &num;
                //WriteLine("Address : " + (int)pointer);
                //WriteLine("Value : " + *pointer);


                //////// pointer to struct
                //Unsafe @unsafe = new Unsafe();
                //Unsafe* strPtr = &@unsafe;
                //(*strPtr).Pointer = &num;
                //strPtr->Pointer = &num;
                //WriteLine(*@unsafe.Pointer);


                //////// create an array
                //int[] arr1 = new int[1000000000000000]; // save clr
                //for (int i = 0; i < arr1.Length; i++)
                //{
                //    WriteLine(arr1[i]);
                //}

                //int[] arr2 = new int[10] { 1, 2, 3, 5, 7, 8, 9, 33, 4, 5 }; // Array

                //const int size = 10;
                //int* arr = stackalloc int[size];

                //WriteLine("First : " + (int)arr);
                //WriteLine("First : " + *arr);
                //for (int* ptr = arr; ptr < arr + size; ptr++)
                //{
                //    Write(*ptr + " ");
                //}
                //WriteLine();
                //for (int i = 0; i < size; i++)
                //{
                //    arr[i] = i * i;
                //    *(arr + i) = i * i;
                //}

                //// *(arr + 100000) = 0; //error

                //for (int* ptr = arr; ptr < arr + size; ptr++)
                //{
                //    Write(*ptr + " ");
                //}



                //int size = 10;
                ////// invoke unsafe method
                //int* arr = UnsafeMethod();

                ////// return pointer to an array
                //int* arr = GenerateArr(out size);

                //for (int i = 0; i < size; i++)
                //{
                //    Write(arr[i] + " ");
                //}
                //ReadKey();
            }
        }
    }


    #endregion
}
