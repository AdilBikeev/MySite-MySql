﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySite.Controllers
{
    public class DocumentationController : Controller
    {
        #region Текста для глав
        const string chapter1 = "На сегодняшний момент язык программирования C# один из самых мощных, быстро развивающихся и " +
                "востребованных языков в ИТ-отрасли. В настоящий момент на нем пишутся самые различные " +
                "приложения: от небольших десктопных программок до крупных веб-порталов и веб-сервисов, " +
                "обслуживающих ежедневно миллионы пользователей." +
                "\n" +
                "По сравнению с другими языками C# достаточно молодой, но в то же время он уже прошел большой путь. " +
                "Первая версия языка вышла вместе с релизом Microsoft Visual Studio .NET в феврале 2002 года. Текущей " +
                "версией языка является версия C# 7.0, которая вышла в 7 марта 2017 года вместе с Visual Studio 2017." +
                "\n" +
                "C# является языком с Си-подобным синтаксисом и близок в этом отношении к C++ и Java. Поэтому, если" +
                "вы знакомы с одним из этих языков, то овладеть C# будет легче." +
                "\n" +
                "C# является объектно-ориентированным и в этом плане много перенял у Java и С++. Например, C# " +
                "поддерживает полиморфизм, наследование, перегрузку операторов, статическую типизацию. Объектно-" +
                "ориентированный подход позволяет решить задачи по построению крупных, но в тоже время гибких, " +
                "масштабируемых и расширяемых приложений. И C# продолжает активно развиваться, и с каждой новой" +
                "версией появляется все больше интересных функциональностей, как, например, лямбды, динамическое " +
                "связывание, асинхронные методы и т.д.\n$";

        const string chapter2 = "Приступив к изучению C# мы получаем целую связку готовых для работы решений, многие из них предоставляются бесплатно," +
            " например, одна из современных версий Visual Studio. Благодаря простому интерфейсу программы, с ней не тяжело разобраться. " +
            "С помощью VS мы можем создавать программы на таких известных языках программирования как: C, C++, C#, Visual Basic и т.д. " +
            "На всех этих языках в VS мы можем создать любое приложение, любого формата — консольное приложение, обычную Windows форму, " +
            "приложение для Windows Phone смартфона, библиотеку классов и тому подобные приложения. Студия очень удобна тем, что там не " +
            "нужно прописывать абсолютно все коды элементов в ручном режиме (как в простом текстовом редакторе), в среде уже готовы все " +
            "коды элементов управления (кнопки, чек-боксы, текстовые окна и тому подобные элементы). Что же из себя представляет C# (произносится как си шарп)" +
            " непосредственно как язык?" +
            "\n" +
            "\n" +
            "1. C# — является наследственным сыном двух мощных языков — C++ и Java," +
            "\n" +
            "2. C# — очень удобен в использовании (написании программ), у него достаточно простой синтаксис и мощные сигнатуры, благодаря которым мы можем создать базы данных не хуже чем SQL или LINQ," +
            "\n" +
            "3. C# — сейчас очень распространен и является одним из самых оптимальных языков программирования.\n$";

        const string chapter3 = "Я много писал на смежные темы, вроде концепции MVC, Entity Framework, паттерна «Репозиторий» и т.п. " +
            "Моим приоритетом всегда было полное раскрытие темы, чтобы читателю не приходилось гуглить недостающие детали. Этот цикл статей опишет " +
            "абсолютно все концепции ООП, которые могут интересовать начинающих разработчиков. Однако эта статья предназначена не только для тех, кто " +
            "начинает свой путь в программировании: она написана и для опытных программистов, которым может потребоваться освежить свои знания." +
            "\n" +
            "Сразу скажу, далеко в теорию мы вдаваться не будем — нас интересуют специфичные вопросы. Где это будет нужно, я буду сопровождать повествование кодом на C#." +
            "\n" +
            "Что такое ООП и в чём его плюсы?" +
            "\n" +
            "«ООП» значит «Объектно-Ориентированное Программирование». Это такой подход к написанию программ, который основывается на объектах, а не на функциях и процедурах. " +
            "Эта модель ставит в центр внимания объекты, а не действия, данные, а не логику. Объект — реализация класса. Все реализации одного класса похожи друг на друга, но могут" +
            " иметь разные параметры и значения. Объекты могут задействовать методы, специфичные для них." +
            "\n" +
            "ООП сильно упрощает процесс организации и создания структуры программы. Отдельные объекты, которые можно менять без воздействия на остальные части программы, упрощают " +
            "также и внесение в программу изменений. Так как с течением времени программы становятся всё более крупными, а их поддержка всё более тяжёлой, эти два аспекта ООП становятся " +
            "всё более актуальными." +
            "\n" +
            "Что за концепции ООП?" +
            "\n" +
            "Сейчас коротко о принципах, которые мы позже рассмотрим в подробностях:" +
            "\n" +
                "1) Абстракция данных: подробности внутренней логики скрыты от конечного пользователя. Пользователю не нужно знать, как работают те или иные классы и методы, чтоб их использовать." +
                    " Подходящим примером из реальной жизни будет велосипед — когда мы ездим на нём или меняем деталь, нам не нужно знать, как педаль приводит его в движение или как закреплена цепь.\n" +
                "2) Наследование: самый популярный принцип ООП. Наследование делает возможным повторное использование кода — если какой-то класс уже имеет какую-то логику и функции, нам не нужно " +
                    "переписывать всё это заново для создания нового класса, мы можем просто включить старый класс в новый, целиком.\n" +
                "3) Инкапсуляция: включение в класс объектов другого класса, вопросы доступа к ним, их видимости.\n"+
                "4) Полиморфизм: «поли» значит «много», а «морфизм» — «изменение» или «вариативность», таким образом, «полиморфизм» — это свойство одних и тех же объектов и методов принимать разные формы.\n"+
                "5) Обмен сообщениями: способность одних объектов вызывать методы других объектов, передавая им управление.\n" +
            "Ладно, тут мы коснулись большого количества теории, настало время действовать. Я надеюсь, это будет интересно.\n$";

        const string chapter4 = "Интерфейс содержит определения для группы связанных функциональных возможностей, которые может реализовать класс или структура." +
            "\n" +
            "С помощью интерфейсов можно, например, включить в класс поведение из нескольких источников. Эта возможность очень важна в C#, поскольку этот язык не поддерживает множественное наследование классов. " +
            "Кроме того, необходимо использовать интерфейс, если требуется имитировать наследование для структур, поскольку они не могут фактически наследовать от другой структуры или класса. " +
            "\n" +
            "Имя структуры должно быть допустимым именем идентификатора C#. По соглашению имена интерфейсов начинаются с заглавной буквы I." +
            "Любой объект (класс или структура), реализующий интерфейс IEquatable<T>, должен содержать определение для метода Equals, соответствующее сигнатуре, которую задает интерфейс. В результате вы можете быть " +
            "уверены, что класс, реализующий IEquatable<T>, содержит метод Equals, с помощью которого экземпляр этого класса может определить, равен ли он другому экземпляру того же класса." +
            "\n" +
            "Определение IEquatable<T> не предоставляет реализацию для метода Equals. Интерфейс определяет только сигнатуру. Таким образом, интерфейс в C# аналогичен абстрактному классу, в котором все методы являются " +
            "абстрактными. Класс или структура может реализовывать несколько интерфейсов, но класс может наследовать только одному классу, абстрактному или нет. Таким образом, с помощью интерфейсов можно включить в класс " +
            "поведение из нескольких источников." +
            "\n" +
            "Дополнительные сведения об абстрактных классах см. в статье Abstract and Sealed Classes and Class Members (Абстрактные и запечатанные классы и члены классов). " +
            "\n" +
            "Интерфейсы могут содержать методы, свойства, события, индексаторы, а также любое сочетание этих четырех типов членов. Ссылки на примеры см. в разделе Связанные разделы. Интерфейс не может содержать константы, " +
            "поля, операторы, конструкторы экземпляров, методы завершения или типы. Члены интерфейса автоматически являются открытыми, и они не могут включать модификаторы доступа. Члены также не могут быть статическими. " +
            "\n" +
            "Для реализации члена интерфейса соответствующий член реализующего класса должен быть открытым и не статическим, а также иметь такое же имя и сигнатуру, что и член интерфейса. " +
            "\n" +
            "Если класс (или структура) реализует интерфейс, этот класс (или структура) должен предоставлять реализацию для всех членов, которые определяет этот интерфейс. Сам интерфейс не предоставляет функциональность, " +
            "которую класс или структура может наследовать таким же образом, как можно наследовать функциональность базового класса. Однако если базовый класс реализует интерфейс, то любой класс, производный от базового" +
            " класса, наследует эту реализацию. " +
            "\n" +
            "Свойства и индексаторы класса могут определять дополнительные методы доступа для свойства или индексатора, определенного в интерфейсе. Например, интерфейс может объявлять свойство, имеющее акцессор get. Класс, " +
            "реализующий этот интерфейс, может объявлять это же свойство с обоими акцессорами (get и set). Однако если свойство или индексатор использует явную реализацию, методы доступа должны совпадать." +
            "\n" +
            "Интерфейсы могут реализовывать другие интерфейсы. Класс может включать интерфейс несколько раз через базовые классы, которым он наследует, или через интерфейсы, которые реализуют другие интерфейсы. Однако класс " +
            "может предоставить реализацию интерфейса только однократно и только если класс объявляет интерфейс как часть определения класса (class ClassName : InterfaceName). Если интерфейс наследуется, поскольку наследуется " +
            "базовый класс, реализующий этот интерфейс, то базовый класс предоставляет реализацию членов этого интерфейса. Однако производный класс может повторно реализовать члены интерфейса вместо использования унаследованной реализации." +
            "\n" +
            "Базовый класс также может реализовывать члены интерфейса с помощью виртуальных членов. В таком случае производный класс может изменять поведение интерфейса путем переопределения виртуальных членов. Дополнительные сведения о " +
            "виртуальных членах см. в статье Полиморфизм.\n$";

        const string chapter5 = "Делегаты" +
            "\n" +
            "Делегат это особый тип. И объявляется он по особому: delegate int MyDelegate (string x);" +
            "\n" +
            "Тут все просто, есть ключевое слово delegate, а дальше сам делегат с именем MyDelegate, возвращаемым типом int и одним аргументом типа string." +
            "\n" +
            "По факту же при компиляции кода в CIL — компилятор превращает каждый такой тип-делегат в одноименный тип-класс и все экземпляры данного типа-делегата по факту являются экземплярами соответствующих типов-классов. Каждый такой класс " +
            "наследует тип MulticastDelegate от которого ему достаются методы Combine и Remove, содержит конструктор с двумя аргументами target (Object) и methodPtr (IntPtr), поле invocationList (Object), и три собственных метода Invoke, BeginInvoke, EndEnvoke." +
            "\n" +
            "Объявляя новый тип-делегат мы сразу через синтаксис его объявления жестко определяем сигнатуру допустимых методов, которыми могут быть инициализированы экземпляры такого делегата. Это сразу влияет на сигнатуру автогенерируемых методов Invoke, BeginInvoke" +
            ", EndEnvoke, поэтому эти методы и не наследуются от базового типа а определяются для каждого типа-делегата отдельно." +
            "\n" +
            "Лямбда выражения" +
            "\n" +
            "Так же экземпляр делегата можно инициализировать лямбда-выражением (lambda-expression). Стоит что они были введены в C# 3.0, а до них существовали анонимные-функции появившиеся в C# 2.0." +
            "\n" +
            "Отличительной чертой лямбд является оператор =>, который делит выражение на левую часть с параметрами и правую с телом метода." +
            "\n" +
            "Допустим у нас есть делегат: delegate string MyDeleg (string verb);" +
            "\n" +
            "Синтаксис лямбд такой: MyDeleg myDeleg = (string x) => {x + \"world!\"};" +
            "\n" +
            "Как видите ключевое слово return опускается даже если есть возвращаемое значение." +
            "Также можно не указывать тип аргумента, но можно и указать для простоты чтения кода другим человеком:MyDeleg myDeleg = (x) => {x + x};" +
            "\n" +
            "В случае если имеется лишь один аргумент то можно пустить скобки, а если тело выражения состоит лишь из одной операции то можно опустить фигурные скобки: MyDeleg myDeleg = x => x + x;" +
            "\n" +
            "Если в сигнатуре делегата аргументов нет то необходимо указать пустые скобки:MyDeleg myDeleg = () => x + x;\n$";

        #endregion


        // GET: Documentation
        public ActionResult Home()
        {
            return View();
        }
        
        public ViewResult Sharp(short? chapter)//номер главы
        {
            if(chapter!=null)
            {
                switch (chapter)
                {
                    case 1:
                    {
                        return View("Sharp","",chapter1);
                    }
                    case 2:
                    {
                        return View("Sharp", "", chapter2);
                    }
                    case 3:
                    {
                        return View("Sharp", "", chapter3);
                    }
                    case 4:
                    {
                        return View("Sharp", "", chapter4);
                    }
                    case 5:
                    {
                        return View("Sharp", "", chapter5);
                    }
                    default: return View();
                }
            }
            return View();
        }

        public ContentResult CPP(short? chapter)//номер главы
        {
            /*if (chapter != null)
            {
                switch (chapter)
                {
                    case 1:
                        {
                            return View("Sharp", "", chapter1);
                        }
                    case 2:
                        {
                            return View("Sharp", "", chapter2);
                        }
                    case 3:
                        {
                            return View("Sharp", "", chapter3);
                        }
                    case 4:
                        {
                            return View("Sharp", "", chapter4);
                        }
                    case 5:
                        {
                            return View("Sharp", "", chapter5);
                        }
                    default: return View();
                }
            }*/
            return Content("Страница находится в разработке");
        }

        public ContentResult C(short? chapter)//номер главы
        {
            /*if (chapter != null)
            {
                switch (chapter)
                {
                    case 1:
                        {
                            return View("Sharp", "", chapter1);
                        }
                    case 2:
                        {
                            return View("Sharp", "", chapter2);
                        }
                    case 3:
                        {
                            return View("Sharp", "", chapter3);
                        }
                    case 4:
                        {
                            return View("Sharp", "", chapter4);
                        }
                    case 5:
                        {
                            return View("Sharp", "", chapter5);
                        }
                    default: return View();
                }
            }*/
            return Content("Страница находится в разработке");
        }

        public ContentResult Java(short? chapter)//номер главы
        {
            /*if (chapter != null)
            {
                switch (chapter)
                {
                    case 1:
                        {
                            return View("Sharp", "", chapter1);
                        }
                    case 2:
                        {
                            return View("Sharp", "", chapter2);
                        }
                    case 3:
                        {
                            return View("Sharp", "", chapter3);
                        }
                    case 4:
                        {
                            return View("Sharp", "", chapter4);
                        }
                    case 5:
                        {
                            return View("Sharp", "", chapter5);
                        }
                    default: return View();
                }
            }*/
            return Content("Страница находится в разработке");
        }

        public ContentResult Python(short? chapter)//номер главы
        {
            /*if (chapter != null)
            {
                switch (chapter)
                {
                    case 1:
                        {
                            return View("Sharp", "", chapter1);
                        }
                    case 2:
                        {
                            return View("Sharp", "", chapter2);
                        }
                    case 3:
                        {
                            return View("Sharp", "", chapter3);
                        }
                    case 4:
                        {
                            return View("Sharp", "", chapter4);
                        }
                    case 5:
                        {
                            return View("Sharp", "", chapter5);
                        }
                    default: return View();
                }
            }*/
            return Content("Страница находится в разработке");
        }

        public ContentResult JavaScript(short? chapter)//номер главы
        {
            /*if (chapter != null)
            {
                switch (chapter)
                {
                    case 1:
                        {
                            return View("Sharp", "", chapter1);
                        }
                    case 2:
                        {
                            return View("Sharp", "", chapter2);
                        }
                    case 3:
                        {
                            return View("Sharp", "", chapter3);
                        }
                    case 4:
                        {
                            return View("Sharp", "", chapter4);
                        }
                    case 5:
                        {
                            return View("Sharp", "", chapter5);
                        }
                    default: return View();
                }
            }*/
            return Content("Страница находится в разработке");
        }

        public ContentResult Windows(short? chapter)//номер главы
        {
            /*if (chapter != null)
            {
                switch (chapter)
                {
                    case 1:
                        {
                            return View("Sharp", "", chapter1);
                        }
                    case 2:
                        {
                            return View("Sharp", "", chapter2);
                        }
                    case 3:
                        {
                            return View("Sharp", "", chapter3);
                        }
                    case 4:
                        {
                            return View("Sharp", "", chapter4);
                        }
                    case 5:
                        {
                            return View("Sharp", "", chapter5);
                        }
                    default: return View();
                }
            }*/
            return Content("Страница находится в разработке");
        }

        public ContentResult Linux(short? chapter)//номер главы
        {
            /*if (chapter != null)
            {
                switch (chapter)
                {
                    case 1:
                        {
                            return View("Sharp", "", chapter1);
                        }
                    case 2:
                        {
                            return View("Sharp", "", chapter2);
                        }
                    case 3:
                        {
                            return View("Sharp", "", chapter3);
                        }
                    case 4:
                        {
                            return View("Sharp", "", chapter4);
                        }
                    case 5:
                        {
                            return View("Sharp", "", chapter5);
                        }
                    default: return View();
                }
            }*/
            return Content("Страница находится в разработке");
        }

        public ContentResult Git(short? chapter)//номер главы
        {
            /*if (chapter != null)
            {
                switch (chapter)
                {
                    case 1:
                        {
                            return View("Sharp", "", chapter1);
                        }
                    case 2:
                        {
                            return View("Sharp", "", chapter2);
                        }
                    case 3:
                        {
                            return View("Sharp", "", chapter3);
                        }
                    case 4:
                        {
                            return View("Sharp", "", chapter4);
                        }
                    case 5:
                        {
                            return View("Sharp", "", chapter5);
                        }
                    default: return View();
                }
            }*/
            return Content("Страница находится в разработке");
        }

        public ContentResult MySQL(short? chapter)//номер главы
        {
            /*if (chapter != null)
            {
                switch (chapter)
                {
                    case 1:
                        {
                            return View("Sharp", "", chapter1);
                        }
                    case 2:
                        {
                            return View("Sharp", "", chapter2);
                        }
                    case 3:
                        {
                            return View("Sharp", "", chapter3);
                        }
                    case 4:
                        {
                            return View("Sharp", "", chapter4);
                        }
                    case 5:
                        {
                            return View("Sharp", "", chapter5);
                        }
                    default: return View();
                }
            }*/
            return Content("Страница находится в разработке");
        }

        public ContentResult Entity_FrameWork(short? chapter)//номер главы
        {
            /*if (chapter != null)
            {
                switch (chapter)
                {
                    case 1:
                        {
                            return View("Sharp", "", chapter1);
                        }
                    case 2:
                        {
                            return View("Sharp", "", chapter2);
                        }
                    case 3:
                        {
                            return View("Sharp", "", chapter3);
                        }
                    case 4:
                        {
                            return View("Sharp", "", chapter4);
                        }
                    case 5:
                        {
                            return View("Sharp", "", chapter5);
                        }
                    default: return View();
                }
            }*/
            return Content("Страница находится в разработке");
        }
    }
}