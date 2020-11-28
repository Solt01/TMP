using System; //+1
using System.Diagnostics; //+2

namespace LinkedItem98
{
    public class Dequeue
    {
        public long ellapledTicks;
        int count;  // количество элементов в списке
        Item head; // +6 головной/первый элемент
        Item tail; // +6 последний/хвостовой элемент
        public ulong n_op = 16; // учитывая класс Item и все до него 1 + 2 + 6 + 6 + 1 
        public void N_op(ulong x) // фунция для увеличения числа операций + 1
        {
            n_op = n_op + x + 4; // + 3
        }
        public int Count { get { N_op(2); return count; } } // защита от изменения размерности списка 
        public void sort(Dequeue ob, int ct)//
        {
            ellapledTicks = DateTime.Now.Ticks; // +3
            int n = ct; //+ 1
            N_op(7); // + 1 вызов функции
            // Построение кучи 
            N_op(5); // +1
            for (int i = n / 2 - 1; i >= 0; i--)
            {  
                heapify(ob, n, i); //+1
                N_op(5); //+1
            }

            N_op(4);//+1
            // Извлекаем элементы 
            for (int i = n - 1; i >= 0; i--)//24*n
            {
                // Перемещаем текущий корень в конец
                int temp = ob.GetObj(0).Data;//+4
                N_op(5);//+1

                ob.GetObj(0).Data = ob.GetObj(i).Data;//+7
                N_op(8);//+1

                ob.GetObj(i).Data = temp;//+4
                N_op(5);//+1

                heapify(ob, i, 0); // +1 вызываем процедуру heapify на уменьшенной куче
                N_op(2);//+1

                N_op(4);//+1
            }
            ellapledTicks = DateTime.Now.Ticks - ellapledTicks; N_op(2);//+4
            N_op(5);//+1
        }
        public void heapify(Dequeue ob, int n, int i) // Процедура для преобразования в двоичную кучу поддерева с корневым узлом i, что является
        {
            N_op(4);//+1

            int largest = i;//+1
            N_op(2);//+1

            // Инициализируем наибольший элемент как корень
            int l = 2 * i + 1; //+3 left = 2*i + 1
            N_op(4);//+1

            int r = 2 * i + 2; //+3 right = 2*i + 2
            N_op(4);

            // Если левый дочерний элемент больше корня
            if (l < n && ob.GetObj(l).Data > ob.GetObj(largest).Data)
            {
                N_op(2);//+1
                largest = l;//+1
            }
            N_op(11);//+1

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (r < n && ob.GetObj(r).Data > ob.GetObj(largest).Data)
            {
                N_op(2);//+1
                largest = r;//+1
            }
            N_op(11);//+1

            // Если самый большой элемент не корень
            if (largest != i)//+1
            {
                int swap = ob.GetObj(i).Data;//+4
                N_op(5);//+1

                ob.GetObj(i).Data = ob.GetObj(largest).Data;//+7
                N_op(8);//+1

                ob.GetObj(largest).Data = swap;//+4
                N_op(5);//+1

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                heapify(ob, n, largest);//+1
                N_op(2);//+1
            }
            N_op(2);//+1
        }
        public void AddFirst(int data) //30*n добавление элемента в начало
        {
            N_op(2);//+1

            Item node = new Item(data); //+8 Item() (+6) new (+1)
            N_op(9);//+1

            Item temp = head;//+7
            N_op(8);//+1

            node.Next = temp;//+2
            N_op(3);//+1

            head = node;//+1
            N_op(2);//+1

            N_op(2);//+1
            if (count == 0) //+1
            {
                tail = head;//+1
                N_op(2);//+1
            }
            else
            {
                temp.Previous = node;//+2
                N_op(3);//+1
            }
            count++;//+2
            N_op(3);//+1
        }
        public void AddLast(int data) //24*n добавление элемента в конец
        {
            N_op(2);//+1

            Item node = new Item(data);//+8
            N_op(9);//+1

            N_op(2);//+1
            if (head == null)//+1 
            {
                head = node;//+1
                N_op(2);//+1
            }
            else
            {
                tail.Next = node;//+2
                N_op(3);//+1

                node.Previous = tail;//+2
                N_op(3);//+1
            }
            tail = node;//+1
            N_op(2);//+1

            count++;//+2
            N_op(3);//+1
        }
        public void RemoveFirst() // удаление первого элемента
        {
            if (count == 0)//+1
            {
                Console.WriteLine("Список пуст");//+2
                N_op(3);//+1
            }
            N_op(2);//+1

            int output = head.Data;//+2
            N_op(3);//+1


            N_op(2);//+1
            if (count == 1)//+1
            {
                head = tail = null;//+2
                N_op(3);//+1
            }
            else
            {
                head = head.Next;//+2
                N_op(3);//+1

                head.Previous = null;//+2
                N_op(3);//+1
            }
            count--;//+2
            N_op(3);//+1
        }
        public void RemoveLast() //удаление последнего элемента
        {

            if (count == 0) // +1
            {
                Console.WriteLine("Список пуст");//+2
                N_op(3);//+1
            }
            N_op(2);//+1

            int output = tail.Data;//+2
            N_op(3);//+1


            N_op(2);//+1
            if (count == 1)//+1
            {
                head = tail = null;//+2
                N_op(3);//+1
            }
            else
            {
                tail = tail.Previous;//+2
                N_op(3);//+1

                tail.Next = null;//+2
                N_op(3);//+1
            }
            count--;//+2
            N_op(3);//+1
        }
        public void ShowFirst() // показать первый элемент
        {
            N_op(2);//+1
            if (Count == 0) //1
            {
                Console.WriteLine("Список пуст");//+1
                N_op(3);//+1
            }
            else
            {
                Console.WriteLine($"Первый элемент списка: {head.Data}");//+3
                N_op(4);//+1
            }

        }
        public void ShowLast() // показать последний элемент
        {
            N_op(2);//+1
            if (Count == 0) //+1
            {
                Console.WriteLine("Список пуст");//+2
                N_op(3);//+1
            }
            else
            {
                Console.WriteLine($"Последний элемент списка: { tail.Data}");//+3
                N_op(4);//+1
            }

        }
        public void isEmpty() // проверка списка на пустоту
        {
            N_op(2);//+1
            if (Count == 0) //+1
            {
                Console.WriteLine("Список пуст");//+2
                N_op(3);//+1
            }
        }
        public void SizeList() // получение размера списка
        {
            Console.WriteLine($"Размер списка:{Count}");//+3
            N_op(4);//+1
        }
        public void Clear() // очистить список
        {
            if (Count != 0)//+1
            {
                N_op(3);//+1
                for (int i = Count; i > 0; i--)
                {
                    N_op(2);//+1
                    if (Count == 1)//+1
                    {
                        head = tail = null;//+2
                        N_op(3);//+1
                    }
                    else
                    {
                        tail = tail.Previous;//+2
                        N_op(3);//+1

                        tail.Next = null;//+2
                        N_op(3);//+1
                    }
                    count--;//+2
                    N_op(3);//+1

                    N_op(4);//+1
                }
            }
            N_op(2);//+1

            Console.WriteLine("Список очищен");//+2
            N_op(3);//+1
        }
        public void FrontClear(int index) // очистить список до i-го элемента начиная с головы
        {
            N_op(2);//+1

            N_op(3);//+1
            for (int i = 0; i < index; i++)
            {
                N_op(2);//+1
                if (count == 1) // +1
                {
                    head = tail = null;//+2
                    N_op(3);//+1
                }
                else
                {
                    head = head.Next;//+2
                    N_op(3);//+1

                    head.Previous = null;//+2
                    N_op(3);//+1
                }
                count--;//+2
                N_op(3);//+1

                N_op(4);//+1
            }
            Console.WriteLine($"Список очищен до {2}-й позиции начиная с головы");//+3
            N_op(4);//+1
        }
        public void LastClear(int index) // очистить список до i-го элемента начиная с конца
        {
            N_op(2);//+1

            N_op(3);//+1
            for (int i = index; i > 0; i--)
            {
                N_op(2);//+1
                if (count == 1)//+1
                {
                    head = tail = null;//+2
                    N_op(3);//+1
                }
                else
                {
                    tail = tail.Previous;//+2
                    N_op(3);//+1

                    tail.Next = null;//+2
                    N_op(3);//+1
                }
                count--;//+2
                N_op(3);//+1

                N_op(4);//+1
            }
            Console.WriteLine($"Список очищен до {2}-й позиции начиная с головы");//+3
            N_op(4);//+1
        }
        public void AppointFront(int data, int index) // присваиваем новое значение i-му элементу начиная с головы
        {
            N_op(3);//+1

            N_op(3);//+1
            if (count == 0)//+1
            {
                Console.WriteLine("Список пуст");//+2
                N_op(3);//+1
            }
            else
            {
                Item current;//+6
                N_op(7);//+1

                N_op(4);//+1
                for (int i = 0; i < index - 1; i++)
                {
                    current = head;//+1
                    N_op(2);//+1

                    head = head.Next;//+2
                    N_op(3);//+1

                    tail.Next = current;//+2
                    N_op(3);//+1

                    current.Previous = tail;//+2
                    N_op(3);//+1

                    tail = current;//+1
                    N_op(3);//+1

                    current.Next = null;//+2
                    N_op(3);//+1

                    head.Previous = null;//+2
                    N_op(3);//+1

                    N_op(5);//+1
                }

                head.Data = data;//+2
                N_op(3);//+1

                N_op(4);//+1
                for (int i = 0; i < index - 1; i++)
                {
                    current = tail;//+1
                    N_op(2);//+1

                    tail = tail.Previous;//+2
                    N_op(3);//+1

                    head.Previous = current;//+2
                    N_op(3);//+1

                    current.Next = head;//+2
                    N_op(3);//+1

                    head = current;//+1
                    N_op(2);//+1

                    tail.Next = null;//+2
                    N_op(3);//+1

                    head.Previous = null;//+2
                    N_op(3);//+1

                    N_op(5);//+1
                }
                Console.WriteLine($"Значение {4}-го элемента изменено на {7} начиная с головы");//+4
                N_op(5);//+1
            }
        }
        public void AppointLast(int data, int index)// присваиваем новое значение i-му элементу начиная с конца
        {
            N_op(3);//+1

            N_op(2);//+1
            if (count == 0)//+1 
            {
                Console.WriteLine("Список пуст");//+2
                N_op(3);//+1
            }
            else
            {
                Item current;//+6
                N_op(7);//+1

                N_op(4);//+1
                for (int i = 0; i < index - 1; i++)
                {
                    current = tail;//+1
                    N_op(2);//+1

                    tail = tail.Previous;//+2
                    N_op(3);//+1

                    head.Previous = current;//+2
                    N_op(3);//+1

                    current.Next = head;//+2
                    N_op(3);//+1

                    head = current;//+1
                    N_op(2);//+1

                    tail.Next = null;//+2
                    N_op(3);//+1

                    head.Previous = null;//+2
                    N_op(3);//+1

                    N_op(5);//+1
                }
                tail.Data = data;//+2
                N_op(3);//+1

                N_op(4);//+1
                for (int i = 0; i < index - 1; i++)
                {
                    current = head;//+1
                    N_op(2);//+1


                    head = head.Next;//+2
                    N_op(3);//+1


                    tail.Next = current;//+2
                    N_op(3);//+1


                    current.Previous = tail;//+2
                    N_op(3);//+1


                    tail = current;//+1
                    N_op(2);//+1


                    current.Next = null;//+2
                    N_op(3);//+1


                    head.Previous = null;//+2
                    N_op(3);//+1

                    N_op(5);//+1
                }
                Console.WriteLine($"Значение {3}-го элемента изменено на {7} начиная с конца");
                N_op(5);//+1
            }
        }
        public void GetFront(int index) // получаем значение i-го элемента начиная с головы   
        {
            N_op(2);//+1

            N_op(2);//+1
            if (count == 0)//+1
            {
                Console.WriteLine("Список пуст");//+2
                N_op(3);//+1
            }

            else
            {
                Item current;//+6
                N_op(7);//+1

                N_op(4);//+1
                for (int i = 0; i < index - 1; i++)
                {
                    current = head;//+1
                    N_op(2);//+1

                    head = head.Next;//+2
                    N_op(3);//+1

                    tail.Next = current;//+2
                    N_op(3);//+1

                    current.Previous = tail;//+2
                    N_op(3);//+1

                    tail = current;//+1
                    N_op(3);//+1

                    current.Next = null;//+2
                    N_op(3);//+1

                    head.Previous = null;//+2
                    N_op(3);//+1

                    N_op(5);//+1

                }

                Console.WriteLine(head.Data);//+3
                N_op(4);//+1

                N_op(4);//+1
                for (int i = 0; i < index - 1; i++)
                {
                    current = tail;//+1
                    N_op(2);//+1

                    tail = tail.Previous;//+2
                    N_op(3);//+1

                    head.Previous = current;//+2
                    N_op(3);//+1

                    current.Next = head;//+2
                    N_op(3);//+1

                    head = current;//+1
                    N_op(2);//+1

                    tail.Next = null;//+2
                    N_op(3);//+1

                    head.Previous = null;//+2
                    N_op(3);//+1

                    N_op(5);//+1
                }
            }
        }
        public void GetLast(int index) // получаем значение i-го элемента начиная с конца   
        {
            N_op(2);//+1

            N_op(2);//+1
            if (count == 0)//+1
            {
                Console.WriteLine("Список пуст");//+2
                N_op(3);//+1
            }

            else
            {
                Item current;//+6
                N_op(7);//+1

                int rez;

                N_op(4);//+1
                for (int i = 0; i < index - 1; i++)
                {

                    current = tail;//+1
                    N_op(2);//+1

                    tail = tail.Previous;//+2
                    N_op(3);//+1

                    head.Previous = current;//+2
                    N_op(3);//+1

                    current.Next = head;//+2
                    N_op(3);//+1

                    head = current;//+1
                    N_op(2);//+1

                    tail.Next = null;//+2
                    N_op(3);//+1

                    head.Previous = null;//+2
                    N_op(3);//+1

                    N_op(5);//+1
                }

                Console.WriteLine(tail.Data);//+3
                N_op(4);//+1

                N_op(4);//+1
                for (int i = 0; i < index - 1; i++)
                {
                    current = head;//+1
                    N_op(2);//+1


                    head = head.Next;//+2
                    N_op(3);//+1


                    tail.Next = current;//+2
                    N_op(3);//+1


                    current.Previous = tail;//+2
                    N_op(3);//+1


                    tail = current;//+1
                    N_op(2);//+1


                    current.Next = null;//+2
                    N_op(3);//+1


                    head.Previous = null;//+2
                    N_op(3);//+1

                    N_op(5);//+1
                }
            }
        }
        public Item GetObj(int index) //24 + 47n получаем i-й элемент списка для пирамидальной сортировки   
        {
            N_op(2);//+1

            Item current, rez;//+6
            N_op(7);//+1

            N_op(3);//+1
            for (int i = 0; i < index; i++)// 16 + 24n
            {
                current = head;//+1
                N_op(2);//+1

                head = head.Next;//+2
                N_op(3);//+1

                tail.Next = current;//+2
                N_op(3);//+1

                current.Previous = tail;//+2
                N_op(3);//+1

                tail = current;//+1
                N_op(3);//+1

                current.Next = null;//+2
                N_op(3);//+1

                head.Previous = null;//+2
                N_op(3);//+1

                N_op(4);//+1
            }

            rez = head;//+1
            N_op(2);//+1

            for (int i = 0; i < index; i++) //8 + 23n
            {
                current = tail;//+1
                N_op(2);//+1

                tail = tail.Previous;//+2
                N_op(3);//+1

                head.Previous = current;//+2
                N_op(3);//+1

                current.Next = head;//+2
                N_op(3);//+1

                head = current;//+1
                N_op(2);//+1

                tail.Next = null;//+2
                N_op(3);//+1

                head.Previous = null;//+2
                N_op(3);//+1

                N_op(4);//+1
            }

            N_op(2);//+1
            return rez;//+1
        }
        public void SetObjFront(int data, int index) // дабавляем новый элемент списка в i-ю позицию начиная с головы
        {
            N_op(3);//+1

            Item current;//+6
            N_op(7);//+1

            Item New = new Item(data);//+8
            N_op(9);//+1

            N_op(4);//+1
            for (int i = 0; i < index - 1; i++)
            {
                current = head;//+1
                N_op(2);//+1

                head = head.Next;//+2
                N_op(3);//+1

                tail.Next = current;//+2
                N_op(3);//+1

                current.Previous = tail;//+2
                N_op(3);//+1

                tail = current;//+1
                N_op(3);//+1

                current.Next = null;//+2
                N_op(3);//+1

                head.Previous = null;//+2
                N_op(3);//+1

                N_op(5);//+1
            }

            current = head;//+1
            N_op(2);//+1

            New.Next = current;//+2
            N_op(3);//+1

            head = New;//+1
            N_op(2);//+1


            N_op(2);//+1
            if (count == 0)//+1
            {
                tail = head;//+1
                N_op(2);//+1
            }
            else
            {
                current.Previous = New;//+2
                N_op(3);//+1
            }

            count++;//+2
            N_op(3);//+1

            N_op(4);//+1
            for (int i = 0; i < index - 1; i++)
            {
                current = tail;//+1
                N_op(2);//+1

                tail = tail.Previous;//+2
                N_op(3);//+1

                head.Previous = current;//+2
                N_op(3);//+1

                current.Next = head;//+2
                N_op(3);//+1

                head = current;//+1
                N_op(2);//+1

                tail.Next = null;//+2
                N_op(3);//+1

                head.Previous = null;//+2
                N_op(3);//+1

                N_op(5);//+1
            }
        }
        public void SetObjLast(int data, int index) // дабавляем новый элемент списка в i-ю позицию начиная с конца
        {
            N_op(3);//+1

            Item current;//+6
            N_op(7);//+1

            Item New = new Item(data);//+8
            N_op(9);//+1

            N_op(4);//+1
            for (int i = 0; i < index - 1; i++)
            {
                current = tail;//+1
                N_op(2);//+1

                tail = tail.Previous;//+2
                N_op(3);//+1

                head.Previous = current;//+2
                N_op(3);//+1

                current.Next = head;//+2
                N_op(3);//+1

                head = current;//+1
                N_op(2);//+1

                tail.Next = null;//+2
                N_op(3);//+1

                head.Previous = null;//+2
                N_op(3);//+1

                N_op(5);//+1
            }

            current = tail;//+1
            N_op(2);//+1

            New.Previous = current;//+2
            N_op(3);//+1

            tail = New;//+1
            N_op(2);//+1


            N_op(2);//+1
            if (count == 0)//+1
            {
                head = tail;//+1
                N_op(2);//+1
            }
            else
            {
                current.Next = New;//+2
                N_op(3);//+1
            }

            count++;//+2
            N_op(3);//+1

            N_op(4);//+1
            for (int i = 0; i < index - 1; i++)
            {
                current = head;//+1
                N_op(2);//+1

                head = head.Next;//+2
                N_op(3);//+1

                tail.Next = current;//+2
                N_op(3);//+1

                current.Previous = tail;//+2
                N_op(3);//+1

                tail = current;//+1
                N_op(3);//+1

                current.Next = null;//+2
                N_op(3);//+1

                head.Previous = null;//+2
                N_op(3);//+1

                N_op(5);//+1
            }
        }
    }
    public class Item // создаем элемент двусвязного списка
    {
        public int Data;
        public Item Next { get; set; }
        public Item Previous { get; set; }
        public Item(int data)
        {
            Data = data;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            {
                Dequeue linkedList = new Dequeue();//+2
                linkedList.N_op(5);//+2

                Console.Write("Номер сортировки: 1  ");//+2
                linkedList.N_op(4);//+2

                Console.Write("Кол-во отсортированных элементов: 300  ");//+2
                linkedList.N_op(4);//+2

                linkedList.N_op(4);//+2
                for (int i = 0; i < 300; i++)
                {
                    linkedList.AddLast(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.AddFirst(i);//+2
                    linkedList.N_op(4);//+2

                  linkedList.N_op(5);//+2
                }

                linkedList.sort(linkedList, linkedList.Count);//+5
                linkedList.N_op(7);//+2


                Console.Write("Время сортировки (такты): " + linkedList.ellapledTicks + "  ");//+5
                linkedList.N_op(7);//+2

                Console.WriteLine($"Колличество операций (N_op): {linkedList.n_op}");//+4
                linkedList.N_op(6);//+2
            } // 300 элементов

            {
                Dequeue linkedList = new Dequeue();//+2
                linkedList.N_op(5);//+2

                Console.Write("Номер сортировки: 2  ");//+2
                linkedList.N_op(4);//+2

                Console.Write("Кол-во отсортированных элементов: 600  ");//+2
                linkedList.N_op(4);//+2

                linkedList.N_op(4);//+2
                for (int i = 0; i < 600; i++)
                {
                    linkedList.AddLast(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.AddFirst(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.N_op(5);//+2
                }

                linkedList.sort(linkedList, linkedList.Count);//+5
                linkedList.N_op(7);//+2


                Console.Write("Время сортировки (такты): " + linkedList.ellapledTicks + "  ");//+5
                linkedList.N_op(7);//+2

                Console.WriteLine($"Колличество операций (N_op): {linkedList.n_op}");//+4
                linkedList.N_op(6);//+2
            } // 600 элементов

            {
                Dequeue linkedList = new Dequeue();//+2
                linkedList.N_op(5);//+2

                Console.Write("Номер сортировки: 3  ");//+2
                linkedList.N_op(4);//+2

                Console.Write("Кол-во отсортированных элементов: 900  ");//+2
                linkedList.N_op(4);//+2

                linkedList.N_op(4);//+2
                for (int i = 0; i < 900; i++)
                {
                    linkedList.AddLast(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.AddFirst(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.N_op(5);//+2
                }

                linkedList.sort(linkedList, linkedList.Count);//+5
                linkedList.N_op(7);//+2


                Console.Write("Время сортировки (такты): " + linkedList.ellapledTicks + "  ");//+5
                linkedList.N_op(7);//+2

                Console.WriteLine($"Колличество операций (N_op): {linkedList.n_op}");//+4
                linkedList.N_op(6);//+2
            } // 900 элементов

            {
                Dequeue linkedList = new Dequeue();//+2
                linkedList.N_op(5);//+2

                Console.Write("Номер сортировки: 4  ");//+2
                linkedList.N_op(4);//+2

                Console.Write("Кол-во отсортированных элементов: 1200  ");//+2
                linkedList.N_op(4);//+2

                linkedList.N_op(4);//+2
                for (int i = 0; i < 1200; i++)
                {
                    linkedList.AddLast(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.AddFirst(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.N_op(5);//+2
                }

                linkedList.sort(linkedList, linkedList.Count);//+5
                linkedList.N_op(7);//+2


                Console.Write("Время сортировки (такты): " + linkedList.ellapledTicks + "  ");//+5
                linkedList.N_op(7);//+2

                Console.WriteLine($"Колличество операций (N_op): {linkedList.n_op}");//+4
                linkedList.N_op(6);//+2
            } // 1200 элементов

            {
                Dequeue linkedList = new Dequeue();//+2
                linkedList.N_op(5);//+2

                Console.Write("Номер сортировки: 5  ");//+2
                linkedList.N_op(4);//+2

                Console.Write("Кол-во отсортированных элементов: 1500  ");//+2
                linkedList.N_op(4);//+2

                linkedList.N_op(4);//+2
                for (int i = 0; i < 1500; i++)
                {
                    linkedList.AddLast(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.AddFirst(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.N_op(5);//+2
                }

                linkedList.sort(linkedList, linkedList.Count);//+5
                linkedList.N_op(7);//+2


                Console.Write("Время сортировки (такты): " + linkedList.ellapledTicks + "  ");//+5
                linkedList.N_op(7);//+2

                Console.WriteLine($"Колличество операций (N_op): {linkedList.n_op}");//+4
                linkedList.N_op(6);//+2
            } // 1500 элементов

            {
                Dequeue linkedList = new Dequeue();//+2
                linkedList.N_op(5);//+2

                Console.Write("Номер сортировки: 6  ");//+2
                linkedList.N_op(4);//+2

                Console.Write("Кол-во отсортированных элементов: 1800  ");//+2
                linkedList.N_op(4);//+2

                linkedList.N_op(4);//+2
                for (int i = 0; i < 1800; i++)
                {
                    linkedList.AddLast(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.AddFirst(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.N_op(5);//+2
                }

                linkedList.sort(linkedList, linkedList.Count);//+5
                linkedList.N_op(7);//+2


                Console.Write("Время сортировки (такты): " + linkedList.ellapledTicks + "  ");//+5
                linkedList.N_op(7);//+2

                Console.WriteLine($"Колличество операций (N_op): {linkedList.n_op}");//+4
                linkedList.N_op(6);//+2
            } // 1800 элементов

            {
                Dequeue linkedList = new Dequeue();//+2
                linkedList.N_op(5);//+2

                Console.Write("Номер сортировки: 7  ");//+2
                linkedList.N_op(4);//+2

                Console.Write("Кол-во отсортированных элементов: 2100  ");//+2
                linkedList.N_op(4);//+2

                linkedList.N_op(4);//+2
                for (int i = 0; i < 2100; i++)
                {
                    linkedList.AddLast(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.AddFirst(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.N_op(5);//+2
                }

                linkedList.sort(linkedList, linkedList.Count);//+5
                linkedList.N_op(7);//+2


                Console.Write("Время сортировки (такты): " + linkedList.ellapledTicks + "  ");//+5
                linkedList.N_op(7);//+2

                Console.WriteLine($"Колличество операций (N_op): {linkedList.n_op}");//+4
                linkedList.N_op(6);//+2
            } // 2100 элементов

            {
                Dequeue linkedList = new Dequeue();//+2
                linkedList.N_op(5);//+2

                Console.Write("Номер сортировки: 8  ");//+2
                linkedList.N_op(4);//+2

                Console.Write("Кол-во отсортированных элементов: 2400  ");//+2
                linkedList.N_op(4);//+2

                linkedList.N_op(4);//+2
                for (int i = 0; i < 2400; i++)
                {
                    linkedList.AddLast(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.AddFirst(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.N_op(5);//+2
                }

                linkedList.sort(linkedList, linkedList.Count);//+5
                linkedList.N_op(7);//+2


                Console.Write("Время сортировки (такты): " + linkedList.ellapledTicks + "  ");//+5
                linkedList.N_op(7);//+2

                Console.WriteLine($"Колличество операций (N_op): {linkedList.n_op}");//+4
                linkedList.N_op(6);//+2
            } // 2400 элементов

            {
                Dequeue linkedList = new Dequeue();//+2
                linkedList.N_op(5);//+2

                Console.Write("Номер сортировки: 9  ");//+2
                linkedList.N_op(4);//+2

                Console.Write("Кол-во отсортированных элементов: 2700  ");//+2
                linkedList.N_op(4);//+2

                linkedList.N_op(4);//+2
                for (int i = 0; i < 2700; i++)
                {
                    linkedList.AddLast(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.AddFirst(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.N_op(5);//+2
                }

                linkedList.sort(linkedList, linkedList.Count);//+5
                linkedList.N_op(7);//+2


                Console.Write("Время сортировки (такты): " + linkedList.ellapledTicks + "  ");//+5
                linkedList.N_op(7);//+2

                Console.WriteLine($"Колличество операций (N_op): {linkedList.n_op}");//+4
                linkedList.N_op(6);//+2
            } // 2700 элементов

            {
                Dequeue linkedList = new Dequeue();//+2
                linkedList.N_op(5);//+2

                Console.Write("Номер сортировки: 10  ");//+2
                linkedList.N_op(4);//+2

                Console.Write("Кол-во отсортированных элементов: 3000  ");//+2
                linkedList.N_op(4);//+2

                linkedList.N_op(4);//+2
                for (int i = 0; i < 3000; i++)
                {
                    linkedList.AddLast(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.AddFirst(i);//+2
                    linkedList.N_op(4);//+2

                    linkedList.N_op(5);//+2
                }

                linkedList.sort(linkedList, linkedList.Count);//+5
                linkedList.N_op(7);//+2


                Console.Write("Время сортировки (такты): " + linkedList.ellapledTicks + "  ");//+5
                linkedList.N_op(7);//+2

                Console.WriteLine($"Колличество операций (N_op): {linkedList.n_op}");//+4
                linkedList.N_op(6);//+2
            } // 3000 элементов

            Console.ReadLine();
        }
    }
    //f(n) = 58 + 91*n + 2n * log_2(n)
}