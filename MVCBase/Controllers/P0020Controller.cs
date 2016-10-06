using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBase.Models;

namespace MVCBase.Controllers
{
    public class P0020Controller : Controller
    {
        public ActionResult Index()
        {
            // 多筆清單顯示. Controller預設action為Index, 詳於~/App_Start/RouteConfig.cs.
            return View(new P0020().Index());
        }
        public ActionResult Read(string id)
        {
            // 單筆顯示
            return View(new P0020().Read(id));
        }
        public ActionResult Create()
        {
            // 顯示新增網頁
            return View();
        }
        public ActionResult Update(string id)
        {
            // 顯示修改畫面
            return View(new P0020().Read(id));
        }
        public ActionResult TestModelBinder()
        {
            // 測試Model Binder
            return View();
        }
        public ActionResult SubmitCreate(T0010 t1, string btnSubmit)
        {
            // 執行新增
            int iAffected = 0;
            switch (btnSubmit)
            {
                case "新增":
                    iAffected = new P0020().Create(t1);
                    break;
            }
            return RedirectToAction("Index");
        }
        public ActionResult SubmitUpdate(T0010 t1, string btnSubmit)
        {
            // 執行修改或刪除
            int iAffected = 0;
            switch (btnSubmit)
            {
                case "修改":
                    iAffected = new P0020().Update(t1);
                    break;
                case "刪除":
                    iAffected = new P0020().Delete(t1.ms1);
                    break;
            }
            return RedirectToAction("Index");
        }
        public string TestSubmitModelBinder(TestModelBinder e, string ms5, string btnSubmit)
        {
            // ModelBinder會自動比對(URL接收欄位)與(action函數參數欄位), 相同名稱的欄位會自動填入接收的資料內容.
            // (action函數參數欄位)比對範圍為: (函數中的參數名稱)以及(class中的所有property欄位, 包括子class). 
            // 也可由Request.Form["欄位名稱"]方式取得接收資料.
            return "ms1=" + e.ms1 + // 比對property名稱符合
                "<br />, ms2=" + e.ms2 + // 比對property名稱符合
                "<br />, ms3=" + e.ms3 + // 比對property名稱符合
                "<br />, ms4=" + e.ms4 + // 比對property名稱符合
                "<br />, ms5=" + ms5 + // 比對函數參數名稱符合.
                "<br />, ms6=" + Request.Form["ms6"] + // 自行取得
                "<br />, mT0010.ms1=" + e.mT0010.ms1 + // 比對子class欄位.
                "<br />, mT0010.ms2=" + e.mT0010.ms2 + // 比對子class欄位.
                "<br />, mT0010.mi1=" + e.mT0010.mi1 + // 比對子class欄位.
                "<br />, mT0010.mi2=" + e.mT0010.mi2 + // 比對子class欄位.
                "<br />, btnSumit=" + btnSubmit; // 比對函數參數名稱符合.
        }
    }
}



