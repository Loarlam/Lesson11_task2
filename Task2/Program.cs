/*Используя Visual Studio, создайте проект по шаблону Console Application.  
Создайте класс CarCollection<T>. Реализуйте в простейшем приближении возможность использования его экземпляра для создания парка машин. 
Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать метод добавления машин с названием машины и года ее выпуска, индексатор для получения значения элемента по указанному индексу и свойство только для чтения для получения общего количества элементов.  
Создайте метод удаления всех машин автопарка. 
*/
using System;
using System.Collections.Generic;

namespace Task2
{
    interface ICarCollection<T>
    {
        string this[int index] { get; }
        int NumberOfCarsInTheList { get; }
        string InformationAboutCarsList { get; }
        void AddsCarsAndYearOfManufacture(T value1, T value2);
        void RemoveCarsInfo();
    }

    class CarCollection<T> : ICarCollection<T>
    {
        List<string> _listOfCars = new List<string>();

        public string this[int index]
        {
            get
            {
                string temporaryCar = _listOfCars[index - 1];
                _listOfCars.RemoveAt(index - 1);
                return temporaryCar;
            }
        }

        public int NumberOfCarsInTheList => _listOfCars.Count;

        public string InformationAboutCarsList
        {
            get
            {
                string result = "";

                for (int i = 0; i < _listOfCars.Count; i++)
                {
                    result += $"№{i + 1} " + _listOfCars[i] + "\n";
                }

                return result;
            }
        }

        public void AddsCarsAndYearOfManufacture(T carName, T machineYear)
        {
            string machineDataConcatenation = carName + " " + machineYear + " года";
            _listOfCars.Add(machineDataConcatenation);
        }

        public void RemoveCarsInfo()
        {
            _listOfCars.Clear();
        }
    }

    class Program
    {
        static CarCollection<string> carCollectionInstance;

        static void Main(string[] args)
        {
            carCollectionInstance = new CarCollection<string>();

            carCollectionInstance.AddsCarsAndYearOfManufacture("Daewoo", Convert.ToString(1988));
            carCollectionInstance.AddsCarsAndYearOfManufacture("Vortex", Convert.ToString(1994));
            carCollectionInstance.AddsCarsAndYearOfManufacture("Hyundai", Convert.ToString(2005));
            carCollectionInstance.AddsCarsAndYearOfManufacture("Nissan", Convert.ToString(1999));

            Console.WriteLine($"Машин в парке: {carCollectionInstance.NumberOfCarsInTheList}");
            Console.WriteLine($"\nСписок машин:\n{carCollectionInstance.InformationAboutCarsList}");
            Console.Write("Покупаю №");
            Console.WriteLine($"Моя машина {carCollectionInstance[Int32.Parse(Console.ReadLine())]}");

            Console.Write("\nКупить все машины?\n1 - да\n2 - нет, только выбранную\nОтвет = ");

            switch (Int32.Parse(Console.ReadLine()))
            {
                case 1:
                    carCollectionInstance.RemoveCarsInfo();
                    Console.WriteLine($"\nВ парке осталось {carCollectionInstance.NumberOfCarsInTheList} машин");
                    break;
                case 2:
                    Console.WriteLine($"\nВ парке осталось {carCollectionInstance.NumberOfCarsInTheList} машин");
                    break;
            }

            Console.ReadKey();
        }
    }
}
