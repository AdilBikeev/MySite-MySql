using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.Models;

namespace MySite.Controllers
{
    public class ProfileController : Controller
    {
        SiteDb siteDb = new SiteDb();

        // GET: Profile
        public ViewResult Home()//возвращает домашнюю страницу профиля
        {
            List<Users> listusers = null;
            try
            {
                if (Request.Cookies["user"] != null)//если пользователь авторизован на странице
                {
                    listusers = Users.Load();//загрыжаем данные о пользователях из БД
                    string email = Request.Cookies["user"].Value;
                    Users user = listusers.First(x => x.EMAIL == email);//находим в БД плзователя с указанным в куки Email
                    return View(user);
                }
                else
                {
                    throw new Exception("Доступ к этой странцие имеют только авторизованные пользвоатели");
                }
            }catch(Exception exc)
            {
                ViewBag.Msg = exc.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Edit()//возвращаю страницу для изменения данных профиля
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Users user)//возвращаю страницу для изменения данных профиля
        {
            List<Users> listUsers = null;
            try
            {
                if(ModelState.IsValid)//если валидация пройдена успешно
                {
                    listUsers = Users.Load();//загружаем данные из БД

                    string Email = Request.Cookies["User"].Value;

                    Users newUser = listUsers.First(x => x.EMAIL == Email);

                    int index = listUsers.IndexOf(newUser);//находим индекс авторизованного пользователя в коллекции

                    //запоминание отредактированные данные о пользователе
                    listUsers[index].NAME = user.NAME;
                    listUsers[index].SURNAME = user.SURNAME;
                    listUsers[index].ABOUTONESELF = user.ABOUTONESELF;
                    listUsers[index].DATEBIRTHDAY = user.DATEBIRTHDAY;

                    Users.SaveChanges(listUsers[index]);//сохраняем измененияы
                    throw new Exception("Изменения успешно сохранены !");
                }
                else
                {
                    throw new Exception("Неверно заполнены поля ввода");
                }
            }catch(Exception exc)
            {
                ViewBag.Msg = exc.Message;
            }
            return View();
        }

        public ActionResult Exit()//выход из профиля
        {
            Response.Cookies["User"].Expires = DateTime.Now.AddDays(-1);//удаляем данные из куки
            return RedirectToAction("Autorization", "LogIn");
        }
    }
}