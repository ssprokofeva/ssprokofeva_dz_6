using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tumakov
{
    internal class Program
        {
            static void Main(string[] args)
            {
                Task71();
                Task72();
                Task73();

                Console.Write("Нажмите что-либо для выхода...");
                Console.ReadKey();
            }

            static void Task71()
            {
                var account = new BankAccount(10000m, BankAccount.AccountType.Savings);
                account.PrintAccountInfo();
            }

            static void Task72()
            {
                var account1 = new BankAccount(10000m, BankAccount.AccountType.Savings);
                var account2 = new BankAccount(20000m, BankAccount.AccountType.Checking);

                account1.PrintAccountInfo();
                Console.WriteLine();
                account2.PrintAccountInfo();
            }

            static void Task73()
            {
                var account1 = new BankAccount(10000m, BankAccount.AccountType.Savings);
                var account2 = new BankAccount(20000m, BankAccount.AccountType.Checking);

                account2.Withdraw(5000m);
                account2.Withdraw(25000m);

                account1.Deposit(3000m);

                account1.PrintAccountInfo();
                Console.WriteLine();
                account2.PrintAccountInfo();
            }
        }
        /// <summary>
        /// задания 7.1-7.3.(объединила в одно)
        /// </summary>

        internal class BankAccount
        {
            private readonly string accountNumber;
            private decimal balance;
            private AccountType accountType;
            private static int nextAccountNumber = 1;
            public enum AccountType
            {
                Checking,
                Savings,
                Credit
            }

            public BankAccount(decimal initialBalance, AccountType type)
            {
                // Генерация уникального номера счета
                accountNumber = GenerateNextAccountNumber();
                balance = initialBalance;
                accountType = type;
            }

            private static string GenerateNextAccountNumber()
            {
                return $"ACC{nextAccountNumber++:D10}";
            }

            public void SetBalance(decimal newBalance) => this.balance = newBalance;
            public void SetAccountType(AccountType type) => this.accountType = type;

            public string GetAccountNumber() => this.accountNumber;
            public decimal GetBalance() => this.balance;
            public AccountType GetAccountType() => this.accountType;

            public void PrintAccountInfo()
            {
                Console.WriteLine($"Номер счета: {this.accountNumber}");
                Console.WriteLine($"Баланс: {this.balance:C}");
                Console.WriteLine($"Тип счета: {this.accountType}");
            }

            public bool Withdraw(decimal amount)
            {
                if (amount > balance)
                {
                    Console.WriteLine("Недостаточно средств на счете.");
                    return false;
                }

                balance -= amount;
                Console.WriteLine($"Снято: {amount:C}. Новый баланс: {balance:C}");
                return true;
            }

            public void Deposit(decimal amount)
            {
                balance += amount;
                Console.WriteLine($"Положено: {amount:C}. Новый баланс: {balance:C}");
            }
        }
        /// <summary>
        /// Домашнее задание 7.1
        /// </summary>

        internal class Building
        {
            private int buildingId;
            private double height;
            private int floors;
            private int apartments;
            private int entrances;

            private static int lastUsedId = 0;

            public Building(double height, int floors, int apartments, int entrances)
            {
                this.buildingId = GenerateUniqueId();
                this.height = height;
                this.floors = floors;
                this.apartments = apartments;
                this.entrances = entrances;
            }


            public int GetBuildingId() => this.buildingId;
            public double GetHeight() => this.height;
            public int GetFloors() => this.floors;
            public int GetApartments() => this.apartments;
            public int GetEntrances() => this.entrances;

            public void SetHeight(double height) => this.height = height;
            public void SetFloors(int floors) => this.floors = floors;
            public void SetApartments(int apartments) => this.apartments = apartments;
            public void SetEntrances(int entrances) => this.entrances = entrances;


            private static int GenerateUniqueId()
            {
                return ++lastUsedId;
            }

            public double CalculateFloorHeight()
            {
                return height / floors;
            }

            public int CalculateApartmentsPerEntrance()
            {
                return apartments / entrances;
            }

            public int CalculateApartmentsPerFloor()
            {
                return apartments / floors;
            }

            public void PrintBuildingInfo()
            {
                Console.WriteLine($"Уникальный номер здания: {buildingId}");
                Console.WriteLine($"Высота здания: {height} м");
                Console.WriteLine($"Этажность: {floors}");
                Console.WriteLine($"Количество квартир: {apartments}");
                Console.WriteLine($"Количество подъездов: {entrances}");
                Console.WriteLine($"Высота этажа: {CalculateFloorHeight():F2} м");
                Console.WriteLine($"Квартир на подъезд: {CalculateApartmentsPerEntrance()}");
                Console.WriteLine($"Квартир на этаж: {CalculateApartmentsPerFloor()}");
            }
        }
    }
