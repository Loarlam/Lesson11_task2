/*Используя Visual Studio, создайте проект по шаблону Console Application.  
Создайте класс CarCollection<T>. Реализуйте в простейшем приближении возможность использования его экземпляра для создания парка машин. 
Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать метод добавления машин с названием машины и года ее выпуска, индексатор для получения значения элемента по указанному индексу и свойство только для чтения для получения общего количества элементов.  
Создайте метод удаления всех машин автопарка. 
*/
using System;
using System.Collections.Generic;

namespace Task2
{
    class CarCollection<T>
    {
        List<string> _listOfCars = new List<string>();

        public string this[int index] => _listOfCars[index+1];

        public int NumberOfcarsInTheList => _listOfCars.Count;

        public string InformationAboutCarsList
        {
            get
            {
                string result = "";

                for (int i = 0; i < _listOfCars.Count; i++)
                {
                    result += _listOfCars[i] + "\n";
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
            _listOfCars = null;
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

            Console.WriteLine($"Машин в парке: {carCollectionInstance.NumberOfcarsInTheList}");
            Console.WriteLine(carCollectionInstance.InformationAboutCarsList);

            Console.ReadKey();
        }
    }
}
