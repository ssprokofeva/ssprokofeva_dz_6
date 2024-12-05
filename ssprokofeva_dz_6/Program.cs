using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssprokofeva_dz_6
{
    abstract class Order
    { 
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; private set; }

        protected Order(string customerName)
        {
            this.CustomerName = customerName;
            this.OrderDate = DateTime.Now;
        }

        public abstract void PlaceOrder();
        public virtual void CancelOrder()
        {
            Console.WriteLine("Заказ отменен.");
        }
    }

    class OnlineOrder : Order
    {
        public string DeliveryAddress { get; set; }

        public OnlineOrder(string customerName) : base(customerName)
        {
            Console.WriteLine($"Создан онлайн заказ для клиента: {customerName}");
        }

        public OnlineOrder(string customerName, string deliveryAddress) : base(customerName)
        {
            this.DeliveryAddress = deliveryAddress;
            Console.WriteLine($"Создан онлайн заказ для клиента: {customerName} с адресом доставки: {deliveryAddress}");
        }

        public override void PlaceOrder()
        {
            Console.WriteLine($"Онлайн заказ размещен для клиента: {CustomerName}. Адрес доставки: {DeliveryAddress}");
        }

        public void UpdateDeliveryAddress(string newAddress)
        {
            this.DeliveryAddress = newAddress;
            Console.WriteLine($"Адрес доставки обновлен до: {newAddress}");
        }

        public void PrintOrderDetails()
        {
            Console.WriteLine($"Клиент: {CustomerName}, Дата заказа: {OrderDate}, Адрес доставки: {DeliveryAddress}");
        }
    }

    class OfflineOrder : Order
    {
        public string StoreLocation { get; set; }

        public OfflineOrder(string customerName) : base(customerName)
        {
            Console.WriteLine($"Создан оффлайн заказ для клиента: {customerName}");
        }

        public OfflineOrder(string customerName, string storeLocation) : base(customerName)
        {
            this.StoreLocation = storeLocation;
            Console.WriteLine($"Создан оффлайн заказ для клиента: {customerName} в магазине: {storeLocation}");
        }

        public override void PlaceOrder()
        {
            Console.WriteLine($"Оффлайн заказ размещен для клиента: {CustomerName} в магазине: {StoreLocation}");
        }

        public void ChangeStoreLocation(string newLocation)
        {
            this.StoreLocation = newLocation;
            Console.WriteLine($"Магазин изменен на: {newLocation}");
        }

        public void PrintOrderDetails()
        {
            Console.WriteLine($"Клиент: {CustomerName}, Дата заказа: {OrderDate}, Магазин: {StoreLocation}");
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string author, int pages, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Pages = pages;
            this.Price = price;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Название: {Title}, Автор: {Author}, Страниц: {Pages}, Цена: {Price:C}");
        }

        public void IncreasePrice(decimal amount)
        {
            this.Price += amount;
            Console.WriteLine($"Цена увеличена на {amount:C}. Новая цена: {this.Price:C}");
        }

        public void DecreasePrice(decimal amount)
        {
            if (this.Price >= amount)
            {
                this.Price -= amount;
                Console.WriteLine($"Цена уменьшена на {amount:C}. Новая цена: {this.Price:C}");
            }
            else
            {
                Console.WriteLine("Невозможно уменьшить цену ниже нуля.");
            }
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public bool IsVIP { get; set; }

        public Customer(string name, bool isVIP)
        {
            this.Name = name;
            this.IsVIP = isVIP;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя: {Name}, VIP статус: {(IsVIP ? "Да" : "Нет")}");
        }

        public void SendNotification(string message)
        {
            Console.WriteLine($"{Name}, уведомление отправлено: {message}");
        }

        public void SetVIPStatus(bool status)
        {
            this.IsVIP = status;
            Console.WriteLine($"Статус VIP изменен на: {status}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("Война и мир", "Лев Толстой", 1225, 500);
            var book2 = new Book("Мастер и Маргарита", "Михаил Булгаков", 368, 400);

            var customer1 = new Customer("Александр Петров", true);
            var customer2 = new Customer("Юрий Каплан", false);

            var onlineOrder1 = new OnlineOrder("Александр Петров");
            var offlineOrder1 = new OfflineOrder("Юрий Каплан", "Московский филиал");

            book1.DisplayInfo();
            book1.IncreasePrice(100);

            customer1.DisplayInfo();
            customer1.SendNotification("Ваш заказ готов!");

            onlineOrder1.PlaceOrder();
            offlineOrder1.ChangeStoreLocation("Санкт-Петербург");

            Console.ReadKey();
        }
    }
}