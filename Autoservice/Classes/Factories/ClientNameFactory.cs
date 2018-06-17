using System;
using System.Threading;

namespace Autoservice.Classes.Factories
{
    public class ClientNameFactory
    {
        private readonly string[] names;

        private readonly string[] surnames;

        public ClientNameFactory()
        {
            names = new[]
            {
                "Никанор",
                "Лукьян",
                "Глеб",
                "Прокл",
                "Данила",
                "Сергей",
                "Юлиан",
                "Казимир",
                "Лука",
                "Варфоломей",
                "Трофим",
                "Мартын",
                "Евстигней",
                "Авдей",
                "Осип",
                "Вацлав",
                "Андриян",
                "Святослав",
                "Модест",
                "Леонид"
            };

            surnames = new[]
            {
                "Хромченко",
                "Тизенгаузен",
                "Ярошевский",
                "Чепурин",
                "Дубов",
                "Губин",
                "Кылымнык",
                "Сиянков",
                "Суслов",
                "Бухаров",
                "Кияк",
                "Ягренев",
                "Жаглин",
                "Ябров",
                "Плаксин",
                "Шалупов",
                "Оськин",
                "Носатенко",
                "Саян",
                "Маслов"
            };
        }

        public string GetRandomName()
        {
            var r = new Random(DateTime.UtcNow.Millisecond + 100);
            Thread.Sleep(20);
            string oute = names[r.Next(0, names.Length)];
            Thread.Sleep(20);
            return oute + $" {surnames[r.Next(0, surnames.Length)]}";
        }
    }
}