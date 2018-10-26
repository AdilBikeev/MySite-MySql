using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.Models;

namespace MySite.Controllers
{
    public class HomeController : Controller
    {
        SiteDb dbSite=new SiteDb();

        public ActionResult Index()//возвращает домашнюю страницу
        {
            return View();
        }

        public ActionResult About()//Возращается страница содержащая информацию о приложении
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()//возвращает  страницу регистрации пользователя
        {
            return View();
        }

        [HttpPost]
        public ViewResult Registration(Users user)//Возвращает сообщение о результате обработки информации
        {
            try
            {
                if(ModelState.IsValid)
                {
                    List<Users> users = Users.Load();
                    foreach (Users item in users)
                    {
                        if (item.LOGIN == user.LOGIN)
                        {
                            throw new Exception("Пользователь с таким логином уже существует !");
                        }
                        else if (item.EMAIL == user.EMAIL)
                        {
                            throw new Exception("Пользователь с таким Email уже существует !");
                        }
                    }
                    users.Add(user);//добавляем новго пользователя в БД
                    return View("Thanks", (object)"Регистрация пройдена успешно !");
                }
                return View();
            }catch(Exception exc)
            {
                return View("Thanks", (object)exc.Message);
            }
        }
    }
}